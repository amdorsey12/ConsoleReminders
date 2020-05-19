using System;

namespace Amdorsey12.Reminders
{
    public interface IReminder
    {
        string Id { get; set; }
        string Content { get; set; }
        bool IsDone{ get; set; }
        DateTime RemindTime { get; set; }
    }
}