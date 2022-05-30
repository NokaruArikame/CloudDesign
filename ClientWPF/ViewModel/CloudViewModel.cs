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
    public class CloudViewModel : INotifyPropertyChanged
    {

        private List<ArchiveFile> archiveFiles;
        private List<ArchiveFolder> archiveFolders;
        private List<IFolder> folders;
        private User user;
        private UserCloud userCloud;
        private BindingList<ICloudItem> cloudItems;
        private IFolder selectedFolder;

        private RelayCommand selectFolderCommand;
        private RelayCommand testRelayCommand;
        private RelayCommand addFolderCommand;

        #region Items GettersSetters

        public User User
        {
            get { return user; }
            set { user = value; }
        }

        public List<ArchiveFile> ArchiveFiles
        {
            get { return archiveFiles; }
            set {   archiveFiles = value;
                OnPropertyChanged("ArchiveFiles");
            }
        }

        public List<ArchiveFolder> ArchiveFolders
        {
            get { return archiveFolders; }
            set
            {
                archiveFolders = value;
                OnPropertyChanged("ArchiveFolders");
            }
        }

        public List<IFolder > Folders
        {
            get { return folders; }
            set 
            { 
                folders = value;
                OnPropertyChanged("Folders");
            }
        }
        public UserCloud UserCloud
        {
            get { return userCloud; }
            set
            {
                userCloud = value;
                OnPropertyChanged("UserCloud");
            }
        }

        public BindingList<ICloudItem> CloudItems
        {
            get { return cloudItems; }
            set
            {
                cloudItems = value;
                OnPropertyChanged("CloudItems");
            }
        }

        public IFolder SelectedFolder
        {
            get { return selectedFolder; }
            set {   selectedFolder = value;
                    OnPropertyChanged("SelectedFolder");
            }
        }

        #endregion

        #region Commands GettersSetters

        public RelayCommand TestRelayCommand
        {
            get
            {
                return testRelayCommand ??
                  (testRelayCommand = new RelayCommand((obj) =>
                  {
                      Environment.Exit(0);
                  }));

            }
        }

        public RelayCommand SelectFolderCommand
        {
            get
            {
                return selectFolderCommand ??
                    (selectFolderCommand = new RelayCommand((selectedItem) =>
                    {
                        System.Diagnostics.Debug.WriteLine("It's working");
                        if(selectedItem == null)
                        {
                            System.Diagnostics.Debug.WriteLine("Selected item is null");
                            return;
                        }
                        System.Diagnostics.Debug.WriteLine("Selected: " + selectedItem?.ToString());
                        SelectedFolder = selectedItem as IFolder;
                        System.Diagnostics.Debug.WriteLine("Assigned: " + SelectedFolder.Name);

                    }));
            }
        }

        public RelayCommand AddFolderCommand
        {
            get {
                return addFolderCommand ??
                  (new RelayCommand((obj) =>
                  {
                      IFolder parentFolder = obj as IFolder;
                      ArchiveFolder archiveFolder = new ArchiveFolder()
                      {
                          Name = "New Folder",
                          ParentFolder = parentFolder,
                          ParentId = parentFolder.Id,
                          Files = new List<ArchiveFile>(),
                          Folders = new List<ArchiveFolder>()
                      };
                      parentFolder.Folders.Add(archiveFolder);
                      Folders.Add(archiveFolder);
                  }));
            }
        }


        #endregion

        public CloudViewModel()
        {
            System.Diagnostics.Debug.WriteLine("Debug WL is working");
            #region Example Start Data
            User = new User()
            {
                Name = "Noka",
                Id = 1,
                Password = "123"
            };
            this.UserCloud = new UserCloud()
            {
                Id = 1,
                Name = "NokaCloud",
                User = user,
                Files = new List<ArchiveFile>(),
                Folders = new List<ArchiveFolder>()
            };
            user.UserCloud = UserCloud;
            System.Diagnostics.Debug.WriteLine(userCloud.Name);

            ArchiveFolder folder1 = new ArchiveFolder()
            {
                Name = "First Folder",
                Id = 2,
                ParentFolder = userCloud,
                ParentId = 1,
                Files = new List<ArchiveFile>(),
                Folders = new List<ArchiveFolder>()
            };
            UserCloud.Folders.Add(folder1);

            ArchiveFolder folder4 = new ArchiveFolder()
            {
                Name = "Fourth Folder",
                Id = 5,
                ParentFolder = userCloud,
                ParentId = 1,
                Files = new List<ArchiveFile>(),
                Folders = new List<ArchiveFolder>()
            };
            UserCloud.Folders.Add(folder4);

            ArchiveFolder folder2 = new ArchiveFolder()
            {
                Name = "Second Folder",
                Id = 3,
                Files = new List<ArchiveFile>(),
                Folders = new List<ArchiveFolder>(),
                ParentFolder = folder1,
                ParentId = folder1.Id
            };

            folder1.Folders.Add(folder2);

            ArchiveFolder folder3 = new ArchiveFolder()
            {
                Name = "Third Folder",
                Id = 4,
                Files = new List<ArchiveFile>(),
                Folders = new List<ArchiveFolder>(),
                ParentFolder = folder2,
                ParentId = folder2.Id
            };

            folder2.Folders.Add(folder3);

            ArchiveFile archiveFile1 = new ArchiveFile()
            {
                Name = "First File",
                Id = 1,
                Size = 100,
                Path = "First Path",
                ParentFolder = UserCloud,
                ParentId = UserCloud.Id,
                UserCloudId = UserCloud.Id
            };

            

            UserCloud.Files.Add(archiveFile1);
            
            ArchiveFile archiveFile2 = new ArchiveFile()
            {
                Name = "Second File",
                Id = 2,
                Size = 150,
                Path = "Second Path",
                ParentId = folder1.Id,
                ParentFolder = folder1,
                UserCloud = UserCloud,
                UserCloudId = UserCloud.Id
            };

            ArchiveFile archiveFile3 = new ArchiveFile()
            {
                Name = "Third File",
                Id = 2,
                Size = 200,
                Path = "Second Path",
                ParentId = folder1.Id,
                ParentFolder = folder1,
                UserCloud = UserCloud,
                UserCloudId = UserCloud.Id
            };

            folder1.Files.Add(archiveFile2);
            folder1.Files.Add(archiveFile3);

            ArchiveFolders = new List<ArchiveFolder>();
            ArchiveFiles = new List<ArchiveFile>();
            ArchiveFiles.Add(archiveFile1);
            ArchiveFiles.Add(archiveFile2);
            ArchiveFolders.Add(folder1);
            ArchiveFolders.Add(folder2);
            ArchiveFolders.Add(folder3);

            /*this.UserCloud.Folders.Add(folder1);
            this.UserCloud.Folders.Add(folder2);
            this.UserCloud.Folders.Add(folder3);*/


            CloudItems = new BindingList<ICloudItem>();

            CloudItems.Add(folder1);
            //CloudItems.Add(folder2);
            CloudItems.Add(folder3);
            CloudItems.Add(archiveFile1);
            //CloudItems.Add(archiveFile2);
            Folders = new List<IFolder>();
            Folders.Add(UserCloud);
           /*Folders.Add(folder1);
            Folders.Add(folder2);
            Folders.Add(folder3);*/

            SelectedFolder = UserCloud;
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
