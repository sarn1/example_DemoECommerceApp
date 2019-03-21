# example_DemoECommerceApp
- https://github.com/PacktPublishing/Building-RESTful-Web-Services-with-DOTNET-Core


- `<scheme name> : <hierarchical part> [? query] [# fragment]`
    - hierarchical part also contains the option query and fragment part
- p.14 - caching can be set in the header
- p.16 - verbs chart with safe vs. idempotent vs. nonidempotent
    - `PUT` - either inserts new or updates if exists
    - `OPTION` - gets a list of all allowed operations for a resource
    - `HEAD` - returns only response header with no responst body
- p.17 - `OPTION` response example would look like this `200 OK ALLOW: HEAD, GET, PUT`
- P.18 - `PUT` vs. `POST`
    - `PUT` is indempotent - it can be repeated, and yields the same result every time.  If the resource does not exist, it will create it, otherwise it will update it.    `POST` is nonindemppotent - multiple resources will be created if it is called more than once.  So for `PUT`, the exact URI needs to be specified.  So `PUT http://test.com/authors` will not work.  It will have to be `PUT http://test.com/authors/19` will work.  It will create an author with Id 19 if it doesn't exists and then update else update if author Id 19 exists.  For `POST`, `POST http://test.com/authors` will work and each `POST` call will create a new author Id.  If `POST http://test.com/authors/19` was called, the request won't consider it a new resource, if it doesn't exist.  It will always be treated as an update request,.... so possibly an error if author Id doesn't exist.
- p31 - Create the `DemoECommerceApp` is `File > New > Project > ASP.NET Core Web Application > API`
- p46 - Code for returning HTTP 500 error for faild `POST` is `return StatusCode(500);`

---

## For eCommerce App (p.60)
- Installed Microsoft.EntityFrameworkCore.SqlServer and Microsoft.EntityFrameworkCore.Tools
- Created localdb using https://github.com/PacktPublishing/Building-RESTful-Web-Services-with-DOTNET-Core/blob/master/Chapter03/DB/FlixOneStore.sql
- then ran `Scaffold-DbContext "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=FlixOneStore;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Tables Customers` in the package manager console.
    - p.100 - For all database tables do `Scaffold-DbContext "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=FlixOneStore;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Force`
- https://github.com/sarn1/example_DemoECommerceApp/blob/master/readme_assets/db.png
- That way when you create a new controller, you can select in the dropdown box a model class and data context class, and it will build out the the REST controller for you and all using the FlixStore DB Context.
- Made changes in Startup.cs to configure the app to work with my database connection.
- Installed additional NuGets to get this to work.  IdentityServer4, IdentityServer4.AcessTokenValidation, IdentityServer4.AspNetIdentity
- https://localhost:44395/api/Customers/910d4c2f-b394-4578-8d9c-7ca3fd3266e2
- Browse locally using the HTML file in the solution.


## Async & Await
One thing that always helped see the difference when I first came to learn about was this scenario.
```csharp


Public async Task StartTaskAsync()
{
    Console.WriteLine("First Step");

    Task awaitableTask = OtherMethodAsync();

    Console.Writeline("Second step");
    await awaitableTask;
    Console.Writeline("4th Step");
}

Public async Task OtherMethodAsync()
{
    await Task.Delay(2000);
    Console.WriteLine("Step 3");
}
```
If you run this it will print out the steps in order. Because the await in the OtherMethodAsyncAsync passes control back to the calling method until whatever it is await has finished.

In the calling method StartTaskAsync it doesn't await immediately so it can continue to run some code until it waits on the task returned by the OtherMethodAsyncAsync.

If you were to make this synchronous. Ie remove all the asyncs and awaits and just return void rather than task. You would see that step 3 prints before Step 2

## Middleware (Chapter 5)
- p.132 - chart of what a middlware is
- In `Startup.cs` the `.UseMVC` tells the system to add MVC to the piplines which is an extension of `Microsoft.AspNetCore.Builder.IApplicationBuilder` which has 4 important `IApplicationBuilder` methods.
- These middleware method can be shortcircuited (a request that is nothing but ending a request) or pass the request to the next delegate.
- Nuget: Microsoft.ApplicationInsights.AspNetCore and Swashbuckle.ASPNETCore for Swagger support.
- p.147 - In Package Manager Console, navigate to the projects folder (`cd chapter5`) and then run `dotnet run`
