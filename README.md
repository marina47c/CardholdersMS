
## Backend development environment / prerequisites

- MS SQL server 2022 (version used in development 16.0.1145; SQL Express)
- Visual Studio 2022
- .NET SDK 9.0.304
- Target Framework .NET 8

## Frontend development environment / prerequisites

- Node.js (v24.4.0)
- npm (11.4.2)
- angular CLI (20.2.0)

## Installation Instructions

1. Clone backend repository:
```bash
git clone https://github.com/marina47c/CardholdersMS.git
```

2. Open the project in Visual Studio. 
	Locate appsetting.json update the connection string to match your machine:

```json
	"ConnectionStrings": {
	  "Default": "Server=["YOUR SERVER MACHINE"];Database=CardholdersDb;Trusted_Connection=True;TrustServerCertificate=True;"
	}
```

 3. Run the backend
	- Running the project will:
	    - Create the `CardholdersDb` database
	    - Seed initial data
	    - Launch Swagger at: [https://localhost:7107/swagger/index.html](https://localhost:7107/swagger/index.html)
	 
4. Clone the frontend repository
```bash
git clone https://github.com/marina47c/cardholders-ui.git
```

5.  Install dependencies and run
	Navigate into the frontend project directory, then run:
	
	```bash
		npm install
		ng serve -o
```
	
	This will open the app at: [http://localhost:4200/login](http://localhost:4200/login)

6. Default login credentials:

```pgsql
	user: admin
	password: admin123
```
	
7. After logging in, you should see the application running in your browser
   
<img width="1873" height="899" alt="image" src="https://github.com/user-attachments/assets/0798b85b-4a9b-4925-a518-4be78573f4a6" />

<img width="1859" height="1007" alt="image" src="https://github.com/user-attachments/assets/eff52f0f-82e5-4626-a171-0205b5ada537" />

<img width="1859" height="878" alt="image" src="https://github.com/user-attachments/assets/a290a70c-971e-4066-aec0-b9bdabb3db75" />

<img width="1846" height="1006" alt="image" src="https://github.com/user-attachments/assets/2291b511-df5d-4b05-98bf-1daeece2e4ed" />
