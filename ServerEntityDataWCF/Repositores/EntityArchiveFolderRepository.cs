using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServerEntityDataWCF.Model;

namespace ServerEntityDataWCF.Repositores
{
    public class EntityArchiveFolderRepository
    {

        public static void AddFolder(string name, int parentId)
        {
            using (ModelContext db = new ModelContext())
            {
                IFolder parentFolder = db.Folders.Find(parentId);
                ArchiveFolder archiveFolder;

                archiveFolder = new ArchiveFolder()
                {
                    Name = name,
                    ParentFolder = parentFolder
                };
                db.ArchiveFolders.Add(archiveFolder);
                db.SaveChanges();
            }
        }

        public static List<ArchiveFolder> GetFolders(int parentId)
        {
            List<ArchiveFolder> folders;
            using(var db = new ModelContext())
            {
                folders = db.ArchiveFolders.Where(f=>f.ParentId==parentId).Include(f=>f.Folders).ToList();
            }
            return folders;
        }

        

    }
}
