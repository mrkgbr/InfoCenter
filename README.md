# README
## Adding database
In InfoCenter.Api folder run migration then update to create database.
```
dotnet ef migrations add InitialCreate --output-dir Data\Migrations
dotnet ef database update
```