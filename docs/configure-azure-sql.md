# Configure Azure SQL Database, schema and permissions

Follow these steps to create a new Azure SQL Server and database, create a table with test data, and grant the managed identity permission to SELECT from the table.

## 1. Create SQL Server and database:
- Create a SQL Server by running the following command in the terminal. The server name and FQDN is printed after completion. We will use them later:
  ```
  az sql server create --subscription d1775405-6d42-4fba-99ac-3cae223d9087 \
  --resource-group radix-workshop-24 \
  --output tsv \
  --query "[name,fullyQualifiedDomainName]" \
  --enable-ad-only-auth \
  --location northeurope \
  --external-admin-principal-type User \
  --external-admin-sid $(az ad signed-in-user show -otsv --query id) \
  --external-admin-name "$(az ad signed-in-user show -otsv --query mail)" \
  --name sql-edc24-radix-workshop-$(az ad signed-in-user show -otsv --query mail | awk -F"@" '{print tolower($1)}')
  ```
- Open the [radix-workshop-24](https://portal.azure.com/#@StatoilSRM.onmicrosoft.com/resource/subscriptions/d1775405-6d42-4fba-99ac-3cae223d9087/resourcegroups/radix-workshop-24/overview) resource group, find and open your SQL Server and go to `Security` > `Networking` to configure firewall rules to allow your current public IP address to connect:  
  ![SQL firewall](sql-firewall.png)
- Click `Add your client IPv4 address` to add your IP address.
- Click `Save` to save the changes.
- Add a firewall rule to allow connections from Radix Playground by running the following command:
  ```
  az sql server firewall-rule create --subscription d1775405-6d42-4fba-99ac-3cae223d9087 \
  --resource-group radix-workshop-24 \
  --output none \
  --server sql-edc24-radix-workshop-$(az account show -otsv --query=user.name | awk -F"@" '{print tolower($1)}') \
  --name radix_playground \
  --start-ip-address '104.45.86.104' \
  --end-ip-address '104.45.86.107'
  ```
- Create the database `moviedb` with the following command:
  ```
  az sql db create --subscription d1775405-6d42-4fba-99ac-3cae223d9087 \
  --resource-group radix-workshop-24 \
  --output none \
  --server sql-edc24-radix-workshop-$(az account show -otsv --query=user.name | awk -F"@" '{print tolower($1)}') \
  --auto-pause-delay 120 \
  --zone-redundant false \
  --backup-storage-redundancy Local \
  --compute-model Serverless \
  --edition GeneralPurpose \
  --family Gen5 \
  --capacity 1 \
  --name moviedb
  ```
## 2. Setting up the database:
  - In the code editor (VS Code), open the `/sql` directory and then open the `3-access.sql` file. Replace `<your Equinor user name>` in line 12 with your Equinor user name. Save the changes (no need to commit yet) as we will use the SQL scripts later in the workshop.
  - Open the [radix-workshop-24](https://portal.azure.com/#@StatoilSRM.onmicrosoft.com/resource/subscriptions/d1775405-6d42-4fba-99ac-3cae223d9087/resourcegroups/radix-workshop-24/overview) resource group, find and open your SQL Server (you can type your user name in the `Filter` field), go to `Setting` > `SQL databases` and click on the `moviedb` database to open.
  - Click `Query editor (preview)` in the left menu, and then the blue `Continue as <your email>` button.  
  ![db login](database-login.png)
  - Go back to the code editor (VS Code).
  - For each file in the `/sql` directory, copy the context into the `Query editor` and click `Run`.

---

[[Home]](../readme.md)  
[[Previous]](configure-workload-identity.md) [[Next]](configure-page-sqlconnection.md)