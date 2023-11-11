using StripsClientWPFReeksView.Exceptions;
using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace StripsClientWPFReeksView.Services
{
    public class StripServiceClient
    {
        private HttpClient client;

        public StripServiceClient(HttpClient client)
        {
            this.client = client;
        }

        public async Task<ReeksDTO> GetReeks(string path)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(path);
                ReeksDTO reeks = null;
                if (response.IsSuccessStatusCode)
                {
                    reeks = await response.Content.ReadAsAsync<ReeksDTO>();
                }
                return reeks;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }
}
