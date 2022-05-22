using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ClientWPF.Model
{
    [DataContract]
    public abstract class IFolder
    {
        [DataMember(IsRequired = true)]
        public int Id { get; set; }

        [DataMember(IsRequired = true)]
        public string Name { get; set; }

        [DataMember(IsRequired = false)]
        public List<ArchiveFile> Files { get; set; } = new List<ArchiveFile>();

        [DataMember(IsRequired = false)]
        public List<ArchiveFolder> Folders { get; set; } = new List<ArchiveFolder>();
    }
}
