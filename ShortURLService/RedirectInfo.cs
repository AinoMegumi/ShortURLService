using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShortURLService
{
    public class RedirectInfo
    {
        [JsonProperty(PropertyName = "id", Required = Required.Always)]
        public string ID;
        [JsonProperty(PropertyName = "url", Required = Required.Always)]
        public string RedirectURL;
    }
    public class RedirectInfos
    {
        [JsonProperty(PropertyName = "redirects", Required = Required.Always)]
        public List<RedirectInfo> Infos;
        public static implicit operator List<RedirectInfo> (RedirectInfos r) => r.Infos;
    }
}
