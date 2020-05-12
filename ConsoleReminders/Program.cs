using System;

namespace ConsoleReminders
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var manager = new ReminderManager();
            manager.Start();
            Reminder[] reminders = new Reminder[]{new Reminder { Content = "First", RemindTime = DateTime.Now, IsDone = false },
                                   new Reminder { Content = "Second", RemindTime = DateTime.Now.AddSeconds(10), IsDone = false },
                                   new Reminder { Content = "Third", RemindTime = DateTime.Now.AddSeconds(20), IsDone = false }};
            manager.Remind(reminders);
            /*anager.Remind(new Reminder { Content = "First", RemindTime = DateTime.Now, IsDone = false });
            manager.Remind(new Reminder { Content = "Second", RemindTime = DateTime.Now.AddSeconds(10), IsDone = false });
            manager.Remind(new Reminder { Content = "Third", RemindTime = DateTime.Now.AddSeconds(20), IsDone = false });*/

            manager.Stop();
        }
    }
}
