using System;
using LiteDB;
namespace Amdorsey12.Reminders
{
    public class Reminder : IReminder
    {
        [LiteDB.BsonId]
        public string Id {get; set;}
        public string Content {get;set;}
        public bool IsDone {get; set;}
        public DateTime RemindTime {get;set;}
    }
}