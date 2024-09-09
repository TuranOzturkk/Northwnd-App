using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace NorthwndApp.MvcWebUI.Extensions
{
    public static class SessionExtension
    {
        public static void SetObject(this ISession session,string key,object data)
        {
            string jsonStr = JsonConvert.SerializeObject(data); ;
            session.SetString(key, jsonStr);
        }

        public static T GetObject<T>(this ISession session, string key)
        {
            string jsonStr = session.GetString(key);

            if(!string.IsNullOrEmpty(jsonStr))
                return JsonConvert.DeserializeObject<T>(jsonStr);

            return default(T);
           
        }
    }
}
