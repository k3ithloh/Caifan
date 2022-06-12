# Caifan

University Exchange for Students

Requirement
-----------
- C#
- .Net

## Project Setup

This guide outline the steps needed to start ExchangeLah in a development environment.
#### Do not work on the Main Branch

- Clone the repository on your development machine.

```sh
git clone https://github.com/ExchangeLah-SG/Caifan.git
```

## Create new branch and change to the new branch

```sh
git checkout -b <branch name>
git push origin <branch name>
```

## Commit and push to Github

```sh
git add .
git commit -m "<commit name>"
git push origin <branch name>
```
## Link to Git CLI Comments
>http://guides.beanstalkapp.com/version-control/common-git-commands.html

## Backend server setup

**1 - Start up Database Server:**  
Server - <a href="https://www.sqlshack.com/setting-up-a-postgresql-database-on-mac/">postgresql</a>  
Recommended GUI - <a href="https://dbeaver.io/download/">DBeaver</a>  
After setting up a new database connection, create a new database ```caifan``` 

**2 - Migrate DB**  
Do this whenever you add new modals/ entity relations/ attributes  
```dotnet ef migrations add <migration_name>```

**3 - Update DB**  
```dotnet ef database update```  
This runs the migration file created in the step before and updates the schema where needed.


