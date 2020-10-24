using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShortURLService.Models
{
    public class ProfileModel
    {
        public RedirectInformation RedirectInfo { get; private set; }
        public ProfileModel(RedirectInformation Info)
        {
            RedirectInfo = Info;
        }
    }
}
