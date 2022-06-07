using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ClientWPF.Model
{
    [DataContract(IsReference =true)]
    public class ArchiveFolder : IFolder, ICloudItem
    {
        /*[DataMember(IsRequired = true)]
        public string Name { get; set; }

        [DataMember(IsRequired = true)]
        public int Id { get; set; }*/

        [DataMember]
        public string Path { get; set; }

        //[DataMember]
        //public virtual List<ArchiveFile> Files { get; set; } = new List<ArchiveFile>();

        [DataMember]
        public override IFolder ParentFolder { get; set; }

        public override int ParentId { get; set; }

        //[DataMember]
        //public virtual List<ArchiveFolder> Folders { get; set; } = new List<ArchiveFolder>();

        //[DataMember(IsRequired = true)]
        //public virtual UserCloud UserCloud { get; set; }

        //public int UserCloudId { get; set; }
    }
}
