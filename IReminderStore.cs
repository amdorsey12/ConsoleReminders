using System;
using System.Collections.Generic;

namespace Dorsey.Reminders
{
    interface IReminderStore : IDisposable
    {
        IEnumerable<IReminder> Get();
        public void Delete(params IReminder[] Reminders);
        public void Delete(IEnumerable<IReminder> Reminders);
        public void Store(params IReminder[] Reminders);
        public void Store(IEnumerable<IReminder> Reminders);
        public void MarkDone(params IReminder[] Reminders);
        public void MarkDone(IEnumerable<IReminder> Reminders);
    }
}