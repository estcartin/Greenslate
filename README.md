# Greenslate test project

The following is the test project for Greenslate application by Esteban Varela.
If you have any questions please don't hesitate to contact me.

## Instrucctions to run the project

1. Go to the following path DB_Scripts
2. Run the following SQL Script to create and seed the DB: SeededDBScript.sql
3. Go to the web.config file and update the following entry with your server name:
```
<configuration>
  <connectionStrings>
    <add name="GreenslateContext" connectionString="...data source=SERVER_NAME;..." />
  </connectionStrings>
  </configuration>
  ```

## Instructions to change method to retrieve projects by user

This projects contains two implementations of the GetUserProjectData method to retrieve the projects for the user.
One implementation uses the model entities and Linq to retrieve the data.
Another implementation uses a stored procedure that returns the needed data from DB.

To change which method is used change the following setting from the web.config file:
```
<configuration>
  <appSettings>
    <add key="GetDataFromStoreProc" value="false" />
  </appSettings>
 </configuration>
```
True: Gets data from Linq and models
False: Gets data from store proc
