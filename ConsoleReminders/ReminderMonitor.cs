using System;

namespace ConsoleReminders 
{
    public class ReminderMonitor 
    {
        private DateTime readyTime;
        private string content;
        private string id;
        public ReminderMonitor(DateTime passedTime, string passedContent, string id)
        {
            readyTime = passedTime;
            content = passedContent;
            this.id = id;
        }
        public void Monitor(DateTime currentTime)
        {
            if (currentTime >= readyTime)
            {
                ReminderReadyEventArgs args = new ReminderReadyEventArgs();
                args.ReadyTime = readyTime;
                args.Content = content;
                args.Id = id;
                OnReminderReady(args);
            }
        }
        public event EventHandler<ReminderReadyEventArgs> ReminderReady;
        protected virtual void OnReminderReady(ReminderReadyEventArgs e)
        {
            EventHandler<ReminderReadyEventArgs> handler = ReminderReady;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        public class ReminderReadyEventArgs : EventArgs
        {
            public DateTime ReadyTime { get; set; }
            public string Content { get; set; }
            public string Id {get; set;}
        }
    }
}