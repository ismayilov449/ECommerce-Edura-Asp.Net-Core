using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edura.WebUI.Infrastructure
{
    public static class SessionExtentions
    {
        public static void SetJson(this ISession session,string key,object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T GetJSon<T>(this ISession session,string key)
        {
            var data = session.GetString(key);

            return data == null ?
                default(T) : JsonConvert.DeserializeObject<T>(data);
        }
             
    }
}
