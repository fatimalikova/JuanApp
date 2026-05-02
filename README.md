# JuanApp

JuanApp is a full-featured e-commerce web application built with **ASP.NET Core MVC** (.NET 9). It includes a customer-facing storefront and a dedicated admin panel for managing products, blogs, sliders, and users.

## Features

### Customer Storefront
- **Home** – Landing page with sliders, featured products, and services
- **Shop** – Browse and filter products by color and size
- **Product Details** – View product images, colors, sizes, pricing, and discounts
- **Shopping Basket** – Add/remove items, manage quantities (session & database backed)
- **Blog** – Read blog posts and related articles
- **Account** – Register, login, and manage your profile with ASP.NET Identity

### Admin Panel (`/manage`)
- **Dashboard** – Overview of store activity
- **Products** – Create, edit, delete products with image uploads (main image + gallery)
- **Blog** – Manage blog posts and blog relations
- **Sliders** – Manage homepage slider content

## Tech Stack

| Layer | Technology |
|---|---|
| Framework | ASP.NET Core MVC (.NET 9) |
| ORM | Entity Framework Core 9 |
| Database | SQL Server |
| Authentication | ASP.NET Core Identity |
| Frontend | Razor Views, Bootstrap |
| Session | ASP.NET Core Session |

## Project Structure

```
JuanApp/
├── Areas/
│   └── Manage/               # Admin area (Controllers, Views, ViewModels)
├── Attributes/               # Custom validation attributes (file type, file size)
├── Controllers/              # Storefront controllers (Home, Shop, Product, Blog, Basket, Account)
├── CustomError/              # Custom Identity error messages
├── Data/                     # DbContext, EF configurations, migrations
├── Models/                   # Domain models (Product, Blog, Slider, AppUser, etc.)
├── Services/                 # Application services (LayoutService, BasketService)
├── ViewModels/               # View-specific models
├── Views/                    # Razor views for storefront
├── wwwroot/                  # Static assets (CSS, JS, images)
├── appsettings.json
└── Program.cs
```

## Getting Started

### Prerequisites
- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- SQL Server (local or remote)

### Setup

1. **Clone the repository**
   ```bash
   git clone https://github.com/fatimalikova/JuanApp.git
   cd JuanApp/JuanApp
   ```

2. **Configure the database connection**

   Add your SQL Server connection string to `appsettings.json` (or `appsettings.Development.json`):
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=YOUR_SERVER;Database=JuanAppDb;Trusted_Connection=True;TrustServerCertificate=True;"
     }
   }
   ```

3. **Apply migrations**
   ```bash
   dotnet ef database update
   ```

4. **Run the application**
   ```bash
   dotnet run
   ```
   The app will be available at `https://localhost:5001` (or the port shown in the console).

## Password Policy

ASP.NET Identity is configured with the following requirements:
- Minimum 6 characters
- At least one uppercase letter
- At least one lowercase letter
- At least one digit
- At least one non-alphanumeric character
- Account lockout: 3 failed attempts → 15-minute lockout

## Image Upload

Product images are validated for:
- **File types**: JPEG, JPG, PNG, WebP
- **Max file size**: 2 MB per file

## License

This project is for educational purposes.
