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
    public class ArchiveFolder : IFolder
    {

        [DataMember]
        public string Path { get; set; }

        [DataMember]
        public virtual IFolder ParentFolder { get; set; }

        public int ParentId { get; set; }

    }
}
