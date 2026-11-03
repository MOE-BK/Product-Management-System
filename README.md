# 🛒 Product Management System

A full-featured **Product Management System** built with **ASP.NET Core MVC** and **Entity Framework Core**.

The application provides a complete solution for managing products and categories, including CRUD operations, image uploads, searching, filtering, sorting, pagination, validation, and database management.

---

## 📌 Project Overview

**Product Management System** is a web-based application designed to simplify product and category management.

The project demonstrates practical implementation of **ASP.NET Core MVC**, **Entity Framework Core**, **SQL Server**, **ViewModels**, **Model Validation**, **File Uploads**, and modern web UI development.

---

## ✨ Features

### 📦 Product Management

- Create products
- View product details
- Edit products
- Delete products
- Upload product images
- Display product images
- Assign products to categories

### 🗂️ Category Management

- Create categories
- View categories
- Edit categories
- Delete categories
- Manage product-category relationships

### 🔎 Search & Filtering

- Search products by name
- Filter products by category
- Combine search and category filtering

### ↕️ Sorting

- Sort products by name
- Sort products by price
- Sort products in ascending or descending order

### 📄 Pagination

- Paginated product listing
- Configurable page size
- Previous / Next navigation

### ✅ Validation

- Server-side validation
- Data Annotations
- Custom file validation
- Image file type validation
- Maximum file size validation
- ModelState validation

### 🖼️ Image Upload

- Upload product images
- Store images inside `wwwroot/images`
- Generate unique image names
- Prevent filename conflicts

---

## 🛠️ Technologies

| Technology | Usage |
|---|---|
| **C#** | Programming Language |
| **ASP.NET Core MVC** | Web Framework |
| **Entity Framework Core** | ORM |
| **SQL Server** | Database |
| **LINQ** | Data Querying |
| **Razor Views** | UI |
| **Bootstrap** | Responsive Design |
| **HTML5** | Page Structure |
| **CSS3** | Styling |
| **JavaScript** | Client-side functionality |
| **Git & GitHub** | Version Control |

---

## 🏗️ Architecture

The project follows the **MVC (Model-View-Controller)** architecture.

```text
ProductManagementSystem
│
├── Controllers
│   ├── ProductsController
│   └── CategoriesController
│
├── Models
│   ├── Product
│   └── Category
│
├── ViewModels
│   └── ProductViewModel
│
├── Data
│   └── AppDbContext
│
├── Views
│   ├── Products
│   ├── Categories
│   └── Shared
│
├── wwwroot
│   ├── css
│   ├── js
│   └── images
│
├── Program.cs
├── appsettings.json
└── ProductManagementSystem.slnx
```

---

## 🗄️ Database

The application uses **SQL Server** with **Entity Framework Core**.

Main entities:

```text
Category
   │
   │ 1
   │
   │ *
Product
```

A category can contain multiple products, while each product belongs to a category.

---

## 🔄 Application Flow

```text
User
  ↓
Razor View
  ↓
Controller
  ↓
ViewModel / Model
  ↓
Entity Framework Core
  ↓
SQL Server
```

For example, when creating a product:

```text
Create Form
     ↓
POST Request
     ↓
ProductsController
     ↓
Model Validation
     ↓
Image Upload
     ↓
EF Core
     ↓
SQL Server
```

---

## 📸 Screenshots

### 🏠 Products Page

Add your screenshot here:

```md
![Products Page](screenshots/products.png)
```

### ➕ Create Product

```md
![Create Product](screenshots/create-product.png)
```

### ✏️ Edit Product

```md
![Edit Product](screenshots/edit-product.png)
```

### 🗂️ Categories

```md
![Categories](screenshots/categories.png)
```

> Create a `screenshots` folder in the repository and place your project screenshots inside it.

---

## 🚀 Getting Started

### 1. Clone the Repository

```bash
git clone https://github.com/MOE-BK/Product-Management-System.git
```

### 2. Navigate to the Project

```bash
cd Product-Management-System
```

### 3. Restore Dependencies

```bash
dotnet restore
```

### 4. Configure the Database

Update the connection string inside:

```text
appsettings.json
```

Example:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER;Database=ProductManagement;Trusted_Connection=True;TrustServerCertificate=True"
}
```

### 5. Apply Database Migrations

```bash
dotnet ef database update
```

### 6. Run the Application

```bash
dotnet run
```

Then open the URL displayed by ASP.NET Core.

---

## 🧪 Development

To create a new migration:

```bash
dotnet ef migrations add InitialCreate
```

To update the database:

```bash
dotnet ef database update
```

---

## 🔐 Security Notes

- Database connection strings should not contain sensitive production credentials.
- Do not commit passwords, API keys, or secrets to GitHub.
- Use `appsettings.Development.json` or environment variables for sensitive configuration.

---

## 📚 What I Practiced

This project was built to practice real-world **ASP.NET Core MVC** development, including:

- MVC Architecture
- Controllers & Actions
- Razor Views
- Models & ViewModels
- Model Binding
- ModelState
- Data Annotations
- Custom Validation
- Entity Framework Core
- DbContext & DbSet
- SQL Server
- Migrations
- Relationships
- Foreign Keys
- Navigation Properties
- LINQ
- Search
- Filtering
- Sorting
- Pagination
- File Upload
- Dependency Injection
- Bootstrap
- Git & GitHub

---

## 🎯 Future Improvements

Possible future enhancements:

- Authentication & Authorization
- Admin Dashboard
- Role Management
- Product Stock Management
- Product Reviews
- Advanced Filtering
- RESTful Web API
- AJAX-based operations
- Unit Testing
- Docker Support
- Cloud Deployment

---

## 👨‍💻 Author

### MOE-BK

GitHub:

https://github.com/MOE-BK

---

## ⭐ Support

If you find this project useful, consider giving the repository a ⭐ on GitHub.

---

## 📄 License

This project is created for educational and portfolio purposes.
