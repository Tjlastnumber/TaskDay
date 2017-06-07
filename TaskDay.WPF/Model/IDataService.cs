using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskDay.Model;

namespace TaskDay.WPF.Model
{
    public interface IDataService
    {
        //void GetTaskGroups(Action<List<ITaskGroup>, Exception> callback);
        Task<List<ITaskGroup>> GetTaskGroups();
    }
}
