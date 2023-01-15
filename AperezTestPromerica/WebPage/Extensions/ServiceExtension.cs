using Newtonsoft.Json;
using System.Text;

namespace WebPage.Extensions
{
    public static class ServiceExtension
    {
        #region CONSTANTES
        public const string GET = "GET";
        public const string POST = "POST";
        public const string PUT = "PUT";
        public const string DELETE = "DELETE";
        #endregion

        #region METODOS
        public static async Task<T> ExcuteAPI<T>(this IHttpClientFactory httpClient, string cliente, string action, string method, object data) where T : class
        {
            string result = null;
            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            var client = httpClient.CreateClient(cliente);
            client.Timeout = TimeSpan.FromMinutes(10);

            switch (method.ToUpper())
            {
                case POST:
                    var response = await client.PostAsync(action, content);
                    result = await response.Content.ReadAsStringAsync();
                    break;
                case PUT:
                    var response2 = await client.PutAsync(action, content);
                    result = await response2.Content.ReadAsStringAsync();
                    break;
                case DELETE:
                    var response3 = await client.DeleteAsync(action);
                    result = await response3.Content.ReadAsStringAsync();
                    break;
                case GET:
                    var response4 = await client.GetAsync(action);
                    result = await response4.Content.ReadAsStringAsync();
                    break;
                default:
                    break;
            }

            try
            {
                var jsonSerializerSettings = new JsonSerializerSettings
                {
                    CheckAdditionalContent = true,
                    TypeNameHandling = TypeNameHandling.None,
                    MissingMemberHandling = MissingMemberHandling.Error,
                    NullValueHandling = NullValueHandling.Ignore,
                    DefaultValueHandling = DefaultValueHandling.Ignore

                };

                return JsonConvert.DeserializeObject<T>(result, jsonSerializerSettings);
            }
            catch (JsonException ex)
            {
                throw new JsonException("Error al deserializar el json:" + ex);
            }
        }

        public static void SetObject(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T GetObject<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default : JsonConvert.DeserializeObject<T>(value);
        }
        #endregion
    }
}
