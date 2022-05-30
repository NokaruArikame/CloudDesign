using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientWPF.Model
{
    public interface ICloudItem
    {
        int Id { get; set; }
        string Name { get; set; }
        IFolder ParentFolder { get; set; }
        int ParentId { get; set; }

    }
}
