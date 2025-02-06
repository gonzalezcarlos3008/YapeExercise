# Yape API - Hexagonal Architecture

## 🚀 Overview

This project implements a **.NET 8 API** and a **WCF Service** following the **Hexagonal Architecture (Ports and Adapters)** design pattern. The system is designed to manage customer data, validate information through external services, and maintain a clean separation between business logic and infrastructure.

### 🗂️ Project Structure

```
YapeExercise
├── Yape.API
│   ├── Controllers
│   ├── Middleware
│   ├── Properties
│   ├── appsettings.json
│   └── Program.cs
├── Yape.API.Application
├── Yape.API.Domain
├── Yape.API.Infrastructure
├── Yape.API.Tests
├── Yape.BD
│   ├── YapeDB.bak
│   └── YapeDB.sql
└── Yape.WCF
    ├── Yape.Application
    ├── IPersonService.cs
    ├── PersonService.svc
    ├── PersonService.svc.cs
    └── Web.config
```

## ⚡ Features

- **WCF Service (.NET Framework 4.8):** Exposes a SOAP service to retrieve persons by phone number.
- **REST API (.NET 8):** Allows creating new customers with validation against the WCF service.
- **Hexagonal Architecture:** Clear separation of concerns with Ports and Adapters.
- **Entity Framework Core:** For database operations.
- **Logging & Exception Handling:** Built-in middleware for error management.

---

## ⚙️ Setup Instructions

### 1️⃣ Prerequisites

- [.NET SDK 8](https://dotnet.microsoft.com/en-us/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- Visual Studio 2022 (with .NET Desktop Development workload)

### 2️⃣ Clone the Repository

```bash
git clone https://github.com/your-username/YapeExercise.git
cd YapeExercise
```

### 3️⃣ Restore the Database

You can restore the database using the provided `.bak` file or the `.sql` script:

#### Option 1: Restore from `.bak`
1. Open SQL Server Management Studio (SSMS).
2. Right-click on `Databases` > `Restore Database`.
3. Choose **Device** and browse to `Yape.BD/YapeDB.bak`.
4. Follow the restore wizard and click OK.

#### Option 2: Execute `.sql` Script
1. Open SSMS.
2. Open `Yape.BD/YapeDB.sql`.
3. Execute the script to create the database and tables.

### 4️⃣ Configure the Database Connection String

#### For the API:

Edit `Yape.API/appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DB_CONNECTION_STRING": "Server=localhost;Database=YapeDB;Trusted_Connection=True;"
  }
}
```

#### For the WCF Service:

Edit `Yape.WCF/Web.config`:

```xml
<connectionStrings>
  <add name="YapeDB" connectionString="Server=localhost;Database=YapeDB;Trusted_Connection=True;" providerName="System.Data.SqlClient" />
</connectionStrings>
```

### 5️⃣ Apply Database Migrations (Optional)

If needed:

```bash
dotnet ef database update --project Yape.API.Infrastructure
```

### 6️⃣ Run the Application

#### Start the WCF Service:
1. Right-click on `Yape.WCF/PersonService.svc`.
2. Select **View in Browser** or run the project from Visual Studio.
3. The WCF service must be loaded at `http://localhost:52329`.

#### Start the API:

```bash
dotnet run --project Yape.API
```

The API will be available at `https://localhost:7076`.

---

## 🛠️ API Endpoints

### 📥 Create Customer

- **URL:** `POST /customer`
- **Request Body:**

```json
{
  "Name": "John",
  "LastName": "Doe",
  "CellPhoneNumber": 1234567890,
  "DocumentType": "ID",
  "DocumentNumber": "A1234567",
  "ReasonOfUse": "Personal Use"
}
```

- **Response:**

```json
{
  "Id": "b1f85a1d-5674-4a1a-bb3b-2c8f8c8f8e8f"
}
```

---

## 🧪 Running Tests

```bash
dotnet test Yape.API.Tests
```

- Unit tests are located in the `Yape.API.Tests` folder.
- Uses **Moq** and **xUnit** for testing.

---

## 💡 Troubleshooting

- **Database Connection Issues:** Ensure SQL Server is running and accessible.
- **Unique Constraint Violations:** The API handles these gracefully with descriptive error messages.
- **Service Connectivity:** Make sure the WCF service is running before starting the API.

---

## 🤝 Contributing

1. Fork the repository
2. Create a new branch (`git checkout -b feature/awesome-feature`)
3. Commit your changes (`git commit -m 'Add new feature'`)
4. Push to the branch (`git push origin feature/awesome-feature`)
5. Open a pull request

---

## 📜 License

This project is licensed under the [MIT License](LICENSE).

---

## 📧 Contact

For any inquiries, feel free to reach out at [gonzalezcarlos3008@hotmail.com](mailto:gonzalezcarlos3008@hotmail.com).

