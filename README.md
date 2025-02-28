# Grant Me - Project Overview

## 📌 Project Description
Grant Me is a tool designed to help users find **eligible grants** by integrating with the **Open Government API**. The system will eventually pull real-time data from the API to list available grants, replacing the need for manually stored grant data.

## 🚀 Setup & Installation
### **Prerequisites**
- .NET 6 or later installed ([Download Here](https://dotnet.microsoft.com/en-us/download))
- SQLite (for local database storage, if needed)
- Visual Studio or VS Code (Recommended for development)
- Git (for version control)

### **Clone the Repository**
```sh
git clone https://github.com/Dizzyio/GrantMe.git
cd GrantMe
```

### **Setup & Run the Project**
1. **Restore dependencies**
   ```sh
   dotnet restore
   ```
2. **Apply database migrations (if using SQLite)**
   ```sh
   dotnet ef database update
   ```
3. **Run the application**
   ```sh
   dotnet run
   ```
4. The app should be running at:
   - `http://localhost:5064`

## 🛠 Features Implemented
### **1️⃣ Basic CRUD for Grants**
The API currently supports:
- `GET /api/Grants` → Retrieve all grants (currently empty until API integration)
- `POST /api/Grants` → Create a new grant (for manual testing)
- `PUT /api/Grants/{id}` → Update a grant
- `DELETE /api/Grants/{id}` → Delete a grant

**📌 Note:** Since the system will later pull grants from the Open Government API, this CRUD functionality is **temporary** and mainly for testing.

### **2️⃣ Database Setup**
- Uses **SQLite** (can be replaced with other databases later).
- `GrantDbContext.cs` manages database operations.
- Migrations are set up using Entity Framework Core.

## ⏳ Next Steps
- **Integrate Open Government API** to pull real-time grant data.
- **Develop user-side UI (if needed).**
- **Expand eligibility questionnaire functionality.**

## 💻 API Testing
### **Swagger UI** (if enabled)
If Swagger is configured, you can test the API in the browser at:
```
http://localhost:5064/swagger
```

### **Using Postman**
1. Open Postman
2. Test `GET /api/Grants`
3. Send `POST /api/Grants` with the following JSON body:
   ```json
   {
     "name": "Startup Grant",
     "description": "For new businesses under 1 year old",
     "eligibilityCriteria": "Must be a registered startup",
     "amount": 5000
   }
   ```
4. Verify the response and test updates/deletions.

## 🔗 Contributions & Updates
- This project is still in development.
- Please report any issues or suggestions in the **GitHub Issues** section.

---

✅ **Last Updated:** February 27, 2025

