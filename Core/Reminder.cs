using System;
using LiteDB;
namespace Dorsey.Reminders
{
    public class Reminder : IReminder
    {
        [LiteDB.BsonId]
        public string Id { get; private set; } = Guid.NewGuid().ToString();
        public string Content { get; set; }
        public bool IsDone { get; set; }
        public DateTime RemindTime { get; set; }
    }
}