using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskDay.Core.CoreCollectionExpand
{
    public static class CollectionExpand
    {
        public static void ForEach<T>(this IEnumerable<T> list, Action<T> doWork)
        {
            foreach (var item in list)
            {
                doWork(item);
            }
        }
    }
}
