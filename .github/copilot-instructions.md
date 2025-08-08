# Claudes 2.0 - ASP.NET Core 9.0 + Angular 19 Application

Claudes 2.0 is a full-stack web application template that provides a complete authentication and user management system. It consists of an ASP.NET Core 9.0 Web API backend, an Angular 19 frontend client, and a shared Entity Framework Core data access layer.

Always reference these instructions first and fallback to search or bash commands only when you encounter unexpected information that does not match the info here.

## Working Effectively

### Prerequisites and Installation
- Install .NET 9.0 SDK:
  - `curl -sSL https://dot.net/v1/dotnet-install.sh | bash /dev/stdin --channel 9.0`
  - `export PATH="$HOME/.dotnet:$PATH"`
  - Verify: `dotnet --version` (should show 9.0.x)
- Node.js and npm are required for Angular client (usually pre-installed)
- SQL Server or SQL Server LocalDB for database (LocalDB only works on Windows)

### Bootstrap, Build, and Test
- Navigate to repository root: `cd /home/runner/work/Proyecto_Final_Progra_6/Proyecto_Final_Progra_6`
- Restore NuGet packages: `export PATH="$HOME/.dotnet:$PATH" && dotnet restore`
  - Takes ~65 seconds on first run. NEVER CANCEL. Set timeout to 10+ minutes.
- Build the entire solution: `export PATH="$HOME/.dotnet:$PATH" && dotnet build`
  - Takes ~178 seconds (3 minutes). NEVER CANCEL. Set timeout to 15+ minutes.
- Install Angular dependencies: `cd Proyecto_Final_Progra_6/Proyecto_Final_Progra_6.client && npm install`
  - Usually fast (~2 seconds) if packages are cached
- Lint Angular code: `npm run lint` (in client directory)
  - Takes ~5 seconds. Always passes in this project.

### Platform Limitations and Workarounds
- **Angular Build Issues:** `npm run build` fails due to Google Fonts CDN restrictions when trying to inline external fonts. This is a network/firewall limitation, not a code issue.
- **Angular Tests:** `npm test` fails in headless environments due to Chrome requiring X server. Tests work fine in GUI environments.
- **Database on Linux:** The default LocalDB connection string only works on Windows. On Linux, you need to:
  - Use SQL Server in Docker, or
  - Switch to SQLite by modifying connection strings in `appsettings.Development.json`
- **Server Startup:** `dotnet run` in Server project fails on Linux due to LocalDB dependency. This is expected.

### Run the Application (Development)
**Note:** Due to platform limitations, the full application cannot run on Linux without database setup modifications.

**For Windows Development:**
- Backend: `cd Proyecto_Final_Progra_6/Proyecto_Final_Progra_6.Server && dotnet run`
- Frontend: `cd Proyecto_Final_Progra_6/Proyecto_Final_Progra_6.client && npm start`
- Access at: `https://localhost:5001` (backend) and `https://localhost:4200` (frontend)

**For Linux Development (requires database modification):**
- Modify `appsettings.Development.json` to use SQLite or SQL Server instead of LocalDB
- Then follow the same run commands

### Default Login Credentials
- **Admin Account:**
  - Username: `admin`
  - Email: `admin@claudes20.com`
  - Password: `tempP@ss123`
- **Standard User Account:**
  - Username: `user`
  - Email: `user@claudes20.com`
  - Password: `tempP@ss123`

## Validation
- ALWAYS run `dotnet restore` and `dotnet build` to validate .NET changes
- ALWAYS run `npm run lint` in the client directory before committing frontend changes
- Angular build validation requires network access for Google Fonts - skip this check in restricted environments
- Angular unit tests require GUI environment - skip in headless/CI environments
- Manual testing requires proper database setup (Windows LocalDB or alternative)

## Technology Stack
**Backend (.NET Server):**
- ASP.NET Core 9.0 Web API
- Entity Framework Core 9.0 with SQL Server
- OpenIddict for OIDC/OAuth2 authentication
- AutoMapper for object mapping
- FluentValidation for input validation
- MailKit for email services
- Quartz for background jobs
- Serilog for logging
- Swagger/OpenAPI for documentation

**Frontend (Angular Client):**
- Angular 19 with TypeScript 5.6
- Bootstrap 5 + Bootswatch themes
- ng2-charts and Chart.js for data visualization
- ng-bootstrap for UI components
- ngx-translate for internationalization
- RxJS for reactive programming
- ESLint for code quality
- Jasmine + Karma for testing

