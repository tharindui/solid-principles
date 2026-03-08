namespace SolidPrinciplesApp.Principles;

public static class DependencyInversionExample
{
    public static void Run()
    {
        Console.WriteLine("\n5) Dependency Inversion Principle (DIP)");

        // BAD EXAMPLE: High-level service directly depends on low-level EmailSenderBad.
        var badNotifier = new BadOrderNotifier();
        badNotifier.Notify("Order #1001 has shipped.");

        // GOOD EXAMPLE: High-level service depends on abstraction (INotificationSender).
        // We can inject different implementations without changing business logic.
        var emailNotifier = new OrderNotifier(new EmailSender());
        emailNotifier.Notify("Order #2001 has shipped.");

        var smsNotifier = new OrderNotifier(new SmsSender());
        smsNotifier.Notify("Order #2002 is out for delivery.");
    }

    private sealed class EmailSenderBad
    {
        public void Send(string message) => Console.WriteLine($"[BAD/DIP] Email sent: {message}");
    }

    private sealed class BadOrderNotifier
    {
        private readonly EmailSenderBad _emailSender = new();

        public void Notify(string message) => _emailSender.Send(message);
    }

    private interface INotificationSender
    {
        void Send(string message);
    }

    private sealed class EmailSender : INotificationSender
    {
        public void Send(string message) => Console.WriteLine($"[GOOD/DIP] Email sent: {message}");
    }

    private sealed class SmsSender : INotificationSender
    {
        public void Send(string message) => Console.WriteLine($"[GOOD/DIP] SMS sent: {message}");
    }

    private sealed class OrderNotifier
    {
        private readonly INotificationSender _notificationSender;

        public OrderNotifier(INotificationSender notificationSender)
        {
            _notificationSender = notificationSender;
        }

        public void Notify(string message) => _notificationSender.Send(message);
    }
}
