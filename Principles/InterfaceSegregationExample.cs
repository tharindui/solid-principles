namespace SolidPrinciplesApp.Principles;

public static class InterfaceSegregationExample
{
    public static void Run()
    {
        Console.WriteLine("\n4) Interface Segregation Principle (ISP)");

        // BAD EXAMPLE: One large interface forces classes to implement
        // methods they do not need.
        IMultiFunctionBad oldPrinter = new OldPrinter();
        oldPrinter.Print();
        oldPrinter.Scan();

        // GOOD EXAMPLE: Small focused interfaces avoid unused members.
        IPrinter printer = new SimplePrinter();
        printer.Print();

        IScanner scanner = new DocumentScanner();
        scanner.Scan();

        IMultiFunctionDevice modernDevice = new ModernPrinterScanner();
        modernDevice.Print();
        modernDevice.Scan();
    }

    private interface IMultiFunctionBad
    {
        void Print();
        void Scan();
        void Fax();
    }

    private sealed class OldPrinter : IMultiFunctionBad
    {
        public void Print() => Console.WriteLine("[BAD/ISP] Old printer prints");

        // Forced implementation that makes no sense.
        public void Scan() => Console.WriteLine("[BAD/ISP] Scan not supported");

        // Forced implementation that makes no sense.
        public void Fax() => Console.WriteLine("[BAD/ISP] Fax not supported");
    }

    private interface IPrinter
    {
        void Print();
    }

    private interface IScanner
    {
        void Scan();
    }

    private interface IMultiFunctionDevice : IPrinter, IScanner
    {
    }

    private sealed class SimplePrinter : IPrinter
    {
        public void Print() => Console.WriteLine("[GOOD/ISP] Simple printer prints");
    }

    private sealed class DocumentScanner : IScanner
    {
        public void Scan() => Console.WriteLine("[GOOD/ISP] Scanner scans");
    }

    private sealed class ModernPrinterScanner : IMultiFunctionDevice
    {
        public void Print() => Console.WriteLine("[GOOD/ISP] Modern device prints");
        public void Scan() => Console.WriteLine("[GOOD/ISP] Modern device scans");
    }
}
