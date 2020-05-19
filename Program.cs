using System;
using System.Threading.Tasks;

namespace Amdorsey12.Reminders
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using (var manager = new ReminderManager())
            {
                manager.Start();
                manager.Remind( new Reminder { Content = "First", RemindTime = DateTime.Now.AddSeconds(10), IsDone = false },
                                new Reminder { Content = "Second", RemindTime = DateTime.Now.AddSeconds(20), IsDone = false },
                                new Reminder { Content = "Third", RemindTime = DateTime.Now.AddSeconds(30), IsDone = false }
                            );
                await Task.Delay(35000);
                manager.Stop();
            }
        }
    }
}
