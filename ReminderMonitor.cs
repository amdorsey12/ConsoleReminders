using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsoleReminders 
{
    public class ReminderMonitor 
    {

        private ReminderStore store = new ReminderStore();
        public bool IsRunning {get; set;}
        public event Action<Reminder> Triggered;

        public async void Monitor()
        {
            while (IsRunning)
            {
                await Task.Delay(500);
                var reminders = store.Get();
                foreach (Reminder reminder in reminders)
                {
                    if (DateTime.Now >= reminder.RemindTime)
                    {
                        Triggered?.Invoke(reminder);
                    }
                }
            }
            store.Dispose();
        }

    }
}