using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiteDB;

namespace ConsoleReminders
{
    public class ReminderStore : IDisposable
    {
        private LiteDatabase Db { get; set; }
        private ILiteCollection<Reminder> RemindersCollection { get; set; }
        
        public ReminderStore()
        {
            Db = new LiteDatabase(@"Reminders.db");
            RemindersCollection = Db.GetCollection<Reminder>("reminders");
        }

        public void Store (params Reminder[] reminders)
            => Store((IEnumerable<Reminder>) reminders);
        
        public void Store (IEnumerable<Reminder> reminders)
        {
            foreach (Reminder reminder in reminders)
            {
                RemindersCollection.Insert(reminder);
            }
        }

        public List<Reminder> Get()
        {
            return RemindersCollection.FindAll().ToList();
        }
        
        public void RemoveAll()
            => RemindersCollection.DeleteAll();
        
        public void Dispose()
            => Db.Dispose();
    }
}