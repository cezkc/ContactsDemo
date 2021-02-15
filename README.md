# ContactsDemo
- Contacts List with basic CRUD operations.

### Initial Setup and Testing
- Load solution dependencies 
- Load client-side libraries on ContactsDemoWebApp (libman)
- Set Solution to startup projects ContactsWebAPI and ContactsDemoWebApp, they have to be executing at the same time, because the API is called by the WebApplication
- The application can be tested by API calls on Swagger or by presentation layer

### Technologies and features:
- .NET Core 3.1 restful API
- Swagger used on API documentation
- Razor presentation layer made with Razor scaffold 
- Automapper for mapping Models to ViewModels and vice versa
- Clean Architecture implemented to isolate some of the dependencies
- Repository pattern used to isolate database calls and make it more decoupled
- EF Core with in memory database

### To-dos
- Tests
- Better handling of HTTP messages returned by the API on presentation layer
- Better handling of Natural Person and Legal Person on the API endpoints
- Implementation of Services if needed to segregate some of Controller responsability
- Implementation of Bearer Token and Identity for security purposes and permissions management
