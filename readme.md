# KAppraisal API

KAppraisal adalah **RESTful API** berbasis **ASP.NET Core (.NET 8)** yang dibuat sebagai project pembelajaran & portofolio. Aplikasi ini menyediakan manajemen **Project** dan **Todo** dengan relasi **one-to-many** (1 Project memiliki banyak Todo).

---

## Tech Stack

- **.NET 8 / ASP.NET Core Web API**
- **Entity Framework Core**
- **MySQL / MariaDB**
- **Swagger (OpenAPI)**
- **DataAnnotations Validation**

---

## Fitur Utama

### Project

- Create project
- Get all projects
- Get project by ID
- Update project (PATCH)
- Delete project

### Todo

- Todo terikat ke Project
- Get todos by project
- Create todo for project
- Update todo
- Delete todo
- Enum status (`Todo`, `Progress`, `Done`, `Success`)

---

## Setup & Installation

### Clone Repository

```bash
git clone https://github.com/baraziz/k-appraisal-test
cd k-appraisal-test
```

---

### Konfigurasi Database

Edit file `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "server=localhost;database=kappraisal;user=root;password=yourpassword"
  }
}
```

---

### 3️⃣ Jalankan Migration

```bash
dotnet ef database update
```

---

### 4️⃣ Jalankan Aplikasi

```bash
dotnet run
```

Akses Swagger di:

```
http://localhost:5131/swagger/index.html
```

---

## 📘 API Documentation (Swagger)

Swagger digunakan untuk dokumentasi API dan testing endpoint.

Contoh endpoint:

### Project

```
GET    /api/projects
POST   /api/projects
GET    /api/projects/{id}
PATCH  /api/projects/{id}
DELETE /api/projects/{id}
```

### Todo

```
GET    /projects/{projectId}/todos
POST   /projects/{projectId}/todos
PATCH  /todos/{id}
DELETE /todos/{id}
```

---

## 👨‍💻 Author

**KAppraisal** dibuat sebagai project pembelajaran backend .NET.

---

## 📄 License

MIT License
