using Newtonsoft.Json;
using PatchedTOAuth.Models;
using System.IO;
using System.Threading.Tasks;

namespace PatchedTOAuth.Utils
{
    public class KeySaveGrab
    {
        public static async Task SaveKeyAsync(string path, string key)
        {
            var keySaveHandler = JsonConvert.SerializeObject(
                new Key
                {
                    AuthKey = key
                }, Formatting.Indented
            );
            await File.AppendAllTextAsync(path, keySaveHandler);
        }
        public static async Task<Key> GetKey(string path) => JsonConvert.DeserializeObject<Key>(
            await File.ReadAllTextAsync(path)
        );
    }
}
