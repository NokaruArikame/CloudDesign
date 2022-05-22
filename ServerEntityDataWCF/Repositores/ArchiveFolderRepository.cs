using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServerEntityDataWCF.Model;

namespace ServerEntityDataWCF.Repositores
{
    public class ArchiveFolderRepository
    {
        /*public static void AddFolder(string name, int userCloudId)
        {
            using(ModelContext db = new ModelContext())
            {
                //UserCloud userCloud = db.UsersClouds.Find(userCloudId);
                ArchiveFolder archiveFolder = new ArchiveFolder()
                {
                    Name = name,
                    //UserCloudId=userCloudId
                };
                db.ArchiveFolders.Add(archiveFolder);
                //db.Entry(userCloud).State = EntityState.Modified;
                db.SaveChanges();
            }
            
        }*/

        public static void AddFolder(string name, int parentId)
        {
            using (ModelContext db = new ModelContext())
            {
                IFolder parentFolder = db.Folders.Find(parentId);
                ArchiveFolder archiveFolder;
                
                //UserCloud userCloud = db.UsersClouds.Find(userCloudId);
                archiveFolder = new ArchiveFolder()
                {
                    Name = name,
                    ParentFolder = parentFolder
                };
                db.ArchiveFolders.Add(archiveFolder);
                //db.Entry(userCloud).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public static List<ArchiveFolder> GetFolders(int parentId)
        {
            List<ArchiveFolder> folders;
            using(var db = new ModelContext())
            {
                db.ArchiveFolders.Where(f => f.ParentId==parentId).Include(f => f.ParentFolder).Include(f => f.Folders).Load();
                folders = db.ArchiveFolders.ToList();
            }
            return folders;
        }
    }
}
