using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Team_SRRPG.Utils
{
    public static class JsonSerializerHelper
    {
        private static readonly string BasePath =
            Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)
            ?? string.Empty;
        private static readonly JsonSerializerOptions _options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            Converters = { new JsonStringEnumConverter() },
            WriteIndented = true,
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
        };

        public static T Deserialize<T> (string filePath)
        {
            var fullPath = Path.Combine(BasePath, filePath);
            if (!File.Exists(fullPath))
                return default;

            var json = File.ReadAllText(fullPath);

            return JsonSerializer.Deserialize<T>(json, _options) ?? throw new InvalidOperationException("데이터 로드 실패");
        }

        public static void Serialize<T>(T obj, string filePath)
        {
            try
            {
                var text = JsonSerializer.Serialize(obj, _options);

                var fullPath = Path.Combine(BasePath, filePath);
                var dir = Path.GetDirectoryName(fullPath);
                if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
                    Directory.CreateDirectory(dir);

                File.WriteAllText(fullPath, text);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
