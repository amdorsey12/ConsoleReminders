using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Amdorsey12.Reminders 
{
    public class ReminderMonitor : IReminderMonitor
    {
        private IReminderStore Store { get; set;}
        public bool IsRunning {get; set;}
        IReminderStore IReminderMonitor.Store { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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
            Store.Dispose();
        }
    }
}