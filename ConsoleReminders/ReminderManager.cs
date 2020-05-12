using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleReminders 
{
    public class ReminderManager 
    {
        private List<ReminderMonitor> Monitors = new List<ReminderMonitor>();
        private Notifier notifier = new Notifier();
        private ReminderStore store = new ReminderStore();
        private bool IsRunning {get; set;}

        public async Task Remind(Reminder[] reminders)
        {
            store.Store(reminders);
            await manage();
        }

        public async Task Start() 
        {
            store.RemoveAll();
            IsRunning = true;
        }
        public async Task Stop() 
        {
            IsRunning = false;
        }
        private async Task manage()
        {
            var Reminders = store.Retrieve();
            
            foreach (Reminder reminder in Reminders)
            {
                ReminderMonitor monitor = new ReminderMonitor(reminder.RemindTime, reminder.Content, reminder.Id.ToString());
                monitor.ReminderReady += Rm_ReminderReady;
                Monitors.Add(monitor);
            }
            
            while (IsRunning)
            {
                
                Thread.Sleep(1000);
                foreach (ReminderMonitor monitor in Monitors)
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