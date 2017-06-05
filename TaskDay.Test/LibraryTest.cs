using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaskDay.Core;
using System.Linq;
using TaskDay.GeneralLibrary;
using TaskDay.Model;

namespace TaskDay.Test
{
    [TestClass, System.Runtime.InteropServices.GuidAttribute("58A60108-436D-4EF4-979F-9E65E247AEA0")]
    public class LibraryTest
    {
        [TestMethod]
        public void FileSave_Test()
        {
            string json = "{\"Titel\":\"Title1\",\"Content\":\"Content1\"}";

            FileHelper.SaveJosn(json);

            Assert.IsTrue(File.Exists(FileHelper.FilePath));
        }

        [TestMethod]
        public void ManagerTaskJosnSave_Test()
        {
            var doingTasks = DoingTasks.Instance;
            var finishTasks = FinishTasks.Instance;

            doingTasks.DailyTasks = new System.Collections.Generic.List<DailyTask>()
                {
                    new DailyTask{ Title = "Title1", TaskItems =new List<TaskItem>{ new TaskItem{Content =  "Content1"}}}, 
                    new DailyTask{ Title = "Title2", TaskItems =new List<TaskItem>{ new TaskItem{Content =  "Content2"}}}, 
                    new DailyTask{ Title = "Title3", TaskItems =new List<TaskItem>{ new TaskItem{Content =  "Content3"}}}, 
                    new DailyTask{ Title = "Title4", TaskItems =new List<TaskItem>{ new TaskItem{Content =  "Content4"}}} 
                };

            finishTasks.DailyTasks = new System.Collections.Generic.List<DailyTask>()
                {
                    new DailyTask{Title = "Title0", TaskItems = new List<TaskItem>{ new TaskItem{ Content = "Content0"}}}
                };

            TaskManager.AddGroup(doingTasks);
            TaskManager.AddGroup(finishTasks);

            FileHelper.SaveJosn(TaskManager.ConvertFormatJson());

            Assert.IsTrue(File.Exists(FileHelper.FilePath));
            Assert.AreEqual(File.ReadAllText(FileHelper.FilePath, Encoding.UTF8), TaskManager.ConvertFormatJson());
        }

        [TestMethod]
        public void ReadTaskJson()
        {
            var group = FileHelper.ReadJosn<List<CustomTasks>>();
            Assert.IsNotNull(group);
        }

        [TestMethod]
        public void ReadTaskJsonConvert()
        {
            var group = FileHelper.ReadJosn<List<CustomTasks>>();
            List<ITaskGroup> igroup = group.ToList<ITaskGroup>();

            Assert.IsNotNull(igroup);
        }
    }
}
