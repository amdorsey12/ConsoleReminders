﻿using System;
using System.Threading.Tasks;

namespace ConsoleReminders
{
    class Program
    {
        static async Task Main(string[] args)
        {
            
            var manager = new ReminderManager();
            await manager.Start();
            await manager.Remind( new Reminder { Content = "First", RemindTime = DateTime.Now, IsDone = false },
                            new Reminder { Content = "Second", RemindTime = DateTime.Now.AddSeconds(10), IsDone = false },
                            new Reminder { Content = "Third", RemindTime = DateTime.Now.AddSeconds(20), IsDone = false }
                        );
            await manager.Stop();
        }
    }
}
