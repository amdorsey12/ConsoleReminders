using System;

namespace ConsoleReminders
{
    public class Reminder 
    {
        public LiteDB.ObjectId Id {get; set;}
        public string Content {get;set;}
        public DateTime RemindTime {get;set;}
        public bool IsDone {get; set;}
    }
}