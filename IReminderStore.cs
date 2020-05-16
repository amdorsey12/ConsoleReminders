using System;
using System.Collections.Generic;

namespace ConsoleReminders
{
    public interface IReminderStore : IDisposable
    {
        public IEnumerable<Reminder> Get();
        public void Delete(params Reminder[] Reminders);
        public void Delete(IEnumerable<Reminder> Reminders);
        public void Store(params Reminder[] Reminders);
        public void Store(IEnumerable<Reminder> Reminders);
        public void MarkDone(params Reminder[] Reminders);
        public void MarkDone(IEnumerable<Reminder> Reminders);
    }
}