using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientWPF.Model
{
    public class FolderItem : CloudItem<IFolder>
    {
        public override string Name
        {
            get { return Item.Name; }
            set { Item.Name = value; }
        }
        public ObservableCollection<FolderItem> ChildrenFolders { get; set; }
        public ObservableCollection<FileItem> Files { get; set; }

        public FolderItem(IFolder folder):base(folder)
        {
            ChildrenFolders = new ObservableCollection<FolderItem>();
            foreach(var f in Item.Folders)
            {
                ChildrenFolders.Add(new FolderItem(f));
            }
            Files = new ObservableCollection<FileItem>();
            foreach(ArchiveFile f in Item.Files)
            {
                Files.Add(new FileItem(f) { ParentFolderItem = this});
            }


        }

        public void Add(ArchiveFolder folder)
        {
            Item.Folders.Add(folder);
            ChildrenFolders.Add(new FolderItem(folder));
        }

        public void Add(ArchiveFile archiveFile)
        {
            Item.Files.Add(archiveFile);
            Files.Add(new FileItem(archiveFile) { ParentFolderItem = this }) ;
        }



    }
}
