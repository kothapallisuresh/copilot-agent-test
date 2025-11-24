# Hello API

A simple ASP.NET Core Web API with two endpoints for greeting and time retrieval.

## Description

This is a minimal ASP.NET Core Web API (.NET 8.0) that provides:
- `/hello` endpoint - Returns "Hello from Copilot!"
- `/time` endpoint - Returns the current server time in ISO 8601 format

## Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download) or later
- [Docker](https://www.docker.com/get-started) (optional, for containerized deployment)

## Quick Start

### Build the Project

```bash
# Clone the repository
git clone https://github.com/kothapallisuresh/copilot-agent-test.git
cd copilot-agent-test

# Restore dependencies
dotnet restore HelloApi/HelloApi.csproj

# Build the project
dotnet build HelloApi/HelloApi.csproj --configuration Release
```

### Run the Application

```bash
# Run from the HelloApi directory
cd HelloApi
dotnet run
```

The API will be available at `http://localhost:5249` (or the port shown in the console output).

### Test the Endpoints

```bash
# Test the hello endpoint
curl http://localhost:5249/hello
# Expected: Hello from Copilot!

# Test the time endpoint
curl http://localhost:5249/time
# Expected: 2025-11-24T09:47:43.1472035Z (ISO 8601 format)
```

## Running Tests

The project includes comprehensive unit tests using xUnit and ASP.NET Core integration testing.

```bash
# Run all tests
dotnet test HelloApi.Tests/HelloApi.Tests.csproj

# Run tests with detailed output
dotnet test HelloApi.Tests/HelloApi.Tests.csproj --verbosity detailed
```

**Test Coverage:**
- ✅ Hello endpoint returns correct message
- ✅ Time endpoint returns ISO 8601 formatted time
- ✅ Time endpoint returns current server time

## Docker Deployment

### Build the Docker Image

```bash
# Build from repository root
docker build -t hello-api .
```

The Dockerfile uses a multi-stage build with:
- **Build stage**: Uses .NET 8.0 SDK to compile the application
- **Runtime stage**: Uses minimal .NET 8.0 ASP.NET runtime image

### Run the Container

```bash
# Run the container
docker run -p 8080:8080 hello-api

# Test the endpoints
curl http://localhost:8080/hello
curl http://localhost:8080/time
```

### Pull from GitHub Container Registry

After the CI/CD pipeline runs, images are published to GitHub Container Registry:

```bash
docker pull ghcr.io/kothapallisuresh/copilot-agent-test:main
docker run -p 8080:8080 ghcr.io/kothapallisuresh/copilot-agent-test:main
```

## API Endpoints

| Endpoint | Method | Description | Response |
|----------|--------|-------------|----------|
| `/hello` | GET | Returns a greeting message | `Hello from Copilot!` |
| `/time` | GET | Returns current server time in ISO 8601 format | `2025-11-24T09:47:43.1472035Z` |

## Project Structure

```
.
├── .github/
│   └── workflows/
│       └── build-test-publish.yml  # CI/CD pipeline
├── HelloApi/
│   ├── Program.cs                  # Main application entry point
│   ├── HelloApi.csproj             # Project configuration
│   ├── appsettings.json            # Application settings
│   └── Properties/
│       └── launchSettings.json     # Development settings
├── HelloApi.Tests/
│   ├── ApiEndpointsTests.cs        # Integration tests
│   └── HelloApi.Tests.csproj       # Test project configuration
├── Dockerfile                      # Multi-stage Docker build
├── .gitignore                      # Git ignore rules
└── README.md                       # This file
```

## CI Pipeline

The project includes a GitHub Actions CI workflow (`.github/workflows/ci.yml`) that automatically runs on every push and pull request to the `main` branch.

**What the CI pipeline does:**
1. **Restore dependencies** - Downloads all required NuGet packages
2. **Build** - Compiles the HelloApi project in Release configuration
3. **Build Tests** - Compiles the HelloApi.Tests project
4. **Run tests** - Executes all xUnit tests and reports results

**When it runs:**
- On every push to the `main` branch
- On every pull request targeting the `main` branch

The CI pipeline ensures that all code changes pass the build and test requirements before being merged, maintaining code quality and catching issues early.

## CI/CD Pipeline

The project also includes a comprehensive CI/CD workflow (`.github/workflows/build-test-publish.yml`) that:

1. **Build & Test**: Restores dependencies, builds the project, and runs all tests
2. **Docker Build & Push**: Builds the Docker image and publishes to GitHub Container Registry

This workflow runs on:
- Push to `main` or `copilot/**` branches
- Pull requests to `main`
- Manual trigger via workflow dispatch

## Development

### Adding New Endpoints

Edit `HelloApi/Program.cs` to add new endpoints:

```csharp
app.MapGet("/your-endpoint", () => "Your response");
```

### Running in Development Mode

```bash
cd HelloApi
dotnet watch run
```

This will automatically rebuild and restart the application when you make changes.

## License

This project is open source and available under the MIT License.