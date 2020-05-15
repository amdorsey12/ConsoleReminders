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

        public void Remind(params Reminder[] reminders)
            => Remind((IEnumerable<Reminder>) reminders);
        
        public void Remind(IEnumerable<Reminder> reminders)
        {
            store.Store(reminders);
        }

        public void Start() 
        {
            if (monitor.IsRunning == true)
            {
                Console.WriteLine("Program already started. Can only stop.");
            }
            else
            {
                Manage();
                store.RemoveAll();
                monitor.IsRunning = true;
                monitor.Monitor();
            }
        }

        public void Stop() 
        {
            monitor.IsRunning = false;
            store.Dispose();
        }

        private void Manage()
        {
            monitor.Triggered += ReminderReady;
        }

        private void ReminderReady(Reminder reminder)
        {
            notifier.Notify(reminder.Id.ToString(), reminder.Content);
        }

    }
}