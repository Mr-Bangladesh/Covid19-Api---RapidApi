using System.Collections.Generic;
using Newtonsoft.Json;

namespace API_Consume___Covid19.Models
{

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Province
    {
        [JsonProperty("province")]
        public string Name { get; set; }

        [JsonProperty("confirmed")]
        public int Confirmed { get; set; }

        [JsonProperty("recovered")]
        public int Recovered { get; set; }

        [JsonProperty("deaths")]
        public int Deaths { get; set; }

        [JsonProperty("active")]
        public int Active { get; set; }
    }

    public class CovidDataModel
    {
        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("provinces")]
        public List<Province> Provinces { get; set; }

        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }
    }



}
