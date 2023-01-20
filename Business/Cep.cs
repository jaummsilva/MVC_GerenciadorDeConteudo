using System.IO;
using System.Net;
using System.Web.Script.Serialization;

namespace Business
{
    public class Cep
    {
        public string CEP { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        public static Cep Busca(string cep)
        {
            var cepObj = new Cep();
            var url = "https://cdn.apicep.com/file/apicep/" + cep + ".json";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            string json = string.Empty;
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                json = reader.ReadToEnd();
            }

            JavaScriptSerializer json_serializer = new JavaScriptSerializer();
            JsonCepObject cepjson = json_serializer.Deserialize<JsonCepObject>(json);

            cepObj.CEP = cepjson.code;
            cepObj.Endereco = cepjson.adress;
            cepObj.Bairro = cepjson.district;
            cepObj.Estado = cepjson.state;
            cepObj.Cidade = cepjson.city;
            return cepObj;
        }
    }
    public class JsonCepObject
    {
    
        public string code { get; set; }
        public string adress { get; set; }
        public string district { get; set; }
        public string city { get; set; }
        public string state { get; set; }

    }
}
