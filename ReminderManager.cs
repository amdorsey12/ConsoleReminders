using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleReminders 
{
    public class ReminderManager : IDisposable
    {
        private ReminderMonitor Monitor { get; set; }
        private Notifier Notifier = new Notifier();
        private ReminderStore Store { get; set; }

        public ReminderManager()
        {
            Store = new ReminderStore();
            Monitor = new ReminderMonitor(Store);
        }

        public void Remind(params Reminder[] reminders)
            => Remind((IEnumerable<Reminder>) reminders);
        
        public void Remind(IEnumerable<Reminder> reminders)
            => Store.Store(reminders);
        
        public void Start() 
        {
            if (Monitor.IsRunning)
            {
                throw new InvalidOperationException();
            }
            else
            {
                Monitor.Triggered += ReminderReady;
                Monitor.IsRunning = true;
                Monitor.Monitor();
            }
        }

        public void Stop() 
            => Monitor.IsRunning = false;
        
        private void ReminderReady(Reminder reminder)
            => Notifier.Notify(reminder.Id.ToString(), reminder.Content);

        public void Dispose()
            => Store.Dispose();
    }
}