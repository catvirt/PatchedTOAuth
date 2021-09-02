namespace PatchedTOAuth.Utils
{
    public class UserGroup
    {
        /// <summary>
        /// Rank ids | Can be modified!
        /// </summary>
        private static readonly string[] userGroups = new string[]
        {
                "2", //member
                "10", //vip
                "11", //nova
                "12" //diamond
        };
        public static string[] UserGroups => userGroups;
    }
}
