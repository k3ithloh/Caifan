# Caifan

University Exchange for Students

Requirements
-----------
- C#
- .Net
- postgresql

## Project Setup
This guide outline the steps needed to start ExchangeLah in a development environment.

**1. Clone the repository on your development machine.**
```sh
git clone https://github.com/ExchangeLah-SG/Caifan.git
```

**2. Set up Backend Server**  
   Server: [postgresql](https://www.sqlshack.com/setting-up-a-postgresql-database-on-mac/)  
   Recommended GUI: [DBeaver](https://dbeaver.io/download/)  
   After setting up a new database connection via DBeaver, create a new database ```caifan```.  
  
**3. Migrate DB**  
Do this whenever you add new modals/ entity relations/ attributes  
```sh
dotnet ef migrations add <migration_name>
```

**4. Update DB**  
This runs the migration file created in the step before and updates the schema where needed.
```sh
dotnet ef database update
```
  
**5. Populate Data**  
TBC, check back later :)

## Development Workflow
**NEVER WORK ON THE MAIN BRANCH**
```sh
# Always work on a new branch for each feature you are working on
git checkout -b <branch name>
git push origin <branch name>

# commit and push to Github
git add .
git commit -m "<commit name>"
git push origin <branch name>
```
Click [here](http://guides.beanstalkapp.com/version-control/common-git-commands.html) for more Git CLI commands

End Points
    GET ALL
https://localhost:7059/api/module
https://localhost:7059/api/basket
https://localhost:7059/api/country
https://localhost:7059/api/degree
https://localhost:7059/api/region
https://localhost:7059/api/university
https://localhost:7059/api/review
https://localhost:7059/api/user
https://localhost:7059/api/degreeuser

    GET ONE
https://localhost:7059/api/module/{mid}
https://localhost:7059/api/basket/{bid}
https://localhost:7059/api/country/{countryid}
https://localhost:7059/api/degree/{degreeid}
https://localhost:7059/api/region/{regionid}
https://localhost:7059/api/university/{universityname}
https://localhost:7059/api/review/{reviewid}
https://localhost:7059/api/user/{userid}

