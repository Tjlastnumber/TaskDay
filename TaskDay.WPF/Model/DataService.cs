using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskDay.Core;
using TaskDay.Model;

namespace TaskDay.WPF.Model
{
    public class DataService : IDataService
    {
        public void GetTaskGroups(Action<List<ITaskGroup>, Exception> callback)
        {
            // Use this to connect to the actual data service

            var item = Core.TaskManager.GetTaskGroups();
            callback(item, null);
        }

        public System.Threading.Tasks.Task<List<ITaskGroup>> GetTaskGroups()
        {
            return Task.Run(() => TaskManager.GetTaskGroups());
        }
    }
}