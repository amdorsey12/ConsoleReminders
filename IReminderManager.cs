using System;
using System.Collections.Generic;
using Amdorsey12.Reminders;

namespace Amdorsey12
{
    interface IReminderManager : IDisposable
    {
        public void Remind(params IReminder[] Reminders);
        public void Remind(IEnumerable<IReminder> Reminders);
        public void Start();
        public void Stop();
    }
}