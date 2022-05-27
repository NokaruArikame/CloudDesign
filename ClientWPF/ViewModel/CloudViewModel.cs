using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ClientWPF.Model;
using ClientWPF.View;
using ClientWPF.CloudService;
using ClientWPF;

namespace ClientWPF.ViewModel
{
    internal class CloudViewModel : INotifyPropertyChanged
    {

        List<ArchiveFile> archiveFiles;
        List<ArchiveFolder> ArchiveFolders;

        public CloudViewModel()
        {
            #region Example Start Data
            User user = new User()
            {
                Name = "Noka",
                Id = 1,
                Password = "123"
            };
            UserCloud userCloud = new UserCloud()
            {
                Id = 1,
                Name = "NokaCloud",
                Files = new List<ArchiveFile>(),
                Folders = new List<ArchiveFolder>()
            };
            user.UserCloud = userCloud;

            ArchiveFolder folder1 = new ArchiveFolder()
            {
                Name = "First Folder",
                Id = 2,
                Files = new List<ArchiveFile>(),
                Folders = new List<ArchiveFolder>()
            };

            ArchiveFolder folder2 = new ArchiveFolder()
            {
                Name = "Second Folder",
                Id = 3,
                Files = new List<ArchiveFile>(),
                Folders = new List<ArchiveFolder>(),
                ParentFolder = folder1,
                ParentId = folder1.Id
            };

            ArchiveFile archiveFile1 = new ArchiveFile()
            {
                Name = "First File",
                Id = 1,
                Size = 100,
                Path = "First Path",
                ParentFolder = userCloud,
                ParentId = userCloud.Id,
                UserCloudId = userCloud.Id
            };

            ArchiveFile archiveFile2 = new ArchiveFile()
            {
                Name = "Second File",
                Id = 2,
                Size = 150,
                Path = "Second Path",
                ParentId = folder1.Id,
                ParentFolder = folder1,
                UserCloud = userCloud,
                UserCloudId = userCloud.Id
            };
            #endregion
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if(PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
