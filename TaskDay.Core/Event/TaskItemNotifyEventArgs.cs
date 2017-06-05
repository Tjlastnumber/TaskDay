using TaskDay.Model;

namespace TaskDay.Core.Event
{
    public class TaskItemNotifyEventArgs
    {
        public DailyTask _dt;
        public TaskItemNotifyEventArgs(DailyTask dt)
        {
            this._dt = dt;
        }
    }

    public delegate void TaskNotifyHandler(TaskItemNotifyEventArgs args);
}
