## About the project

Implementation of a Dynamic Storage, with changes at runtime.
It contains the following projects:

* **SanaWebTest** : This is the web part of the project and an examble of use, using 2 types of Storage(Sql Server via Entity Framework and In-Memory)
* **SanaWebTest.Storage** : Is is the storage engine, it uses a repository patter to encapsulate the common call to the chosen storage.
* **SanaWebTest.Storage.EFSqlServer** :  It is a storage implementation using Entity Framework to connect to a Sql Server database.
* **SanaWebTest.Storage.InMemory** : It is an implementation of memory storage, it uses a singleton class to keep the information stored while the aplication is running

## Getting Started

These are the requirements to run the application

### Prerequisites

* Visual Studio 2022 (.Net 6.0)
* Sql Server Database (Change ConectionString in the appsettings.json)
	```
	"ConnectionStrings": {
		"SqlServerDefault": "data source=localhost;Initial Catalog = SanaTest; Integrated Security = True;"
	}
	```
* The database name must be exists


## Usage

Run the application
