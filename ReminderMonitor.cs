using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dorsey.Reminders 
{
    public class ReminderMonitor : IReminderMonitor
    {
        private IReminderStore Store { get; set; }
        public bool IsRunning { get; set; }

        public event Action<IReminder> Triggered;

        public ReminderMonitor(IReminderStore store)
            => this.Store = store;

        public async void Monitor()
        {
            while (IsRunning)
            {
                await Task.Delay(500);
                var reminders = Store.Get();
                foreach (Reminder reminder in reminders)
                {
                    if (DateTime.Now >= reminder.RemindTime)
                    {
                        Triggered?.Invoke(reminder);
                    }
                }
            }
        }
    }
}