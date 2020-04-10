# Dependencies:

	- It has to work if you launch: dotnet restore.

	- The dependencies it would restore are:
		- Microsoft.EntityFrameworkCore
		- Microsoft.EntityFrameworkCore.Tools
		- Microsoft.EntityFrameworkCore.Design
		- Npgsql.EntityFrameworkCore.PostgreSQL
		- Microsoft.AspNetCore.Authentication.JwtBearer --version 3.0.0
		- JWT --version 6.1.4
# Add user secrets

	- dotnet user-secrets init
	- dotnet user-secrets set "Connection:Password" "yourpassword"
	- dotnet user-secrets set "Crypto:Secret" "Your secret goes here"

# Launch migrations

	- But first be sure you have ef tools installed: dotnet tool install --global dotnet-ef
	- dotnet ef database update