using TaskDay.Core.Enum;
using TaskDay.Model;

namespace TaskDay.Core.Event
{
    public class TaskItemChangedEventArgs
    {
        public TaskChangedType ChangedType { get; private set; }
        public TaskItemChangedEventArgs(TaskChangedType changedType)
        {
            ChangedType = changedType;
        }
    }

    public delegate void TaskChangedHandler(DailyTask dt, TaskItemChangedEventArgs args);
}
