# ConsoleReminders

A simple reminder library with a small sample program implementation using the console and LiteDB.

Usage:

-Clone or download repo and place it in your project.
-Add reference to Dorsey.Reminders
-Create a notifier and reminder store that suit your needs and obey INotifier and IReminderStore
-Instantiate an instance of ReminderManager, and pass it the notifier and store.
-Start the manager, pass it reminders, and stop it according to your desired program logic.

Sample
```cs
//Starts and then writes a reminder every 10 seconds to the console. Terminates after 35 seconds.
using (var manager = new ReminderManager(new ConsoleNotifier(), new LiteDbStore()))
{
    manager.Start();
    manager.Remind
    ( 
        new Reminder { Content = "First", RemindTime = DateTime.Now.AddSeconds(10), IsDone = false },
        new Reminder { Content = "Second", RemindTime = DateTime.Now.AddSeconds(20), IsDone = false },
        new Reminder { Content = "Third", RemindTime = DateTime.Now.AddSeconds(30), IsDone = false }
    );
    await Task.Delay(35000);
    manager.Stop();
}
    
```
