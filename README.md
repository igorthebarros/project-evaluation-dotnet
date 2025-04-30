# 📦 .Net Order Flow Control System - .Net Dockerized API

This system is composed by one main API: WebAPI. This API is responsible for all CRUD actions for Order domain entity.

Tech-stack: .Net 9, ASP.Net, Docker, Entity Framework Core, PostgreSQL, PGAdmin, AutoMapper, Serilog...

## 🐳 Running with Docker Compose

Make sure Docker and Docker Compose are installed on your machine.

1. Open your terminal.
2. Navigate to the project root folder.
3. Run this command:

```bash
docker-compose up --build
```

This will download dependencies, build the containers, and start the services.

---

## 💾 Applying EF Core Migrations

The application is configured to run the migrations automatically if it's on Development environment.

If in Production environment, please consider the following:

Once the container is running, open a terminal and execute:

```bash
docker exec -it {your-api-container-name} dotnet ef database update
```

Replace `{your-api-container-name}` with the name of your running API container.

This will apply any pending Entity Framework Core migrations to your database.

---

## 🔍 Accessing Swagger UI

After your container is up and running, open this URL in your browser:

```
http://localhost:{your_port}/swagger
```

Example:
```
http://localhost:5000/swagger
```

This will open the Swagger page where you can explore and test your endpoints.

---

## 📬 Sample Data for `/api/Order`

{
  "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "createdAt": "2025-04-30T04:46:32.404Z",
  "updatedAt": "2025-04-30T04:46:32.404Z",
  "clientId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "status": "string",
  "tax": 0,
  "userId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "items": [
    {
      "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
      "createdAt": "2025-04-30T04:46:32.404Z",
      "updatedAt": "2025-04-30T04:46:32.404Z",
      "productId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
      "quantity": 0,
      "price": 0,
      "orderId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
      "product": {
        "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        "createdAt": "2025-04-30T04:46:32.404Z",
        "updatedAt": "2025-04-30T04:46:32.404Z",
        "name": "string",
        "description": "string",
        "price": 0,
        "isActive": true,
        "orderProducts": [
          "string"
        ]
      },
      "order": {
        "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        "createdAt": "2025-04-30T04:46:32.404Z",
        "updatedAt": "2025-04-30T04:46:32.404Z",
        "clientId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        "status": 0,
        "tax": 0,
        "userId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        "user": {
          "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
          "createdAt": "2025-04-30T04:46:32.404Z",
          "updatedAt": "2025-04-30T04:46:32.404Z",
          "username": "string",
          "email": "string",
          "role": 0,
          "orders": [
            "string"
          ]
        },
        "items": [
          "string"
        ]
      }
    }
  ]
}
