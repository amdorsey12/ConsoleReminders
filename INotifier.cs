namespace Amdorsey12.Reminders
{
    public interface INotifier
    {
        public void Notify(IReminder reminder);
    }
}