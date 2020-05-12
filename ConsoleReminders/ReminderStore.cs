using System.Collections.Generic;
using System.Linq;
using LiteDB;

namespace ConsoleReminders
{
    public class ReminderStore 
    {
        public void Store (Reminder[] reminders)
        {
            using (var db = new LiteDatabase(@"Reminders.db"))
            {
                var remindersCollection = db.GetCollection<Reminder>("reminders");
                foreach (Reminder reminder in reminders)
                {
                    remindersCollection.Insert(reminder);
                }
            }
        }
        public List<Reminder> Retrieve()
        {
            using (var db = new LiteDatabase(@"Reminders.db"))
            {
                var remindersCollection = db.GetCollection<Reminder>("reminders");
                return remindersCollection.FindAll().ToList();
            }
        }
        
        public void RemoveAll()
        {
            using (var db = new LiteDatabase(@"Reminders.db"))
            {
                var remindersCollection = db.GetCollection<Reminder>("reminders");
                remindersCollection.DeleteAll();
            }
        }
    }
}