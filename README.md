# PatchedTOAuth
PatchedTO - Fully asyncronous example made for .NET


# Example:

```csharp
using PatchedTOAuth.Auth;
using PatchedTOAuth.Utils;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PatchedTOAuth
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            var key = "";

            if (File.Exists("key.json"))
            {
                key = (await KeySaveGrab.GetKey("key.json")).AuthKey;
            }
            else
            {
                Console.WriteLine("Key: ");

                key = Console.ReadLine();
            }

            //var authSetup = new AuthControl(key, "YourAppName");

            var authSetup = new AuthControl(key);

            var checkUserDataAsync = await authSetup.GetStatusAsync(System.Net.Http.HttpMethod.Get);

            if (!checkUserDataAsync.Status)
            {
                Console.WriteLine(" The key you provided was incorrect!");

                await Task.Delay(1000);

                Environment.Exit(0);

                return;
            }

            if (!UserGroup.UserGroups.Any(s => s == checkUserDataAsync.UserInfo.Rank))
            {
                Console.WriteLine(" You don't have the required UG! ");

                await Task.Delay(1000);

                Environment.Exit(0);

                return;
            }

            if (!File.Exists("key.json"))
            {
                await KeySaveGrab.SaveKeyAsync("key.json", key);
            }

            Console.WriteLine("Success!");
            
            // you can use as well interpolated string!

            Console.WriteLine("IP: " + checkUserDataAsync.UserInfo.Ip);
            Console.WriteLine("RANK: " + checkUserDataAsync.UserInfo.Rank);
            Console.WriteLine("EXP: " + checkUserDataAsync.UserInfo.Exp);
            Console.WriteLine("REP: " + checkUserDataAsync.UserInfo.Rep);
            Console.WriteLine("POST: " + checkUserDataAsync.UserInfo.Post);
            Console.WriteLine("UID: " + checkUserDataAsync.UserInfo.Uid);
            Console.WriteLine("USER: " + checkUserDataAsync.UserInfo.User);

            Console.WriteLine("SESSION-INFO: " + checkUserDataAsync.SessionInfo.Time);

            await Task.Delay(-1);
        }
    }
}
          
```


