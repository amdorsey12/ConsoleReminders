namespace ConsoleReminders
{
    public interface INotifier
    {
        public void Notify(Reminder reminder);
    }
}