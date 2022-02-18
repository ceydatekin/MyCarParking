using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Instagram.Helpers
{
    public class SessionHelper
    {
        private readonly IHttpContextAccessor HttpContextAccessor;
        public SessionHelper(IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;
        }
        public void Set(string key, object value)
        {
            value = !String.IsNullOrEmpty(value.ToString()) ? value : "";
            HttpContextAccessor.HttpContext.Session.SetString(key, value + "");
        }
        public string Get(string key)
        {
            return HttpContextAccessor.HttpContext.Session.GetString(key);
        }
    }
}
