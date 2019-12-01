using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace slack.Domain.ExternalServices.Models
{
    public class Edited
    {
        /// <summary>
        /// The user ID of the editor.
        /// </summary>
        [JsonProperty(PropertyName = "user")]
        public string User { get; set; }

        /// <summary>
        /// The timestamp the edit happened.
        /// </summary>
        [JsonProperty(PropertyName = "ts")]
        public string Ts { get; set; }
    }
}
