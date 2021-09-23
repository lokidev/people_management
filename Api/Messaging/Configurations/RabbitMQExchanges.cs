using Newtonsoft.Json;

namespace PeopleManagement.Messaging.Configurations
{
  [JsonObject("rabbit_mq_exchanges")]
  public class RabbitMQExchanges
  {
    [JsonProperty("worldExchange")]
    public string WorldExchange { get; set; }
    [JsonProperty("karmaExchange")]
    public string KarmaExchange { get; set; }
    }
}
