using Newtonsoft.Json.Linq;

namespace External_API_Calling.Extensions
{
    public static class HttpCallServiceGenericExtension
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        public async static Task<T2> HttpCall<T2>(this string url, HttpMethod httpMethod, HttpContent? content)
        {
            HttpRequestMessage request = new HttpRequestMessage(httpMethod, url);
            if (content != null)
            {
                request.Content = content;
            }

            HttpResponseMessage response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();
            return JObject.Parse(responseBody).ToObject<T2>();
        }
    }
}
