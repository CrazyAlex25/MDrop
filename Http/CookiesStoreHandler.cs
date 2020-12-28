using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace MDrop.Http
{
    public class CookiesStoreHandler : HttpClientHandler
    {
        private static readonly BinaryFormatter formatter = new BinaryFormatter();

        const string _cookiesFile = "cookies.dat";
        public CookiesStoreHandler()
        {
            this.UseCookies = true;
            this.CookieContainer = Load();
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response= await base.SendAsync(request, cancellationToken);
            Save();
            return response;
        }

        private volatile object _lock = new object();
        private CookieContainer Load()
        {
            lock(_lock)
            {
                try
                {
                    using (var f = File.OpenRead(_cookiesFile))
                    {
                        return (CookieContainer)formatter.Deserialize(f);
                    }
                }
                catch
                {
                    return new CookieContainer();
                }
            }
            
        }
        private void Save()
        {
            lock(_lock)
            {
                try
                {
                    using (var f = File.Create(_cookiesFile))
                    {
                        formatter.Serialize(f, CookieContainer);
                    }
                }
                catch { }
            }
        }
    }
}
