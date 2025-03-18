# 🖨️ HCMUT Student Smart Printing Service (SSPS)

A smart printing service designed for students of **Ho Chi Minh City University of Technology (HCMUT)**. This system allows students to conveniently pre-order their printing needs, track their usage history, and manage printing information.

## 📌 Features
- **Student Access**:
  - Pre-order printing tasks online.
  - View and manage personal printing history.
  
- **SPSO (Student Printing Service Officer) Management**:
  - Configure system settings and manage printers.
  - View statistics and performance reports.
  - Access student printing history.

---

## 👨‍💻 Contributors
Developed by a team of Computer Science students from HCMUT:

- **Trịnh Anh Minh** - 2252493
- **Vũ Quỳnh Hương** - 2252286
- **Võ Cao Nhật Minh** - 2252495
- **Vũ Minh Quân** - 2212828
- **Trần Xuân Hảo** - 2252191
- **Trần Quốc Bảo Long** - 2252453

---

## 🛠️ Prerequisites
Ensure you have **Visual Studio 2022** installed (the version with the purple icon).

---

## 🚀 Getting Started
Follow these steps to set up and run the project:

### 1. Open the Project
- Double-click on **`PrintingService.sln`** to open the solution in **Visual Studio 2022**.

### 2. Configure the Database

1. Open the **`appsettings.json`** file and ensure the following connection string is correctly configured:

   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=Printing_ServiceData;Trusted_Connection=True;"
   }
   ```

   **Note:** If you're using an older version of SQL Server, update the `Server` value as required.

2. Ensure you have a **SQL Server** instance running with a database named:

   ```
   Printing_ServiceData
   ```

3. Execute the SQL script in **`SQLFinalData_Trigger.sql`** to set up the necessary tables and triggers.

### 3. Run the Application
If everything is configured correctly, click the **Run** button in Visual Studio to start the web application.

---

## 🔐 Test Accounts
Use the following credentials to log in and test the system:

### Student Account
```json
{
  "ID": "ST0001",
  "Password": "abc"
}
```

*Additional student accounts can be found in the database.*

### SPSO Account
```json
{
  "ID": "SPSO01",
  "Password": "abc"
}
```

---

## 📣 Thank You!
We appreciate you using our web application. Feel free to reach out for support or suggestions!

