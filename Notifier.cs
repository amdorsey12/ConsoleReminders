using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleReminders 
{
    public class Notifier
    {
        private List<string> Notifications = new List<string>();

        public void Notify(string id, string content)
        {
            if (!Notifications.Contains(id))
            {
                Console.WriteLine(content);
                Notifications.Add(id);
            }
        }
    }
}