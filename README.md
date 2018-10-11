# Mendz.Data.Oracle
Provides a generic Mendz.Data-aware context for ADO.Net-compatible access to Oracle databases. [Wiki](https://github.com/etmendz/Mendz.Data.Oracle/wiki)
## Namespace
Mendz.Data.Oracle
### Contents
Name | Description
---- | -----------
OracleDbDataContext | Provides the database context for an Oracle database.
OracleDataSettingOption | Provides the data setting options for Oracle access.
#### OracleDbDataContext
Mendz.Data.Common defines an IDbDataContext interface, 
which is implemented as GenericDbDataContextBase, 
which is derived by DbDataContextBase.
OracleDbDataContext derives from DbDataContextBase, which requires the abstract BuildContext() method to be implemented.
The internal implementation uses Mendz.Data.DataSettingOptions to build the data context using OracleDataSettingOption.Name.

OracleDbDataContext assumes that appsettings.json contains an entry/section for DataSettings.
```JSON
{
    "DataSettings": {
        "ConnectionStrings": {
            "OracleConnectionString" : "connection string to Oracle"
        }
    }
}
```
In the application startup or initialization routine, the DataSettings should be loaded into DataSettingOptions as follows:
```C#
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            DataSettingOptions.Initialize(Configuration.GetSection("DataSettings").Get<DataSettings>());
        }
```
Mendz.Data-aware repositories implement DbRepositoryBase, which expects a Mendz.Data-aware data context.
Using OracleDbDataContext, a repository skeleton can look like the following:
```C#
    public class TestRepository : DbRepositoryBase<OracleDbDataContext>
    {
        ...
    }
```
Using Mendz.Data can shield the application from "knowing" about the data context.
The application does not need to reference Mendz.Data.Oracle.
The application can reference only Mendz.Data, and the models and repositories libraries.
## NuGet It...
https://www.nuget.org/packages/Mendz.Data.Oracle/
