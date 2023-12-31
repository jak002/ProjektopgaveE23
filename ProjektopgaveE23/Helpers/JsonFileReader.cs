﻿using System.Text.Json;

namespace ProjektopgaveE23.Helpers
{
    public class JsonFileReader<T>
    {
        public static List<T> ReadJson(string jsonFileName)
        {
            using (var jsonFileReader = File.OpenText(jsonFileName))
            {
                string dataIn = jsonFileReader.ReadToEnd();
                return JsonSerializer.Deserialize<List<T>>(dataIn);
            }
        }
    }
}
