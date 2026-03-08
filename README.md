# SOLID Principles in .NET (C#)

This project is a small **.NET console app** designed to help you understand all five SOLID principles with **bad vs good examples**, plus comments in code for each example.

## What is SOLID?

SOLID is a set of 5 object-oriented design principles that make software:
- Easier to understand
- Easier to extend
- Easier to test
- Less fragile when requirements change

The 5 principles are:
1. **S** - Single Responsibility Principle (SRP)
2. **O** - Open/Closed Principle (OCP)
3. **L** - Liskov Substitution Principle (LSP)
4. **I** - Interface Segregation Principle (ISP)
5. **D** - Dependency Inversion Principle (DIP)

---

## Project structure

- `Program.cs`: runs all principle demos in sequence.
- `Principles/SingleResponsibilityExample.cs`
- `Principles/OpenClosedExample.cs`
- `Principles/LiskovSubstitutionExample.cs`
- `Principles/InterfaceSegregationExample.cs`
- `Principles/DependencyInversionExample.cs`

Each file contains:
- A **bad example** (violation)
- A **good example** (SOLID-compliant)
- Inline comments explaining why.

---

## 1) Single Responsibility Principle (SRP)

**Definition:** A class should have only one reason to change.

### Bad idea
One class performs multiple tasks (e.g., calculation + database save + printing).

### Good idea
Split responsibilities into focused classes:
- Calculator
- Repository
- Printer

### Benefit
When printing logic changes, you update only printer class—not business calculation logic.

---

## 2) Open/Closed Principle (OCP)

**Definition:** Software entities should be open for extension, closed for modification.

### Bad idea
A processor uses big `if/else` or `switch` statements for every new case.

### Good idea
Use interfaces/abstractions and add new classes for new behavior.
Example: Add `BankTransferPayment` without changing existing `PaymentProcessor`.

### Benefit
Less risk of breaking old logic while adding new features.

---

## 3) Liskov Substitution Principle (LSP)

**Definition:** Subtypes must be replaceable for their base types without breaking behavior.

### Bad idea
A subtype cannot honor parent contract (e.g., `Ostrich` forced to `Fly()`).

### Good idea
Model behavior using correct abstractions (`IFlyingBird`, `IWalkingBird`).

### Benefit
Polymorphism becomes safe and predictable.

---

## 4) Interface Segregation Principle (ISP)

**Definition:** Clients should not be forced to depend on methods they do not use.

### Bad idea
A "fat" interface has too many methods (`Print`, `Scan`, `Fax`) and some implementations cannot support all.

### Good idea
Split into smaller interfaces (`IPrinter`, `IScanner`) and combine only where needed.

### Benefit
Cleaner contracts and fewer dummy/empty implementations.

---

## 5) Dependency Inversion Principle (DIP)

**Definition:** High-level modules should depend on abstractions, not concrete details.

### Bad idea
Business logic directly creates and uses low-level service classes.

### Good idea
Depend on interfaces (`INotificationSender`) and inject concrete implementations (`EmailSender`, `SmsSender`).

### Benefit
Flexible architecture, easier testing (you can mock interfaces), and easier to replace infrastructure.

---

## How to run

1. Install .NET SDK (recommended .NET 8 or later).
2. In project folder, run:

```bash
dotnet restore
dotnet run
```

You will see console output for each SOLID principle showing bad and good examples.

---

## How to learn effectively from this repo

1. Run once and observe output.
2. Open each file in `Principles/` and read comments.
3. Try adding your own example class per principle.
4. Refactor one bad example into a better design.
5. Practice with real-world mini-features:
   - Add a new payment method (OCP)
   - Add a push notification sender (DIP)
   - Add a new device type (ISP)

---

## Common interview-style quick answers

- **What does SRP solve?** Avoids “god classes”.
- **What does OCP solve?** Enables extension without editing old stable code.
- **What does LSP solve?** Prevents broken inheritance contracts.
- **What does ISP solve?** Prevents bloated interfaces.
- **What does DIP solve?** Decouples business logic from infrastructure details.

---

## Final note

SOLID is not about creating many classes blindly. It is about writing code that is:
- Maintainable
- Extensible
- Testable
- Understandable for teams

Use these principles with practical judgment.
