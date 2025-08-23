## Instalation Steps

1. In appsettings,json, inside connection string, update server name to match your machine

	"ConnectionStrings": {
	  "Default": "Server=["YOUR SERVER MACHINE"];Database=CardholdersDb;Trusted_Connection=True;TrustServerCertificate=True;"
	}

2. Run next commands:

	- Restore NuGet packages
		dotnet restore  
		
	- apply migrations (create DB)
		dotnet ef database update 

	 -  Start the app
		dotnet run      



- Login with: 
	  username: admin
	  password: admin123