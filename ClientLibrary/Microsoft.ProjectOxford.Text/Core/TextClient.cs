using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.ProjectOxford.Text.Core
{
    public abstract class TextClient
    {
        private const string APPLICATION_JSON_CONTENT_TYPE = "application/json";
        private const string GET_METHOD = "GET";
        private const string OCP_APIM_SUBSCRIPTION_KEY = "Ocp-Apim-Subscription-Key";
        private const string POST_METHOD = "POST";

        public TextClient(string apiKey)
        {
            this.ApiKey = apiKey;
        }

        public string ApiKey { get; set; }
        public string Url { get; set; }

        protected string SendPost(string data)
        {
            return SendPost(this.Url, data);
        }

        protected string SendPost(string url, string data)
        {
            return this.SendPostAsync(url, data).Result;
        }

        protected async Task<string> SendPostAsync(string data)
        {
            return await SendPostAsync(this.Url, data);
        }

        protected async Task<string> SendPostAsync(string url, string data)
        {
            if (String.IsNullOrWhiteSpace(url)) throw new ArgumentException(nameof(url));
            if (String.IsNullOrWhiteSpace(this.ApiKey)) throw new ArgumentException(nameof(ApiKey));
            if (String.IsNullOrWhiteSpace(data)) throw new ArgumentException(nameof(data));

            byte[] reqData = Encoding.UTF8.GetBytes(data);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Headers.Add(OCP_APIM_SUBSCRIPTION_KEY, this.ApiKey);
            request.ContentType = APPLICATION_JSON_CONTENT_TYPE;
            request.Accept = APPLICATION_JSON_CONTENT_TYPE;
            request.ContentLength = reqData.Length;
            request.Method = POST_METHOD;

            var reqStream = await request.GetRequestStreamAsync();
            reqStream.Write(reqData, 0, reqData.Length);
            reqStream.Close();

            var response = await request.GetResponseAsync();
            var responseStream = response.GetResponseStream();
            var reader = new StreamReader(responseStream);
            var responseData = reader.ReadToEnd();
            reader.Close();
            response.Close();

            return responseData;
        }

        protected string SendGet()
        {
            return SendGet(this.Url);
        }

        protected string SendGet(string url)
        {
            return SendGetAsync(url).Result;
        }

        protected async Task<string> SendGetAsync()
        {
            return await SendGetAsync(this.Url);
        }

        protected async Task<string> SendGetAsync(string url)
        {
            if (String.IsNullOrWhiteSpace(url)) throw new ArgumentException(nameof(url));
            if (String.IsNullOrWhiteSpace(this.ApiKey)) throw new ArgumentException(nameof(ApiKey));

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Headers.Add(OCP_APIM_SUBSCRIPTION_KEY, this.ApiKey);
            request.Method = GET_METHOD;

            var response = await request.GetResponseAsync();
            var responseStream = response.GetResponseStream();
            var reader = new StreamReader(responseStream);
            var responseData = reader.ReadToEnd();
            reader.Close();
            response.Close();

            return responseData;
        }
    }
}
