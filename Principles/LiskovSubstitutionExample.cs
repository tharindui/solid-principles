namespace SolidPrinciplesApp.Principles;

public static class LiskovSubstitutionExample
{
    public static void Run()
    {
        Console.WriteLine("\n3) Liskov Substitution Principle (LSP)");

        // BAD EXAMPLE: Ostrich inherits Bird but cannot fly.
        // Substituting Ostrich where Bird is expected breaks behavior.
        Bird badBird = new Sparrow();
        badBird.Fly();

        badBird = new Ostrich();
        badBird.Fly();

        // GOOD EXAMPLE: Separate abstractions for flying and non-flying birds.
        // Substitution always respects contract expectations.
        IFlyingBird flyingBird = new Eagle();
        flyingBird.Fly();

        IWalkingBird walkingBird = new Penguin();
        walkingBird.Walk();
    }

    private class Bird
    {
        public virtual void Fly() => Console.WriteLine("[BAD/LSP] Bird is flying");
    }

    private sealed class Sparrow : Bird
    {
        public override void Fly() => Console.WriteLine("[BAD/LSP] Sparrow is flying");
    }

    private sealed class Ostrich : Bird
    {
        public override void Fly() => Console.WriteLine("[BAD/LSP] ERROR: Ostrich cannot fly but is forced by base class");
    }

    private interface IFlyingBird
    {
        void Fly();
    }

    private interface IWalkingBird
    {
        void Walk();
    }

    private sealed class Eagle : IFlyingBird
    {
        public void Fly() => Console.WriteLine("[GOOD/LSP] Eagle is flying");
    }

    private sealed class Penguin : IWalkingBird
    {
        public void Walk() => Console.WriteLine("[GOOD/LSP] Penguin is walking");
    }
}
