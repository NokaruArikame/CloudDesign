using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientWPF.Model
{
    public abstract class ObservableCloudItems<T>
    {
        public T Current { get; set; }

        public ObservableCollection<ObservableCloudItems<T>> Children { get; set; }

        protected ObservableCloudItems(T current, Func<T,IEnumerable<T>> expand)
        {
            Current = current;
            Children = new ObservableCollection<ObservableCloudItems<T>>();
            foreach(var item in expand(Current))
            {
                Children.Add(Create(item));
            }
        }

        protected abstract ObservableCloudItems<T> Create(T current);

    }
}
