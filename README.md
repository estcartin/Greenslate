# Greenslate test project

## Instrucctions to run the project

1. Go to the following path DB_Scripts
2. Run the following SQL Script to create and seed the DB: SeededDBScript.sql
3. Go to the web.config file and update the following entry:
```
<configuration>
  <connectionStrings>
    <add name="GreenslateContext" connectionString="...**data source=SERVER_NAME;**..." />
  </connectionStrings>
  </configuration>
  ```
