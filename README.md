### InfoCenter API
**API built with ASP.NET Controller-based APIs**

## Adding database
The app will create the SQLite database on the first run if it does not already exist.

# Creating database manually
In InfoCenter.Api folder run migration then update to create the database.
```
dotnet ef migrations add InitialCreate --output-dir Data\Migrations
dotnet ef database update
```

## Building and Running the API
```
dotnet build
dotnet run
```