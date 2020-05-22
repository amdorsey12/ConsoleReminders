using System;
using System.Collections.Generic;

namespace Dorsey.Reminders
{
    public interface IReminderStore : IDisposable
    {
        IEnumerable<IReminder> Get();
        void Delete(IEnumerable<IReminder> reminders);
        void Store(IEnumerable<IReminder> reminders);
        void MarkDone(IEnumerable<IReminder> reminders);
    }

    public static class ReminderStoreUtils
    {
        public static void Delete(this IReminderStore store, params IReminder[] reminders)
            => store.Delete((IEnumerable<IReminder>)reminders);

        public static void Store(this IReminderStore store, params IReminder[] reminders)
            => store.Store((IEnumerable<IReminder>)reminders);
            
        public static void MarkDone(this IReminderStore store, params IReminder[] reminders)
            => store.MarkDone((IEnumerable<IReminder>)reminders);
    }
}