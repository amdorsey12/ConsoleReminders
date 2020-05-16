using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiteDB;

namespace ConsoleReminders
{
    public class LiteDbStore : IReminderStore
    {
        private LiteDatabase Db { get; set; }
        private ILiteCollection<Reminder> RemindersCollection { get; set; }
        
        public LiteDbStore()
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
        
        public void RemoveAll()
            => RemindersCollection.DeleteAll();
            
        public IEnumerable<Reminder> Get()
        {
            return (IEnumerable<Reminder>) RemindersCollection.Find(x => x.IsDone != true).ToList();
        }

        public void Delete(params Reminder[] Reminders)
            => Delete((IEnumerable<Reminder>) Reminders);

        public void Delete(IEnumerable<Reminder> Reminders)
        {
            foreach (Reminder reminder in Reminders)
            {
                RemindersCollection.Delete(reminder.Id);
            }
        }

        public void MarkDone(params Reminder[] Reminders)
            => MarkDone((IEnumerable<Reminder>) Reminders);

        public void MarkDone(IEnumerable<Reminder> Reminders)
        {
            foreach (Reminder reminder in Reminders)
            {
                var reminderOut = RemindersCollection.Find(x => x.Id == reminder.Id).FirstOrDefault();
                reminderOut.IsDone = true;
                RemindersCollection.Insert(reminderOut);
            }
        }
        public void Dispose()
            => Db.Dispose();
    }
}