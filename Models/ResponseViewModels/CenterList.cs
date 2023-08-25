using Newtonsoft.Json;

namespace External_API_Calling.Models.ResponseViewModels
{
    public class CenterList
    {
        //[JsonProperty("id")]
        public int Id { get; set; }

        //[JsonProperty("name")]
        public string Name { get; set; }

        //[JsonProperty("Place")]
        public string Place { get; set; }

        //[JsonProperty("State")]
        public string State { get; set; }
    }
}
