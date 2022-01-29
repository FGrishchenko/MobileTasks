using Newtonsoft.Json;
using System.IO;

namespace androidTEst.Utilities
{
    public static class DeserializationData
    {
        public static T ReadDataFromFile<T>(string pathToFile)
        {
            return JsonConvert.DeserializeObject<T>(File.ReadAllText(pathToFile));
        }
    }
}