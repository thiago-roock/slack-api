using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace slack.Domain.ExternalServices.Models
{
    public class CreateMsg
    {
        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }
    }
}
