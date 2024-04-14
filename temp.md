IConfidentialClientApplication cca = ConfidentialClientApplicationBuilder
                .Create(" ")
                .WithClientSecret(" ")
                .WithAuthority(AzureCloudInstance.AzurePublic, " ")
                 
.Build();

AuthenticationResult authResult = await cca.AcquireTokenForClient(new[] { "https://graph.microsoft.com/.default" }).ExecuteAsync();
 
