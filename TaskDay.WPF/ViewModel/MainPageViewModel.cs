using GalaSoft.MvvmLight;
using System.Linq;
using TaskDay.Core;
using TaskDay.Model;
using System.Collections.Generic;
using TaskDay.WPF.Model;
using GalaSoft.MvvmLight.CommandWpf;

namespace TaskDay.WPF.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainPageViewModel : ViewModelBase
    {
        private readonly IDataService _dataService;

        private List<ITaskGroup> _taskGroups;

        public List<ITaskGroup> TaskGroups
        {
            get { return _taskGroups; }
            set { Set(ref _taskGroups, value); }
        }

        private RelayCommand _groupsChangeCommand;

        /// <summary>
        /// Gets the GroupChangeCommand.
        /// </summary>
        public RelayCommand GroupChangeCommand
        {
            get
            {
                return _groupsChangeCommand
                    ?? (_groupsChangeCommand = new RelayCommand(
                    () =>
                    {

                    }));
            }
        }

        /// <summary>
        /// Initializes a new instance of the MainPageViewModel class.
        /// </summary>
        public MainPageViewModel(IDataService dataService)
        {
            _dataService = dataService;

            Init();
        }

        async private void Init()
        {
            TaskGroups = await _dataService.GetTaskGroups();
        }
    }
}