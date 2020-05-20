using System;
using System.Collections.Generic;

namespace Dorsey.Reminders
{
    public interface IReminderStore : IDisposable
    {
        IEnumerable<IReminder> Get();
        void Delete(params IReminder[] Reminders);
        void Delete(IEnumerable<IReminder> Reminders);
        void Store(params IReminder[] Reminders);
        void Store(IEnumerable<IReminder> Reminders);
        void MarkDone(params IReminder[] Reminders);
        void MarkDone(IEnumerable<IReminder> Reminders);
    }
}