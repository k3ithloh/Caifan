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

## Deployment Pipeline
Run the following commands in the project directory (---/Caifan) to package our code for deployment.
``` sh
dotnet publish -c Release -o deploy
cd deploy
zip -r ../deploy_bundle.zip *
```
Go to Elastic Beanstalk in the AWS Management Console. On the left navbar and click on the following:
Environments > Caifan-prod-env > Upload and deploy > Choose File > Select the deploy_bundle.zip you just created.  
  
Version label will be automatically generated, no need to change. Then click ```Deploy```.  
  
Deployment takes around 1-3 mins. After deployment is completed, ensure that Health Status is ```Ok```. You may click the ```Go to Environment``` on the left navbar to access the landing page of our application. 

