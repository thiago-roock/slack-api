using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace slack.Domain.ExternalServices.Models
{
    public class SlackResultado
    {
        [JsonProperty(PropertyName = "ok")]
        public bool OK { get; set; }

        [DefaultValue("")]
        [JsonProperty(PropertyName = "error", DefaultValueHandling = DefaultValueHandling.Populate)]
        public string Error { get; set; }

        [JsonProperty(PropertyName = "ts")]
        public string Ts { get; set; }

        [JsonProperty(PropertyName = "channel")]
        public string Channel { get; set; }

        [JsonProperty(PropertyName = "message")]
        public Message Message { get; set; }

    }
}
