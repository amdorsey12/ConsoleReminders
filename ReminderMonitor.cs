using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsoleReminders 
{
    public class ReminderMonitor 
    {
        private LiteDbStore Store { get; set;}
        public bool IsRunning {get; set;}
        public event Action<Reminder> Triggered;

        public ReminderMonitor(LiteDbStore store)
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
            Store.Dispose();
        }
    }
}