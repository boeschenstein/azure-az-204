# Authenticate console app

## Portal

- open Azure Active Directory
- add new App Registration
  - Select Single Tenant (or any others)
  - Select `Public client`, set URL to http://localhost

## Create console app

`dotnet new console`

```cs
var app = PublicClientApplicationBuilder
    .Create("<Application (Client) Id>")
    .WithAuthority(AzureCloudInstance.AzurePublic, "<Directory (Tenant) Id>")
    .WithRedirectUri("http://localhost")
    .Build()

    string[] permission_scope = { "user.read" }; // see API Permission from registered App

    AuthenticationResult res = await app.AcquireTokenInteractive(permission_scope).ExecuteAsync();

```

- Run the App
- Accept the consent
- watch the output in the console
