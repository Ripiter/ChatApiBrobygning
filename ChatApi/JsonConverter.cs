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
            T deserialized = default(T);

            try
            {
                deserialized = JsonConvert.DeserializeObject<T>(_value);
            }
            catch (Exception e)
            {
                //Log message here
            }

            return deserialized;
        }

        public static string Serialize<T>(T objectToSerialize)
        {
            string serialized = "";

            try
            {
                serialized = JsonConvert.SerializeObject(objectToSerialize);
            }
            catch(Exception e)
            {
                //Log message here
            }

            return serialized;
        }
    }
}
