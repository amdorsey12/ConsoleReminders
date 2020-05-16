using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleReminders 
{
    public class ReminderManager : IDisposable
    {
        private ReminderMonitor Monitor { get; set; }
        private ConsoleNotifier Notifier = new ConsoleNotifier();
        private LiteDbStore Store { get; set; }

        public ReminderManager()
        {
            Store = new LiteDbStore();
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
        {
            Notifier.Notify(reminder);
            Store.MarkDone(reminder);
        }

        public void Dispose()
            => Store.Dispose();
    }
}