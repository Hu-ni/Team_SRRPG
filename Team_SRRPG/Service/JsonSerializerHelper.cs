using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Team_SRRPG.Service
{
    public static class JsonSerializerHelper
    {
        private static readonly string Path = System.IO.Path.GetDirectoryName(
    System.Reflection.Assembly.GetExecutingAssembly().Location) ?? string.Empty;
        public static T Deserialize<T> (string filePath)
        {
            JsonSerializer serializer = new JsonSerializer(typeof(T));
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                return (T)serializer.Deserialize(fs);
            }
        }

        
    }
}
