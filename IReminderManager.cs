using System;
using System.Collections.Generic;
using Dorsey.Reminders;

namespace Dorsey
{
    public interface IReminderManager : IDisposable
    {
        void Remind(params IReminder[] Reminders);
        void Remind(IEnumerable<IReminder> Reminders);
        void Start();
        void Stop();
    }
}