﻿using Helpers.Helper.Convert;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Helpers.Sort
{
    public static class SortExtension
    {
        public static async Task Sort(JObject jObj)
        {
            var props = jObj.Properties().ToList();
            foreach (var prop in props)
            {
                prop.Remove();
            }

            foreach (var prop in props.OrderBy(p => p.Name))
            {
                jObj.Add(prop);
                if (prop.Value is JObject @object)
                {
                    await Sort(@object);
                }
            }
        }

        public static async Task<T> SortObject<T>(object doc) where T : new()
        {
            var jOb = JObject.FromObject(doc);
            await Sort(jOb);
            var jsonObject = JsonConvert.SerializeObject(jOb, Formatting.Indented);
            var t = jsonObject.ToDeserialize<T>();
            return t;
        }
    }
}
