using System;

namespace Dorsey.Reminders
{
    public interface IReminder
    {
        string Id { get; }
        string Content { get; set; }
        bool IsDone{ get; set; }
        DateTime RemindTime { get; set; }
    }
}