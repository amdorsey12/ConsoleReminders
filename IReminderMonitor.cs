using System;

namespace Amdorsey12.Reminders
{
    public interface IReminderMonitor
    {
        public IReminderStore Store { get; set; }
        public bool IsRunning { get; set; }
        public event Action<IReminder> Triggered;
        public void Monitor();

    }
}