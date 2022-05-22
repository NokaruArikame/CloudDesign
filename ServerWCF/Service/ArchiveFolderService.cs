using ServerEntityDataWCF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServerEntityDataWCF.Repositores;
using System.Text;
using ServerWCF.ServiceInner;

namespace ServerWCF.Service
{
    public class ArchiveFolderService : IArchiveFolderService
    {
        /*public void AddFolder(string name, int cloudId)
        {
            ArchiveFolderRepository.AddFolder(name, cloudId);
        }*/

        public void AddFolder(string name, int parentFolderId)
        {
            ArchiveFolderRepository.AddFolder(name, parentFolderId);
        }

        /*public List<ArchiveFolder> GetChildFolders(int parentId, int cloudId)
        {
            throw new NotImplementedException();
        }*/

        /*public ArchiveFolder GetFirstFolder(int cloudId)
        {
            throw new NotImplementedException();
        }*/

        public string GetFolders(int parentId)
        {
            List<ArchiveFolder> folders = ArchiveFolderRepository.GetFolders(parentId);
            StringBuilder foldersInfo = new StringBuilder(6);
            foreach (ArchiveFolder folder in folders)
            {
                foldersInfo.Append("Folder:"+folder.Name);
                if(folder.ParentFolder!=null)
                    foldersInfo.Append("Its parent: "+folder.ParentFolder.Name);
                if(folder.Folders.Count>0)
                    foreach(ArchiveFolder folder2 in folder.Folders)
                        foldersInfo.Append("It's child: "+folder2.Name);
            }
            return foldersInfo.ToString();
        }

        public string GetFoldersJson(int parentId)
        {
            List<ArchiveFolder> foldersList = 
                ArchiveFolderRepository.GetFolders(parentId);
            string foldersJson = 
                EntityJsonSerializer.ArchiveFolderToJson(foldersList);
            return foldersJson;
        }

        internal void RemoveUser(string name)
        {
            UserRepository.RemoveUser(name);
        }
    }
}