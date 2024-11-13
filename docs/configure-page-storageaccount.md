# Configure application to stream a video from an Azure Storage Account

In this part of the workload identity workshop we will use the [Azure SDK](https://azure.microsoft.com/en-us/downloads/) to access a protected Azure resource. More specifically, our application will open a video stored in a Storage Account container and stream it to the web page.

We will use an existing [Storage Account](https://portal.azure.com/#view/Microsoft_Azure_Storage/ContainerMenuBlade/~/overview/storageAccountId/%2Fsubscriptions%2Fd1775405-6d42-4fba-99ac-3cae223d9087%2FresourceGroups%2FEDC23-Radix-Workshop%2Fproviders%2FMicrosoft.Storage%2FstorageAccounts%2Fedc23radixworkshop1/path/videos/etag/%220x8DBA878C42047D1%22/defaultEncryptionScope/%24account-encryption-key/denyEncryptionScopeOverride~/false/defaultId//publicAccessVal/None) containing one file named `radix.mp4`.

- Assign the `Storage Blob Data Reader` role to your managed identity for the blob container . Run the following command in the terminal:
   ```
   principalId=$(az identity show --subscription d1775405-6d42-4fba-99ac-3cae223d9087 \
   --resource-group radix-workshop-24 \
   --name id-edc24-radix-workshop-$(az ad signed-in-user show -otsv --query mail | awk -F"@" '{print tolower($1)}') \
   --query principalId \
   -otsv) && \
   az role assignment create \
   --scope "/subscriptions/d1775405-6d42-4fba-99ac-3cae223d9087/resourceGroups/radix-workshop-24/providers/Microsoft.Storage/storageAccounts/edc24radixworkshop/blobServices/default/containers/videos" \
   --role "Storage Blob Data Reader" \
   --assignee-principal-type ServicePrincipal \
   --assignee-object-id $principalId \
   --output none
   ```
- Uncomment lines 15-20 in `/src/web/Program.cs`. This code registers a blob service client and configures the credentials provider.
- In `/src/web/Controllers/StreamController.cs`, delete line 35 (the `throw` statement) and uncomment lines 22-33. This is the code that connects to the blob container and reads the content of the `radix.mp4` file.
- Uncomment lines 37-39 in `/src/web/Pages/Index.cshtml`. The `<video>` element will play the video returned from the `StreamController`.
- Commit and push the changes to your GitHub repo. Wait for the `build-deploy` job to finish, and open the web page to verify that your managed identity is able to access the blob container and stream the video to your browser.

You can run locally with `dotnet watch run --project src/web/Web.csproj`

---

[[Home]](../readme.md)  
[[Previous]](configure-page-sqlconnection.md) [[Next]](pipeline-configure-workload-identity.md)