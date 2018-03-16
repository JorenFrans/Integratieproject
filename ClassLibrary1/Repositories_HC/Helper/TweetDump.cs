using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories_HC
{
    public class TweetDump
    {
        [JsonProperty("records")]
        public Tweet[] Tweet { get; set; }
    }
}