**Data Layer (Core):**
- Entity Framework Core 9.0
- ASP.NET Core Identity for user management
- Repository and Unit of Work patterns

## Project Structure
```
/
├── Proyecto_Final_Progra_6.sln              # Visual Studio solution file
├── Proyecto_Final_Progra_6/
│   ├── Documentos/                          # Project documentation and specifications
│   ├── Proyecto_Final_Progra_6.Server/     # ASP.NET Core Web API
│   │   ├── Controllers/                     # API controllers
│   │   ├── Services/                        # Business services
│   │   ├── Configuration/                   # App configuration (AutoMapper, OIDC)
│   │   ├── Authorization/                   # Authorization handlers
│   │   ├── Migrations/                      # Entity Framework migrations
│   │   ├── Program.cs                       # Application entry point
│   │   └── appsettings*.json               # Configuration files
│   ├── Proyecto_Final_Progra_6.client/     # Angular 19 SPA
│   │   ├── src/app/                        # Angular application source
│   │   ├── src/assets/                     # Static assets and themes
│   │   ├── package.json                    # npm dependencies
│   │   ├── angular.json                    # Angular CLI configuration
│   │   └── karma.conf.js                   # Test configuration
│   └── Proyecto_Final_Progra_6.Core/       # Shared data access layer
│       ├── Models/                         # Entity models
│       ├── Infrastructure/                 # Database context and repositories
│       └── Services/                       # Core business services
```

## Common Tasks

### Building and Testing Commands
```bash
# Navigate to repository root
cd /home/runner/work/Proyecto_Final_Progra_6/Proyecto_Final_Progra_6

# Set .NET path (required for .NET 9.0)
export PATH="$HOME/.dotnet:$PATH"

# Restore and build .NET solution (NEVER CANCEL - takes 3+ minutes)
dotnet restore    # ~65 seconds
dotnet build      # ~178 seconds

# Angular tasks (from client directory)
cd Proyecto_Final_Progra_6/Proyecto_Final_Progra_6.client
npm install       # Install dependencies
npm run lint      # Lint code (always use before commits)
npm run build     # Build (fails in restricted networks due to Google Fonts)
npm test          # Run tests (fails in headless environments)
```

### Timing Expectations (CRITICAL - NEVER CANCEL)
- **dotnet restore:** 60-70 seconds on first run. NEVER CANCEL. Set timeout to 600+ seconds.
- **dotnet build:** 170-180 seconds (3 minutes). NEVER CANCEL. Set timeout to 900+ seconds.
- **npm install:** 2-5 seconds when cached, up to 60 seconds fresh install.
- **npm run lint:** 3-5 seconds.
- **npm run build:** 15-20 seconds when working, but FAILS in restricted networks.

### Complete Validation Workflow
```bash
# Complete development setup and validation
cd /home/runner/work/Proyecto_Final_Progra_6/Proyecto_Final_Progra_6

# Step 1: Ensure .NET 9.0 is available
export PATH="$HOME/.dotnet:$PATH"
dotnet --version  # Should show 9.0.x

# Step 2: Restore and build .NET (NEVER CANCEL - takes 3+ minutes total)
dotnet restore    # Wait for completion (~65 seconds)
dotnet build      # Wait for completion (~178 seconds)

# Step 3: Validate Angular setup
cd Proyecto_Final_Progra_6/Proyecto_Final_Progra_6.client
npm install       # Usually fast if cached
npm run lint      # Should pass without errors

# Step 4: Test what works vs. what has limitations
npm run build     # EXPECTED TO FAIL in restricted networks (Google Fonts issue)
npm test          # EXPECTED TO FAIL in headless environments (needs Chrome GUI)

# Step 5: Check server capabilities
cd ../Proyecto_Final_Progra_6.Server
export PATH="$HOME/.dotnet:$PATH"
dotnet run        # EXPECTED TO FAIL on Linux (LocalDB limitation)
```

### Key Files to Understand
- `Program.cs` - Main server configuration and dependency injection setup
- `appsettings.Development.json` - Development database connection (uses LocalDB)
- `package.json` - Angular dependencies and npm scripts
- `angular.json` - Angular build configuration and project settings
- Solution files in `Documentos/` - Detailed technical specifications in Spanish

