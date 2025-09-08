# Animal Shelter API

#### An API for an animal shelter.

#### By _**India Lyon-Myrick**_

## Technologies Used

* _C#_
* _.NET_
* _MySQL_
* _MySQL Workbench_
* _Git_

## Description

_An API designed for an animal shelter. The API contains a list of all animals, the ability to add new animals to the shelter list, and functionality to edit or deleting existing animals. In order to access animal information, users must register an account via the ``register`` endpoint. The project uses authentication tokens to allow users access to animal-related routes. After registering, users can access the ``login`` endpoint, which will assign them a token giving them access to the animal endpoints for 10 minutes before they must sign in again._

_Note: When making API calls through Postman, please copy the token returned by the ``login`` route. To make calls, access the ``Authorization`` tab of your request, set the type to ``Bearer Token``, and paste your token. Once again, tokens expire after 10 minutes. After that, you will need to log in again and update your token._

## Setup/Installation Requirements

* _You will need [.NET](https://dotnet.microsoft.com/en-us/download/dotnet/6.0), [MySQL](https://downloads.mysql.com/archives/get/p/25/file/mysql-installer-web-community-8.0.19.0.msi), and [Git](https://git-scm.com/downloads/) in order to run the program._

_1: Clone the repository to a folder of choice on your machine (by either using the "Code" button on the GitHub page, or in a terminal application using `git clone https://github.com/igl-myrick/AnimalShelterApi.Solution`)._

_2: Using a terminal application such as Git Bash or Windows Command Prompt, navigate to the top level of the program folder, then into the `AnimalShelterApi` folder._

_3: You will need to create an `appsettings.json` file within the `AnimalShelterApi` folder, including the following code:_

```
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;database=[YOUR-DB-NAME];uid=[YOUR-USER-HERE];pwd=[YOUR-PASSWORD-HERE];"
  },
  "Jwt": {
    "Key": "[YOUR-KEY-HERE]",
    "Issuer": "http://localhost:5124",
    "Audience": "dotnetclient"
  }
}
```

_Insert your own MySQL username in place of [YOUR-USER-HERE], MySQL password in place of [YOUR-PASSWORD-HERE], and the name of your database in place of [YOUR-DB-NAME]. You will additionally need to insert a string of letters and/or numbers at least 32 characters long in place of [YOUR-KEY-HERE]. Remove the square brackets when including your own information._

_4: Once the `appsettings.json` file has been created, run the command `dotnet ef database update` in your terminal to create the database._

_5: Next, run `dotnet build` in the command line to build the program._

_6: After the program is built, run `dotnet run` to start the program._

_7: Once the program is running, you can make calls to the API through either your own webpage/programs, or through an application like [Postman](https://www.postman.com/downloads/)._

## API Endpoints

### Manage accounts:

_Registration:_

    POST http://localhost:5124/api/auth/register

_Logging in:_

    POST http://localhost:5124/api/auth/login

### Shelter endpoints:

_Access a list of all animals:_

    GET http://localhost:5124/api/animals/

_Access a specific animal's entry by id:_

    GET http://localhost:5124/api/animals/{id}

_Add a new animal:_

    POST http://localhost:5124/api/animals/

_Edit an existing animal:_

    PUT http://localhost:5124/api/animals/{id}

_Delete an existing animal:_

    DELETE http://localhost:5124/api/animals/{id}

### Endpoint details

#### Account-related Endpoints:

_When registering for an account, you must include a username and a password in the body, as well as re-entering the password to confirm the spelling. Here is an example request:_

```
{
    "username": "ExampleUser",
    "password": "password1234",
    "confirmPassword": "password1234"
}
```

_Signing in requires a similar body, except you do not need to confirm the password:_

```
{
    "username": "ExampleUser",
    "password": "password1234",
}
```

#### Animal Endpoints:

_The first GET route, which displays all animals, has three optional parameters that can be used to narrow the list of animals:_

| Parameter | Type | Required | Description | Example query |
|---|---|---|---|---|
| species | String | not required | Returns all animals of the given species | GET http://localhost:5124/api/animals?species=cat |
| breed | String | not required | Returns all animals of the given breed | GET http://localhost:5124/api/animals?breed=tabby
| name | String | not required | Returns all animals with a matching name | GET http://localhost:5124/api/animals?name=jack

_You can also chain these queries together, for example:_ 

``GET http://localhost:5124/api/animals?species=cat&breed=tabby``

---

_When making a request to the POST endpoint, you must include a body in JSON format containing the animal's information. Here is an example request:_

```
{
  "name": "Jill",
  "species": "Dog",
  "breed": "Chihuahua",
  "age": 12
}
```

_PUT requests have similar body requirements, but you must additionally specify the id of the animal you wish to edit. Here is an example request to ``http://localhost:5124/api/animals/1``:_

```
{
  "animalId": 3,
  "name": "Michael",
  "species": "Dog",
  "breed": "German Shepherd",
  "age": 4
}
```

## Known Bugs

* _None at the moment_