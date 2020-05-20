namespace Dorsey.Reminders
{
    public interface INotifier
    {
        public void Notify(IReminder reminder);
    }
}