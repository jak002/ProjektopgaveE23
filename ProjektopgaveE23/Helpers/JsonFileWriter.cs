using System.Text.Json;

namespace ProjektopgaveE23.Helpers
{
    public class JsonFileWriter<T>
    {
        public static void WriteToJson(List<T> elements, string jsonFileName)
        {
            using (FileStream outputStream = File.Create(jsonFileName))
            {
                var writer = new Utf8JsonWriter(outputStream, new JsonWriterOptions
                {
                    SkipValidation = false,
                    Indented = true
                });

                JsonSerializer.Serialize<T[]>(writer, elements.ToArray());
            }
        }
    }
}
