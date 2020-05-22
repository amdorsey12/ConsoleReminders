using System;

namespace Dorsey.Reminders
{
    public interface IReminder
    {
        string Id { get; set; }
        string Content { get; set; }
        bool IsDone{ get; set; }
        DateTime RemindTime { get; set; }
    }
}