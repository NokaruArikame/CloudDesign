using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using ServerEntityDataWCF.Model;

namespace ServerWCF.ServiceInner
{
    public class EntityJsonSerializer
    {
        JsonSerializer JsonSerializer = new JsonSerializer();
        public static EntityJsonSerializer Instance { get; set; }

        public static string UserToJson(User user)
        {
            if(user == null)
                throw new ArgumentNullException(nameof(user));
            string userString = JsonConvert.SerializeObject(user);
            return userString;
        }
        public static User JsonToUser(string userString)
        {
            if(string.IsNullOrEmpty(userString))
                throw new ArgumentNullException(nameof(userString));
            User user = JsonConvert.DeserializeObject<User>(userString);
            return user;
        }

        public static string ArchiveFolderToJson(List<ArchiveFolder> archiveFolders)
        {
            if (archiveFolders.Count <1)
                throw new ArgumentException(nameof(archiveFolders)+" dont exist objects.");
            string archiveFolderString = JsonConvert.SerializeObject(archiveFolders, Formatting.Indented);
            return archiveFolderString;
        }
        public static List<ArchiveFolder> JsonToArchiveFolders(string archiveFoldersString)
        {
            if(string.IsNullOrEmpty(archiveFoldersString))
                throw new ArgumentNullException(nameof(archiveFoldersString));
            List<ArchiveFolder> archiveFolders = 
                JsonConvert.DeserializeObject<List<ArchiveFolder>>(archiveFoldersString);
            return archiveFolders;
        } 


    }
}