### Essential Commands Reference
```bash
# .NET Development
export PATH="$HOME/.dotnet:$PATH"              # Required for .NET 9.0
dotnet --version                               # Verify .NET installation
dotnet restore                                 # Restore NuGet packages
dotnet build                                   # Build entire solution
dotnet run                                     # Run server (needs database)

# Angular Development  
npm install                                    # Install dependencies
npm run lint                                   # Code quality check
npm run build                                  # Build for production
npm start                                      # Development server
npm test                                       # Run unit tests

# Common File Locations
ls -la Proyecto_Final_Progra_6/                    # Main projects
ls -la Proyecto_Final_Progra_6/Documentos/         # Project documentation
ls -la Proyecto_Final_Progra_6/Proyecto_Final_Progra_6.Server/Controllers/    # API endpoints
ls -la Proyecto_Final_Progra_6/Proyecto_Final_Progra_6.client/src/app/        # Angular app
```

### Development Workflow
1. Always run `export PATH="$HOME/.dotnet:$PATH"` in new terminal sessions
2. Run `dotnet restore` and `dotnet build` after any .NET changes
3. Run `npm run lint` after any Angular changes
4. Test compilation frequently during development
5. Use proper timeout values (10+ minutes for builds) in automated environments
6. Remember platform limitations when working on different operating systems

### Authentication and Authorization
- Built-in user and role management system
- OpenIddict-based OIDC/OAuth2 implementation
- JWT token-based authentication (stored in browser, not cookies)
- Default admin and user accounts for testing (see login credentials above)

### Database Management
- Entity Framework Core Code First approach
- Migrations are in `Proyecto_Final_Progra_6.Server/Migrations/`
- Default connection uses SQL Server LocalDB (Windows only)
- For Linux development, switch to SQLite or SQL Server in Docker

## Functional Requirements and Features

Based on the project documentation, this application is designed to be a university bookstore inventory and sales management system with the following features:

### Core Business Entities (minimum 3 with full CRUD):
- **Users and Roles:** Complete user management with authentication and authorization
- **Inventory Management:** Book catalog, stock levels, pricing
- **Sales Management:** Orders, transactions, customer management
- **Reporting:** Sales reports, inventory reports, KPIs dashboard

### Required Database Relations:
- One-to-many: Users→Orders, Categories→Books
- Many-to-many: Books→Authors, Orders→Books (order details)
- All implemented using Entity Framework Core migrations

### Authentication Features:
- JWT token-based authentication (Bearer tokens stored in WebStorage)
- User registration, login, logout functionality
- Role-based access control (admin, user roles)
- Password recovery and user profile management

### Reporting Requirements:
- Minimum 2 reports exportable to PDF
- Dashboard with KPIs and charts (Chart.js integration)
- Filtering capabilities for reports
- Crystal Reports integration for advanced reporting

## Troubleshooting Common Issues

### Build Failures:
- **"NETSDK1045" error:** Ensure .NET 9.0 SDK is installed and PATH is set correctly
- **npm build failures:** Usually due to Google Fonts network restrictions - this is expected in restricted environments
- **Long build times:** This is normal - dotnet build takes 3+ minutes, never cancel
- **Missing packages:** Run `dotnet restore` and `npm install` before building

### Runtime Issues:
- **LocalDB connection failures:** Expected on Linux, requires database configuration changes
- **CORS errors:** Check that frontend and backend URLs match in configuration
- **Authentication issues:** Verify JWT configuration and token storage

### Development Environment:
- **Chrome test failures:** Expected in headless environments, tests work in GUI environments
- **Angular serve issues:** Ensure npm dependencies are installed and ports are available
- **Visual Studio integration:** This project works best with Visual Studio 2022 on Windows

## Git and Version Control
- Repository is configured for GitHub integration
- Default .gitignore excludes build artifacts and dependencies
- Commit frequently, especially after successful builds
- Use feature branches for new development

## Academic Project Context
This template is designed for educational purposes demonstrating:
- Modern full-stack web development practices
- Enterprise-grade authentication and authorization
- Proper separation of concerns with layered architecture
- RESTful API design principles
- Responsive frontend development with Angular
- Database design and ORM usage
- Code quality and maintainability standards

This application template provides a solid foundation for rapid development of authentication-enabled web applications with modern technologies and best practices.