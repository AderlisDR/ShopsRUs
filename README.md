# ShopsRUs
RESTful API that provides the ability to calculate discounts, generate total costs and generate invoices for ShopsRUs customers.

## Getting Started
This project is based on .Net Core 3.1 and SQL Server, it is important to have the versions of these installed on the machine.

### Installation
You'll need a IDE that supports running .Net Core applications, I recommend using Visual Studio. Once you have openned the solution, you'll need to update the connection string to set the db environment, for this, look for a file named **appsettings.Development.json** inside **ShopsRUs.API** folder and set the key **DefaultConnection** with your SQL Server server environment. Once your db environment is set, open Package Manager Console and run following commands:

```
Update-Database
```

### Running the application
Once your environment is set, you can run the application in debug mode to test the endpoints. In the root folder of this repository you'll find a Postman Endpoint Collection that may help you do the testings.