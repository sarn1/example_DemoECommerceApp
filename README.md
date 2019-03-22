# example_DemoECommerceApp
- https://github.com/PacktPublishing/Building-RESTful-Web-Services-with-DOTNET-Core


# Basic Rest
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


# Ecommerce App
- For eCommerce App (p.60)
-installed Microsoft.EntityFrameworkCore.SqlServer and Microsoft.EntityFrameworkCore.Tools
- created localdb using https://github.com/PacktPublishing/Building-RESTful-Web-Services-with-DOTNET-Core/blob/master/Chapter03/DB/FlixOneStore.sql
- then ran `Scaffold-DbContext "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=FlixOneStore;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Tables Customers` in the package manager console.
- https://github.com/sarn1/example_DemoECommerceApp/blob/master/readme_assets/db.png
- That way when you create a new controller, you can select in the dropdown box a model class and data context class, and it will build out the the REST controller for you and all using the FlixStore DB Context.
- installed McApp.AppCore.IdentityServer4
- (p.73) This is where I stopped following the book.  Code set incomplete.  
---

# Cors
- To enable CORS for all origins, install Microsoft.AspNetCore.Cors
- Then in startup.cs https://github.com/PacktPublishing/Building-RESTful-Web-Services-with-DOTNET-Core/blob/master/Chapter03/DemoECommerceApp/DemoECommerceApp/Startup.cs#L30-L40

# Testing
- FxCop is one fo the most popular tools used in security testing.  Built into VS.
- Postman is one of the most popular tools when testing web service output.  It is a Google Chrome extension.  Another one is Advanced Rest Client.
- RestSharp is a lightweight HTTP client library.