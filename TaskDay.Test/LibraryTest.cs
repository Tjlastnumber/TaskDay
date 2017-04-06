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
            TaskManager.AddGroup(new DoingTasks
            {
                DailyTasks = new System.Collections.Generic.List<DailyTask>()
                {
                    new DailyTask{ Title = "Title1", Content = "Content1"}, 
                    new DailyTask{ Title = "Title2", Content = "Content2"}, 
                    new DailyTask{ Title = "Title3", Content = "Content3"}, 
                    new DailyTask{ Title = "Title4", Content = "Content4"}, 
                },
            });

            TaskManager.AddGroup(new DeletedTasks
            {
                DailyTasks = new System.Collections.Generic.List<DailyTask>()
                {
                    new DailyTask{Title = "Title0", Content = "Content0"}
                }
            });

            FileHelper.SaveJosn(TaskManager.ConvertJson());

            Assert.IsTrue(File.Exists(FileHelper.FilePath));
            Assert.AreEqual(File.ReadAllText(FileHelper.FilePath, Encoding.UTF8), TaskManager.ConvertJson());
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
