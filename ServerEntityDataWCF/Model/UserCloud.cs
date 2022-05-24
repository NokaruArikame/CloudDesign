using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ServerEntityDataWCF.Model
{
    [DataContract(IsReference =true)]
    public class UserCloud : IFolder
    {

        [DataMember(IsRequired = true)]
        public virtual User User { get; set; }

        public int UserId { get; set; }

    }
}
