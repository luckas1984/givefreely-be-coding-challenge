

## Affiliate Program Management System
### Background

Your company runs an affiliate program, where partners (affiliates) can earn commissions by referring customers. You are tasked to create a backend system to manage this program. The system should handle basic operations like linking customers to affiliates and providing a basic commission report.
Requirements

* Affiliate and Customer Management: Create a RESTful API using ASP.NET Core to manage affiliates and customers. Each affiliate and customer has a unique identifier and a name. The API should support the following operations:
        Create a new affiliate
        Create a new customer linked to an affiliate
        List all affiliates
        List all customers of a specific affiliate

* Basic Commission Reporting: Your API should provide an endpoint for affiliates to see a count of their referred customers.

* Persistence: Implement a simple data persistence layer using Entity Framework Core. Use any type of data source you are comfortable with.

* Testing: Write basic unit tests for your business logic to ensure it works as expected.

### Evaluation Criteria

Your solution will be evaluated on the following criteria:

* Functionality: Does the application do what was asked?
* Code Quality: Is the code easy to understand and maintain? Is it following C# and .NET best practices?
* Testing: How well is the code tested? Are edge cases and error conditions considered?

### Requirement
* .NET 6.0
* .NET SDK 6.0 (for development porpouse)
* VS Studio 2022 (IDE)
* The solution is using a SQLite in order to quickly and easily set up and execute tests 

### Usage & Test

In order to run and expose the RestAPI resources you can:
* Command: dotnet run --project AffiliationAPI/AffiliationAPI.csproj
* Test API resources (Swagger): https://localhost:7256/swagger/index.html