using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Dorsey.Reminders 
{
    public class ReminderManager : IReminderManager
    {
        private IReminderMonitor Monitor { get; set; }
        private INotifier Notifier { get; set; }
        private IReminderStore Store { get; set; }

        public ReminderManager(INotifier notifier, IReminderStore store)
        {
            Store = store;
            Notifier = notifier;
            Monitor = new ReminderMonitor(Store);
        }
        
        public void Remind(IEnumerable<IReminder> reminders)
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
        
        private void ReminderReady(IReminder reminder)
        {
            Notifier.Notify(reminder);
            Store.MarkDone(reminder);
        }

        public void Dispose()
            => Store.Dispose();
    }
}