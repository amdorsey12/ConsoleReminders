using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleReminders 
{
    public class ConsoleNotifier : INotifier
    {
        public void Notify(Reminder reminder)
            => Console.WriteLine(reminder.Content);
        
    }
}