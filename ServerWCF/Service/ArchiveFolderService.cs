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
            EntityArchiveFolderRepository.AddFolder(name, cloudId);
        }*/

        public void AddFolder(string name, int parentFolderId)
        {
            EntityArchiveFolderRepository.AddFolder(name, parentFolderId);
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
            List<ArchiveFolder> folders = EntityArchiveFolderRepository.GetFolders(parentId);
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
                EntityArchiveFolderRepository.GetFolders(parentId);
            string foldersJson = 
                EntityJsonSerializer.ArchiveFolderToJson(foldersList);
            return foldersJson;
        }

        public string GetCloudJson(int userId)
        {
            UserCloud userCloud = EntityUserCloudRepository.GetCloud(userId);
            string cloudJson;
            cloudJson = EntityJsonSerializer.UserCloudToJson(userCloud);
            return cloudJson;
        }

        public string[] GetData(int userId)
        {
            UserCloud userCloud = EntityUserCloudRepository.GetCloud(userId);
            List<ArchiveFolder> archiveFolders = EntityArchiveFolderRepository.GetFolders(userCloud.Id);
            string[] data = new string[2];
            data[0] = EntityJsonSerializer.UserCloudToJson(userCloud);
            data[1] = EntityJsonSerializer.ArchiveFolderToJson(archiveFolders);
            return data;
        }

        internal void RemoveUser(string name)
        {
            EntityUserRepository.RemoveUser(name);
        }
    }
}