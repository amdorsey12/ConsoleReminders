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
            await Task.Run(() => store.Store(reminders));
        }

        public async Task Remind(params Reminder[] reminders)
        {
            await Task.Run(() => store.Store(reminders));
        }

        public async Task Start() 
        {
            store.RemoveAll();
            IsRunning = true;
            await Task.Run(() => Manage());
        }

        public void Stop() 
        {
            IsRunning = false;
        }

        private async Task Manage()
        {
            while (IsRunning)
            {
                var Reminders = await Task.Run(() => store.Retrieve());
            
                foreach (Reminder reminder in Reminders)
                {
                    ReminderMonitor monitor = new ReminderMonitor(reminder.RemindTime, reminder.Content, reminder.Id.ToString());
                    monitor.ReminderReady += Rm_ReminderReady;
                    monitors.Add(monitor);
                }
                //Thread.Sleep(1000);
                foreach (ReminderMonitor monitor in monitors)
                {   
                    monitor.Monitor(DateTime.Now);
                }
            }
        }

        private async void Rm_ReminderReady(object sender, ReminderMonitor.ReminderReadyEventArgs e)
        {
            await Task.Run(() => notifier.Notify(e.Id, e.Content));
        }

    }
}