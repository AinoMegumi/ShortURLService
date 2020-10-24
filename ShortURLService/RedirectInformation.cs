using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShortURLService
{
    public class RedirectInformation
    {
        [JsonProperty(PropertyName = "name", Required = Required.Always)]
        public string SiteName;
        [JsonProperty(PropertyName = "id", Required = Required.Always)]
        public string ID;
        [JsonProperty(PropertyName = "url", Required = Required.Always)]
        public string RedirectURL;
        [JsonProperty(PropertyName = "image", Required = Required.DisallowNull)]
        public string ImageFileName;
        [JsonProperty(PropertyName = "admin", Required = Required.Always)]
        public string Administrator;
        [JsonProperty(PropertyName = "desc", Required = Required.DisallowNull)]
        public string Description;
    }
    public class RedirectInformations
    {
        [JsonProperty(PropertyName = "redirects", Required = Required.Always)]
        public List<RedirectInformation> Infos;
        public static implicit operator List<RedirectInformation> (RedirectInformations r) => r.Infos;
    }
}
