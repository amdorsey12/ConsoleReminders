using System;
using System.Collections.Generic;
using Dorsey.Reminders;

namespace Dorsey
{
    interface IReminderManager : IDisposable
    {
        public void Remind(params IReminder[] Reminders);
        public void Remind(IEnumerable<IReminder> Reminders);
        public void Start();
        public void Stop();
    }
}