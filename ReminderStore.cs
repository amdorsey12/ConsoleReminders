using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiteDB;

namespace ConsoleReminders
{
    public class ReminderStore 
    {

        private LiteDatabase db { get; set; }
        private ILiteCollection<Reminder> remindersCollection { get; set; }
        
        public ReminderStore()
        {
            db = new LiteDatabase(@"Reminders.db");
            remindersCollection = db.GetCollection<Reminder>("reminders");
        }

        public void Store (params Reminder[] reminders)
            => Store((IEnumerable<Reminder>) reminders);
        
        public void Store (IEnumerable<Reminder> reminders)
        {
            foreach (Reminder reminder in reminders)
            {
                remindersCollection.Insert(reminder);
            }
        }

        public List<Reminder> Get()
        {
            return remindersCollection.FindAll().ToList();
        }
        
        public void RemoveAll()
        {
            remindersCollection.DeleteAll();
        }

        public void Dispose()
        {
            db.Dispose();
        }

    }
}