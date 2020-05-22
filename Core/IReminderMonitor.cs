using System;

namespace Dorsey.Reminders
{
    public interface IReminderMonitor
    {
        bool IsRunning { get; set; }
        event Action<IReminder> Triggered;
        void Monitor();

    }
}