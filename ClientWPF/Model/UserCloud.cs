using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ClientWPF.Model
{
    [DataContract(IsReference =true)]
    public class UserCloud : IFolder
    {
        /*[DataMember(IsRequired =true)]
        public int Id { get; set; }

        [DataMember(IsRequired =true)]
        public string Name { get; set; }*/

        [DataMember(IsRequired = true)]
        public virtual User User { get; set; }

        public int UserId { get; set; }
        public override IFolder ParentFolder
        {
            get { return this; }
            set {; }
        }
        public override int ParentId
        {
            get { return this.Id; }
            set {; }
        }

        //[DataMember(IsRequired = false)]
        //public virtual List<ArchiveFolder> Folders { get; set; } =new List<ArchiveFolder>();

        //[DataMember(IsRequired = false)]
        //public virtual List<ArchiveFile> Files { get; set; } = new List<ArchiveFile>();
    }
}
