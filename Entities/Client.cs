using System;
using Newtonsoft.Json;

namespace client.Entities
{
    public class Client
    {
        [JsonProperty(PropertyName ="id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "firstname")]
        public string FirstName { get; set; }
        [JsonProperty(PropertyName = "surname")]
        public string SurName { get; set; }
        [JsonProperty(PropertyName = "cellnumber")]
        public string CellNumber { get; set; }
        [JsonProperty(PropertyName = "idnumber")]
        public string IdNumber { get; set; }
    }
}
