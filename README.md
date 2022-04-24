# Shop
Shop.API Asp.net Core 3.1
Shop.UI Asp.net Core 6.0

Database ConnectionStrings
Shop.API/appsettings.json

"ConnectionStrings": {
    "Local": "server=<YourDbServerName>;Database=ShopDb;integrated security = true;"
  },

Shop.Apı Set as Startup Project
Add-Migration InitialCreate -OutputDir Persistance/Migrations
database-update

Seed Data user & password:
usernama: "kullanici"
password: "kullanici"
