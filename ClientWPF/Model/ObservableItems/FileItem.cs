using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientWPF.Model
{
    /// <summary>
    /// Базовый класс для 
    /// </summary>
    public class FileItem : CloudItem<ArchiveFile>
    {
        public override string Name
        {
            get { return Item.Name; }
            set { Item.Name = value; }
        }
        public FolderItem ParentFolderItem { get; set; }
        public FileItem(ArchiveFile archiveFile) :base(archiveFile)
        {
        }
    }
}
