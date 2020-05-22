using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiteDB;

namespace Dorsey.Reminders
{
    public class LiteDbStore : IReminderStore
    {
        private LiteDatabase Database { get; set; }
        private ILiteCollection<Reminder> Collection { get; set; }
        
        public LiteDbStore()
        {
            Database = new LiteDatabase(@"Reminders.db");
            Collection = Database.GetCollection<Reminder>("reminders");
        }

        public void Store(IEnumerable<IReminder> reminders)
        {
            foreach (Reminder reminder in reminders)
            {
                Collection.Insert(reminder);
            }
        }
        
        public void RemoveAll()
            => Collection.DeleteAll();
            
        public IEnumerable<IReminder> Get()
            => Collection.Find(x => x.IsDone != true).ToList();
        
        public void Delete(IEnumerable<IReminder> Reminders)
        {
            foreach (Reminder reminder in Reminders)
            {
                Collection.Delete(reminder.Id);
            }
        }

        public void MarkDone(IEnumerable<IReminder> Reminders)
        {
            foreach (Reminder reminder in Reminders)
            {
                var reminderOut = Collection.Find(x => x.Id == reminder.Id).FirstOrDefault();
                reminderOut.IsDone = true;
                Collection.Insert(reminderOut);
            }
        }

        public void Dispose()
            => Database.Dispose();
    }
}