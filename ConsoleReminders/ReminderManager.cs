using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleReminders 
{
    public class ReminderManager 
    {

        private List<ReminderMonitor> monitors = new List<ReminderMonitor>();
        private Notifier notifier = new Notifier();
        private ReminderStore store = new ReminderStore();
        private bool IsRunning {get; set;}

        public async Task Remind(IEnumerable<Reminder> reminders)
        {
            store.Store(reminders);
        }

        public async Task Remind(params Reminder[] reminders)
        {
            store.Store(reminders);
        }

        public async Task Start() 
        {
            store.RemoveAll();
            IsRunning = true;
            await Manage();
        }

        public async Task Stop() 
        {
            IsRunning = false;
        }

        private async Task Manage()
        {
            while (IsRunning)
            {
                var Reminders = store.Retrieve();
            
                foreach (Reminder reminder in Reminders)
                {
                    ReminderMonitor monitor = new ReminderMonitor(reminder.RemindTime, reminder.Content, reminder.Id.ToString());
                    monitor.ReminderReady += Rm_ReminderReady;
                    monitors.Add(monitor);
                }
                Thread.Sleep(1000);
                foreach (ReminderMonitor monitor in monitors)
                {   
                    monitor.Monitor(DateTime.Now);
                }
            }
        }

        private void Rm_ReminderReady(object sender, ReminderMonitor.ReminderReadyEventArgs e)
        {
            notifier.Notify(e.Id, e.Content);
        }

    }
}