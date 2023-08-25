using Newtonsoft.Json;

namespace External_API_Calling.Models.ResponseViewModels
{
    public class Center
    {
        //[JsonProperty("centres")]
        public List<CenterList> Centres { get; set; }
    }
}
