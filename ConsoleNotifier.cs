using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dorsey.Reminders 
{
    public class ConsoleNotifier : INotifier
    {
        public void Notify(IReminder reminder)
            => Console.WriteLine(reminder.Content);
        
    }
}