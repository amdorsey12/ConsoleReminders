using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amdorsey12.Reminders 
{
    public class ConsoleNotifier : INotifier
    {
        void INotifier.Notify(IReminder reminder)
            => Console.WriteLine(reminder.Content);
        
    }
}