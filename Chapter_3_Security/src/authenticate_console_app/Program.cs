// See https://aka.ms/new-console-template for more information

using System;
using System.Threading.Tasks;
using Microsoft.Identity.Client;

public class Program
{

    public static async Task Main(string[] args)
    {

        Console.WriteLine("Hello, World!");

        // create new App Registration in your AD

        // dotnet add package Microsoft.Identity.Client

        var app = PublicClientApplicationBuilder
            .Create("f152fe48-577e-4ad9-b8c8-88f37f2aa22e")
            .WithAuthority(AzureCloudInstance.AzurePublic, "54391de2-2024-4d49-8ed6-fc3d5058c803")
            .WithRedirectUri("http://localhost")
            .Build();

        string[] permission_scope = { "user.read" }; // see API Permission from registered App

        AuthenticationResult res = await app.AcquireTokenInteractive(permission_scope).ExecuteAsync();

        Console.WriteLine($"Authenticated User : {res.Account.Username}");
        Console.WriteLine($"Token expires on : {res.ExpiresOn}");

    }

}
