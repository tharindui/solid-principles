namespace SolidPrinciplesApp.Principles;

public static class SingleResponsibilityExample
{
    public static void Run()
    {
        Console.WriteLine("\n1) Single Responsibility Principle (SRP)");

        // BAD EXAMPLE: One class has too many responsibilities.
        // InvoiceManager handles calculation, persistence, and printing.
        var badInvoiceManager = new BadInvoiceManager();
        badInvoiceManager.ProcessInvoice(100m, 0.15m);

        // GOOD EXAMPLE: Split responsibilities into focused classes.
        // Each class has one reason to change.
        var calculator = new InvoiceCalculator();
        var repository = new InvoiceRepository();
        var printer = new InvoicePrinter();

        var total = calculator.CalculateTotal(100m, 0.15m);
        repository.Save(total);
        printer.Print(total);
    }

    private sealed class BadInvoiceManager
    {
        public void ProcessInvoice(decimal amount, decimal taxRate)
        {
            var total = amount + amount * taxRate;
            Console.WriteLine($"[BAD/SRP] Saving invoice total: {total:C}");
            Console.WriteLine($"[BAD/SRP] Printing invoice total: {total:C}");
        }
    }

    private sealed class InvoiceCalculator
    {
        public decimal CalculateTotal(decimal amount, decimal taxRate) => amount + amount * taxRate;
    }

    private sealed class InvoiceRepository
    {
        public void Save(decimal total) => Console.WriteLine($"[GOOD/SRP] Saved invoice total: {total:C}");
    }

    private sealed class InvoicePrinter
    {
        public void Print(decimal total) => Console.WriteLine($"[GOOD/SRP] Printed invoice total: {total:C}");
    }
}
