# Web-API-User-Management

his project contains a simple example of a Web API for user management. The project supports `GET`, `POST`, `PUT`, `DELETE`, and `PATCH` HTTP methods following REST standards. It also pays attention to HTTP status codes, error handling, model validation, routing, and model binding processes.

## Usage

1. Clone the source code of the project to your computer.
2. Navigate to the project directory and start the project by entering the `dotnet run` command in the terminal/command prompt.
3. You can use an API client (Swagger, Postman, cURL, etc.) to test the API.

## API Endpoints

- `GET /Users`: Lists all users.
- `GET /Users/{id}`: Retrieves the user with the specified ID.
- `POST /Users`: Adds a new user.
- `PUT /Users/{id}`: Updates the user with the specified ID.
- `DELETE /Users/{id}`: Deletes the user with the specified ID.
- `PATCH /Users/{id}`: Updates the name of the user with the specified ID.

## Query Parameters

- `GET /Users/list?name={name}`: Filters users by name.
