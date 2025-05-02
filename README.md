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



## II. Setup Husky
🧱 Step-by-Step Husky Setup in .NET Projects
✅ 1. Init Node project for Husky
bash
Copy
Edit
npm init -y
npm install husky --save-dev
npx husky install
Then add to your package.json:

json
Copy
Edit
"scripts": {
  "prepare": "husky install"
}
✅ 2. Create Pre-Commit Hook: dotnet format + dotnet build
bash
Copy
Edit
npx husky add .husky/pre-commit "bash scripts/pre-commit.sh"
chmod +x .husky/pre-commit
Create file: scripts/pre-commit.sh

bash
Copy
Edit
#!/bin/bash

echo "Running dotnet format..."
dotnet format --verify-no-changes
if [ $? -ne 0 ]; then
  echo "❌ Code formatting issues detected. Please run 'dotnet format'."
  exit 1
fi

echo "Running dotnet build (includes analyzers)..."
dotnet build -warnaserror
if [ $? -ne 0 ]; then
  echo "❌ Build failed. Please fix issues."
  exit 1
fi

echo "✅ Pre-commit checks passed!"
✅ 3. Create Commit Message Hook: Conventional Commit Check
bash
Copy
Edit
npm install @commitlint/cli @commitlint/config-conventional --save-dev
Create file commitlint.config.js

js
Copy
Edit
module.exports = {
  extends: ['@commitlint/config-conventional']
};
Create hook:

bash
Copy
Edit
npx husky add .husky/commit-msg "npx --no -- commitlint --edit $1"