using System;
using System.Collections.Generic;
using Amdorsey12.Reminders;

namespace Amdorsey12
{
    public interface IReminderManager : IDisposable
    {
        public IReminderMonitor Monitor { get; set; }
        public INotifier Notifier { get; set; }
        public IReminderStore Store { get; set; }
        public void Remind(params IReminder[] Reminders);
        public void Remind(IEnumerable<IReminder> Reminders);
        public void Start();
        public void Stop();
        public void ReminderReady();
    }
}