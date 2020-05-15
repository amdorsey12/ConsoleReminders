using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleReminders 
{
    public class Notifier
    {

        private List<string> notifications = new List<string>();

        public void Notify(string id, string content)
        {
            if (!notifications.Contains(id))
            {
                Console.WriteLine(content);
                notifications.Add(id);
            }
        }

    }
}