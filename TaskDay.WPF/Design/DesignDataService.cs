using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskDay.Core;
using TaskDay.Model;
using TaskDay.WPF.Model;

namespace TaskDay.WPF.Design
{
    public class DesignDataService : IDataService
    {
        public void GetTaskGroups(Action<List<ITaskGroup>, Exception> callback)
        {
            // Use this to create design time data

            var item = TaskManager.GetTaskGroups(); 
            callback(item, null);
        }

        public System.Threading.Tasks.Task<List<ITaskGroup>> GetTaskGroups()
        {
            return Task.Run(() => TaskManager.GetTaskGroups());
        }
    }
}