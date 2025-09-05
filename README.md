# 🎓 EduPortal — Освітній портал курсів

Це простий, але повноцінний C#/.NET-проєкт навчальної платформи з курсами, викладачами та студентами.  
Реалізований на архітектурі **ASP.NET MVC** з використанням **Entity Framework Core** для роботи з базою даних.  

---

## 🔧 Технології

- .NET 9  
- ASP.NET Core MVC  
- Entity Framework Core  
- SQLite  
- C#  

---

## 📁 Структура проєкту

- `Entities/` — сутності:  
  - `Course`  
  - `Teacher`  
  - `Student`  
  - `Enrollment`  
  - `BaseEntityForTeacherAndStudent`  

- `DataBase/` — робота з БД:  
  - `AppDbContext`  
  - `Configurations/` — Fluent API-конфігурації для кожної сутності  

- `Services/` — бізнес-логіка:  
  - `StudentService`  
  - `TeacherService`  
  - `CourseService`  
  - `EnrollmentService`  

- `Controllers/` — MVC-контролери для кожної сутності  
  (`StudentsController`, `TeachersController`, `CoursesController`, `EnrollmentsController`)  

- `Views/` — Razor-сторінки (`.cshtml`) для відображення списків та CRUD-операцій  

---

## 🧠 Функціонал

### 📚 Курси (`CourseService`)
- Створення курсу  
- Редагування курсу  
- Видалення курсу  
- Перегляд списку курсів  
- Фільтрація за категоріями  

### 👨‍🏫 Викладачі (`TeacherService`)
- Створення викладача  
- Перегляд усіх викладачів  
- Перегляд курсів конкретного викладача  

### 👨‍🎓 Студенти (`StudentService`)
- Реєстрація студента  
- Перегляд студентів  
- Перегляд курсів, на які записаний студент  

### 📝 Запис на курс (`EnrollmentService`)
- Запис студента на курс  
- Відписка від курсу  
- Перегляд усіх записів  

---

## 🚀 Як запустити

### 1. 📦 Завантажити ZIP-проєкт
- Натисни кнопку `Code` → `Download ZIP` (або склонуй репозиторій: `git clone ...`)  
- Розпакуй архів у зручну папку  

### 2. 🧠 Відкрити в IDE
- Відкрий проєкт у [Rider](https://www.jetbrains.com/rider/), [Visual Studio](https://visualstudio.microsoft.com/), або [Visual Studio Code](https://code.visualstudio.com/) із встановленим C#-плагіном  
- Переконайся, що встановлена **.NET SDK 9** (перевір через `dotnet --version`)  

### 3. 🗄️ Налаштувати базу даних
- У `AppDbContext` використовується SQLite (`Data source=EduPortal.db`)  
- При першому запуску база створюється автоматично (`Database.EnsureCreated()`)  

### 4. ▶️ Запустити проєкт
- Запусти через `dotnet run` або IDE  
- Відкрий у браузері `https://localhost:5001` (або порт, який призначить система)  

---

## 💬 Коментарі

- Контролери **не працюють напряму з DbContext** — доступ до даних винесений у сервіси.  
- У `Configurations/` прописані всі Fluent API-налаштування (`HasKey`, `Property`, `HasData`, зв’язки).  
- У Views реалізовані CRUD-операції **в одній сторінці списку** без окремих `Details` чи `Index`.  
- Код написаний **зрозуміло та послідовно**, дотримані базові принципи архітектури MVC.  
