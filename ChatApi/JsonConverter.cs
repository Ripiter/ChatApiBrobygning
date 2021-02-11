using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApi
{
    public static class JsonConverter
    {
        public static T Deserialize<T>(string _value)
        {
            return JsonConvert.DeserializeObject<T>(_value);
        }
    }
}
