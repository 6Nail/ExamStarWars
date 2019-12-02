using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExamSwapi
{
    class Person
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("height")]
        public string Height { get; set; }
        [JsonProperty("mass")]
        public string Mass { get; set; }
        [JsonProperty("hair_color")]
        public string HairColor { get; set; }
        [JsonProperty("skin_color")]
        public string SkinСolor { get; set; }
        [JsonProperty("eye_color")]
        public string EyeColor { get; set; }
        [JsonProperty("birth_year")]
        public string BirthYear { get; set; }
        [JsonProperty("gender")]
        public string Gender { get; set; }
        [JsonProperty("homeworld")]
        public string Homeworld { get; set; }       
        [JsonProperty("created")]
        public DateTime Created { get; set; }
        [JsonProperty("edited")]
        public DateTime Edited { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
