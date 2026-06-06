# Modern ASP.NET Core Web API Blueprint

A clean, production-ready implementation of a layered API architecture in .NET using C# primary constructors and enterprise best practices.

## Key Features Demonstrated
* Repository and Service Pattern: Strict separation of concerns keeping database access completely abstracted away from business logic.
* Pure DTO Architecture: Uses clean C# record types to handle incoming and outgoing data shapes, ensuring raw database entities never leak to the public API consumer.
* Client-Side Rate Limiting: Core infrastructure middleware implementing an IP-partitioned client throttling policy.
* Modern Global Exception Handling: Leverages the built-in IExceptionHandler interface to automatically capture system failures, securely log stack traces, and present standardized ProblemDetails responses.
* Structured Logging with Serilog: High-performance file and console request logging configured elegantly out of service extension classes.

## Prerequisites
* .NET SDK (version 8.0 or later)

## How to Run and Test
1. Clone the repository to your local machine.
2. Navigate to the project root directory in your terminal.
3. Run the application using the command line:
   ```bash
   dotnet run