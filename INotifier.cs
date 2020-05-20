namespace Dorsey.Reminders
{
    public interface INotifier
    {
        void Notify(IReminder reminder);
    }
}