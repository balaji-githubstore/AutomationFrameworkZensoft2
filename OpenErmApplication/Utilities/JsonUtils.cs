using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Zensoft.OpenErmApplication.Utilities
{
    class JsonUtils
    {
        public static string GetValue(string file,string key)
        {
            StreamReader reader = new StreamReader(file);
            dynamic json = JsonConvert.DeserializeObject(reader.ReadToEnd());
            return Convert.ToString(json[key]);
        }
    }
}
