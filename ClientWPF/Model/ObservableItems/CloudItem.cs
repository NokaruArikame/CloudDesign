using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientWPF.Model
{
    /// <summary>
    /// Базовый класс декоратора 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class CloudItem<T>
    {
        public T Item { get; set; }
        public virtual string Name { get; set; }

        public CloudItem(T item)
        {
            Item = item;
        }

        public override string ToString()
        {
            return Name.ToString();
        }


    }
}
