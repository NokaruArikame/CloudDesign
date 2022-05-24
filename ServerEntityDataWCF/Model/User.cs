using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ServerEntityDataWCF.Model
{
    [DataContract(IsReference=true)]
    public class User
    {
        [DataMember(IsRequired =true)]
        public int Id { get; set; }

        [DataMember (IsRequired =true)]
        public string Name { get; set; }

        [DataMember]
        public virtual UserCloud UserCloud { get; set; }

    }
}
