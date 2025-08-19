# ASP.NET Core Web API with JWT Authentication

This project demonstrates how to implement **JWT (JSON Web Token) authentication** in an ASP.NET Core Web API.

---

## 🚀 Features
- ASP.NET Core Web API
- JWT-based authentication with **Bearer tokens**
- Configurable `Issuer`, `Audience`, and `SecretForKey` in `appsettings.json`
- Example `AccountController` with a `/login` endpoint for token generation
- Protected endpoints requiring JWT authentication

---

## 🛠 Prerequisites
- [.NET 9 SDK](https://dotnet.microsoft.com/en-us/download)
- A code editor (e.g., [Rider](https://www.jetbrains.com/rider/) or [Visual Studio Code](https://code.visualstudio.com/))
- [Postman](https://www.postman.com/) or Rider/VSCode HTTP requests

---

## ⚙️ Configuration
Add the following section to your **`appsettings.json`**:

```json
"Authentication": {
  "Issuer": "https://localhost:7277",
  "Audience": "https://localhost:7277",
  "SecretForKey": "RgDldLrk+p+T0JIsAkDD7THNt/npmWYl4VvV3UUIrSVE="
}
