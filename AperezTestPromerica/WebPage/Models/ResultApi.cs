using Newtonsoft.Json;

namespace WebPage.Models
{
    /// <summary>
    /// Clase generica que se usa para respuestas desde API
    /// Id: para devolver valor Unico de clase de dominio
    /// Code: para devolver un valor si fue exitoso o fracaso
    /// </summary>
    public class ResultApi
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public object Data { get; set; }
        public string Message { get; set; }

        public T ToObjet<T>()
        {
            var jsonSerializerSettings = new JsonSerializerSettings
            {
                CheckAdditionalContent = true,
                TypeNameHandling = TypeNameHandling.None,
                MissingMemberHandling = MissingMemberHandling.Error
            };

            return JsonConvert.DeserializeObject<T>(Data.ToString(), jsonSerializerSettings);
        }
    }
}
