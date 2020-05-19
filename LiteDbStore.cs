using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiteDB;

namespace Amdorsey12.Reminders
{
    public class LiteDbStore : IReminderStore
    {
        private LiteDatabase Db { get; set; }
        private ILiteCollection<IReminder> RemindersCollection { get; set; }
        
        public LiteDbStore()
        {
            Db = new LiteDatabase(@"Reminders.db");
            RemindersCollection = Db.GetCollection<IReminder>("reminders");
        }

        public void Store (params IReminder[] reminders)
            => Store((IEnumerable<IReminder>) reminders);
        
        public void Store (IEnumerable<IReminder> reminders)
        {
            foreach (IReminder reminder in reminders)
            {
                RemindersCollection.Insert(reminder);
            }
        }
        
        public void RemoveAll()
            => RemindersCollection.DeleteAll();
            
        public IEnumerable<IReminder> Get()
        {
            return (IEnumerable<IReminder>) RemindersCollection.Find(x => x.IsDone != true).ToList();
        }

        public void Delete(params IReminder[] Reminders)
            => Delete((IEnumerable<IReminder>) Reminders);

        public void Delete(IEnumerable<IReminder> Reminders)
        {
            foreach (Reminder reminder in Reminders)
            {
                RemindersCollection.Delete(reminder.Id);
            }
        }

        public void MarkDone(params IReminder[] Reminders)
            => MarkDone((IEnumerable<IReminder>) Reminders);

        public void MarkDone(IEnumerable<IReminder> Reminders)
        {
            foreach (IReminder reminder in Reminders)
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