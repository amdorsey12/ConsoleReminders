using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleReminders 
{
    public class ReminderManager 
    {
        private ReminderMonitor monitor = new ReminderMonitor();
        private Notifier notifier = new Notifier();
        private ReminderStore store = new ReminderStore();
        public async Task Remind(IEnumerable<Reminder> reminders)
        {
            await store.Store(reminders);
        }

        public async Task Remind(params Reminder[] reminders)
        {
            await store.Store(reminders);
        }

        public async void Start() 
        {
            if (monitor.IsRunning == true)
            {
                Console.WriteLine("Program already started. Can only stop.");
            }
            else
            {
                store.RemoveAll();
                monitor.IsRunning = true;
                await Manage();
            }
        }

        public void Stop() 
        {
            monitor.IsRunning = false;
        }

        private async Task Manage()
        {
            monitor.Triggered += ReminderReady;
        }

        private async void ReminderReady(Reminder reminder)
        {
            notifier.Notify(reminder.Id.ToString(), reminder.Content);
        }

    }
}