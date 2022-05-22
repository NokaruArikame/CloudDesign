using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ServerEntityDataWCF.Model
{
    [DataContract(IsReference =true)]
    public class ArchiveFile
    {
        [DataMember(IsRequired = true)]
        public int Id { get; set; }

        [DataMember(IsRequired = true)]
        public string Name { get; set; }

        [DataMember]
        public string Path { get; set; }

        [DataMember(IsRequired = true)]
        public int Size { get; set; }

        public int ParentId { get; set; }

        [DataMember]
        public virtual IFolder ParentFolder { get; set; }

        [DataMember(IsRequired = true)]
        public virtual UserCloud UserCloud { get; set; }

        public int UserCloudId { get; set; }
    }
}
