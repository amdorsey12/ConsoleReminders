using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsoleReminders 
{
    public class ReminderMonitor 
    {
        private ReminderStore store = new ReminderStore();
        private List<Reminder> reminders = new List<Reminder>();
        public bool IsRunning {get; set;}

        public event Action<Reminder> Triggered;

        public ReminderMonitor()
        {
            reminders = store.Retrieve();
            Monitor();
        }

        private async void Monitor()
        {
            while (IsRunning)
            {
                await Task.Delay(500);
                foreach (Reminder reminder in reminders)
                {
                    if (DateTime.Now == reminder.RemindTime)
                    {
                        Triggered?.Invoke(reminder);
                    }
                }
            }
        }
    }
}