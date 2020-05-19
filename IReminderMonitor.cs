using System;

namespace Amdorsey12.Reminders
{
    public interface IReminderMonitor
    {
        public bool IsRunning { get; set; }
        public event Action<IReminder> Triggered;
        public void Monitor();

    }
}