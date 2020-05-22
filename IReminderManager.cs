using System;
using System.Collections.Generic;
using Dorsey.Reminders;

namespace Dorsey.Reminders
{
    public interface IReminderManager : IDisposable
    {
        void Remind(IEnumerable<IReminder> Reminders);
        void Start();
        void Stop();
    }

    public static class ReminderManagerUtils
    {
        public static void Remind(this IReminderManager manager, params IReminder[] reminders)
            => manager.Remind((IEnumerable<IReminder>)reminders);
    }
}