# Hello API

A simple ASP.NET Core Web API with a single endpoint that returns a greeting message.

## Description

This is a minimal ASP.NET Core Web API that exposes a `/hello` endpoint which returns "Hello from Copilot!".

## Prerequisites

- [.NET 10.0 SDK](https://dotnet.microsoft.com/download) or later
- [Docker](https://www.docker.com/get-started) (optional, for containerized deployment)

## Setup Instructions

### Running Locally

1. Clone the repository:
   ```bash
   git clone https://github.com/kothapallisuresh/copilot-agent-test.git
   cd copilot-agent-test
   ```

2. Navigate to the project directory:
   ```bash
   cd HelloApi
   ```

3. Restore dependencies:
   ```bash
   dotnet restore
   ```

4. Build the project:
   ```bash
   dotnet build
   ```

5. Run the application:
   ```bash
   dotnet run
   ```

6. The API will be available at `http://localhost:5000` (or the port shown in the console output)

7. Test the endpoint:
   ```bash
   curl http://localhost:5000/hello
   ```
   
   Expected response: `Hello from Copilot!`

### Running with Docker

1. Build the Docker image:
   ```bash
   docker build -t hello-api .
   ```

2. Run the container:
   ```bash
   docker run -p 8080:8080 hello-api
   ```

3. Test the endpoint:
   ```bash
   curl http://localhost:8080/hello
   ```
   
   Expected response: `Hello from Copilot!`

## API Endpoints

- `GET /hello` - Returns a greeting message

## Project Structure

```
.
├── HelloApi/
│   ├── Program.cs              # Main application entry point
│   ├── HelloApi.csproj         # Project configuration
│   └── appsettings.json        # Application settings
├── Dockerfile                  # Docker configuration
├── .gitignore                  # Git ignore rules
└── README.md                   # This file
```

## Development

To modify the greeting message, edit the `/hello` endpoint in `HelloApi/Program.cs`:

```csharp
app.MapGet("/hello", () => "Your custom message here!");
```

## License

This project is open source and available under the MIT License.