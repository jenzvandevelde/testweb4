using StripsBL.Interfaces;
using StripsBL.Model;
using StripsDL.Exceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace StripsDL.Repositories
{
    public class StripsRepository : IStripsRepository
    {
        private string connectionString;

        public StripsRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public Reeks GetReeks(int reeksId)
        {
            string sql = "SELECT r.id, s.id, r.Naam,  s.Titel, s.nr FROM Reeks r join Strip s on s.Reeks = r.id where r.id=@reeksId";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    try
                    {
                        //List<Strip> strips = new List<Strip>();
                        conn.Open();
                        cmd.CommandText = sql;
                        cmd.Parameters.AddWithValue("@reeksId", reeksId);
                        IDataReader reader = cmd.ExecuteReader();
                        Reeks reeks = null;
                        while (reader.Read())
                        {
                            if (reeks == null)
                            {
                                reeks = new Reeks(reeksId, (string)reader["naam"]);
                            }

                            if (reader["nr"] == DBNull.Value)
                            {
                                reeks.Strips.Add(new Strip((int)reader["id"], (string)reader["Titel"], 0));
                            }
                            else
                            {
                                reeks.Strips.Add(new Strip((int)reader["id"], (string)reader["Titel"], (int?)reader["nr"]));
                            }
                        }
                        reader.Close();
                        reeks.Strips = reeks.Strips.OrderBy(s => s.Nr).ToList();
                        return reeks;
                    }
                    catch (Exception ex)
                    {
                        throw new StripsRepositoryException("Fout in de de dataLaag, bij GetReeks()", ex);
                    }
                }
            }
        }

        public Strip GetStrip(int stripId)
        {
            string sql = "Select Id, Nr, Titel FROM strip where Id = @id";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    try
                    {
                        Strip strip = null;

                        conn.Open();
                        cmd.CommandText = sql;
                        cmd.Parameters.AddWithValue("@id", stripId);
                        cmd.ExecuteReader();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                if (reader["nr"] == DBNull.Value)
                                {
                                    strip = new Strip((int)reader["id"], (string)reader["Titel"], 0);
                                }
                                else
                                {
                                    strip = new Strip((int)reader["id"], (string)reader["Titel"], (int)reader["Nr"]);

                                }

                            }
                        }


                        return strip;
                    }
                    catch (Exception ex)
                    {
                        throw new StripsRepositoryException("Fout in de datalaag, bij getStrip");
                    }
                }
            }
        }
    }
}
