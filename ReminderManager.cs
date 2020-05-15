using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleReminders 
{
    public class ReminderManager : IDisposable
    {

        private ReminderMonitor monitor { get; set; }
        private Notifier notifier = new Notifier();
        private ReminderStore store { get; set; }

        public ReminderManager()
        {
            store = new ReminderStore();
            monitor = new ReminderMonitor(store);
        }

        public void Remind(params Reminder[] reminders)
            => Remind((IEnumerable<Reminder>) reminders);
        
        public void Remind(IEnumerable<Reminder> reminders)
        {
            store.Store(reminders);
        }

        public void Start() 
        {
            if (monitor.IsRunning)
            {
                throw new Exception("Manager already started, you can only stop");
            }
            else
            {
                monitor.Triggered += ReminderReady;
                monitor.IsRunning = true;
                monitor.Monitor();
            }
        }

        public void Stop() 
        {
            monitor.IsRunning = false;
        }

        private void ReminderReady(Reminder reminder)
        {
            notifier.Notify(reminder.Id.ToString(), reminder.Content);
        }

        public void Dispose()
        {
            store.Dispose();
        }

    }
}