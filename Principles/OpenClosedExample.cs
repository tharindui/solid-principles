namespace SolidPrinciplesApp.Principles;

public static class OpenClosedExample
{
    public static void Run()
    {
        Console.WriteLine("\n2) Open/Closed Principle (OCP)");

        // BAD EXAMPLE: PaymentProcessor must be modified every time
        // a new payment type is introduced.
        var badProcessor = new BadPaymentProcessor();
        badProcessor.Pay("CreditCard", 50m);
        badProcessor.Pay("PayPal", 20m);

        // GOOD EXAMPLE: Extend behavior with new strategy classes
        // without changing the processor.
        var goodProcessor = new PaymentProcessor();
        goodProcessor.Pay(new CreditCardPayment(), 50m);
        goodProcessor.Pay(new PayPalPayment(), 20m);
        goodProcessor.Pay(new BankTransferPayment(), 75m);
    }

    private sealed class BadPaymentProcessor
    {
        public void Pay(string paymentType, decimal amount)
        {
            if (paymentType == "CreditCard")
                Console.WriteLine($"[BAD/OCP] Paid {amount:C} by credit card");
            else if (paymentType == "PayPal")
                Console.WriteLine($"[BAD/OCP] Paid {amount:C} by PayPal");
            else
                Console.WriteLine("[BAD/OCP] Unsupported payment type");
        }
    }

    private interface IPaymentMethod
    {
        void Pay(decimal amount);
    }

    private sealed class PaymentProcessor
    {
        public void Pay(IPaymentMethod method, decimal amount) => method.Pay(amount);
    }

    private sealed class CreditCardPayment : IPaymentMethod
    {
        public void Pay(decimal amount) => Console.WriteLine($"[GOOD/OCP] Paid {amount:C} by credit card");
    }

    private sealed class PayPalPayment : IPaymentMethod
    {
        public void Pay(decimal amount) => Console.WriteLine($"[GOOD/OCP] Paid {amount:C} by PayPal");
    }

    private sealed class BankTransferPayment : IPaymentMethod
    {
        public void Pay(decimal amount) => Console.WriteLine($"[GOOD/OCP] Paid {amount:C} by bank transfer");
    }
}
