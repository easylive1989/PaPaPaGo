using Newtonsoft.Json;

namespace PapapaGo.Sample
{
    public class ConfirmRequest : RequestBase
    {
        [JsonProperty("online_order_id")]
        public string online_order_id { get; set; }
    }
}