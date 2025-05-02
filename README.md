# 1. Project Structure
# basesrc/
│
├── Api/                     # ASP.NET Core API project
│   ├── Program.cs
│   ├── Endpoints/
│   │   ├── Users/
│   │   │   ├── CreateUser.cs       # Command + Handler
│   │   │   ├── GetUserById.cs      # Query + Handler
│   │   │   ├── Mapping.cs
│   │   │   ├── Validator.cs
│   │   │   └── UserEndpoints.cs    # Route Registration
│   └── Middleware/
│
├── Domain/                 # Entities, Enums, Value Objects
│   └── User.cs
│
├── Infrastructure/         # EF, Email, Redis, 3rd-party
│   └── Data/
│       ├── AppDbContext.cs
│       └── Repository.cs
│
├── Application/            # CQRS Handlers, Validators, DTOs
│   └── Interfaces/
│
└── SharedKernel/           # Common types, errors, etc.


# 2. C# Formatting & Linting


## File

[*.cs]
dotnet_sort_system_directives_first = true
dotnet_separate_import_directive_groups = true
csharp_new_line_before_open_brace = all
csharp_indent_case_contents = true
csharp_indent_switch_labels = true

dotnet tool install -g dotnet-format
dotnet format


# 3. Branching strategy
main        ← production (deploy tag)
└── dev     ← integration branch
    └── feature/user-login
    └── bugfix/validation-fix

# 4. Convetion commit
feat(user): allow user registration
fix(api): handle null values in GetUser
chore(deps): update Newtonsoft.Json


# 5. PR Rules
### What this PR does
- Adds user creation endpoint

### Testing Notes
- Tested with Swagger UI

### Checklist
- [ ] Tests added
- [ ] CI passes
- [ ] Code formatted

