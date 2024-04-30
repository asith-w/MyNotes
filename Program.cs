using Microsoft.Graph;
using Microsoft.Kiota.Abstractions.Authentication;

await GetChatHostedContentViaGraphClientV5();
await ByteStreamToBase64();
//await ByteStreamToBase64GraphClient_V5();

static async Task GetChatHostedContentViaGraphClientV5()
{
    string accessToken = "eyJ0eXAiOiJKV1QiLCJub25jZSI6IktVVzI5QmUxU3JiNS14T3JCSHktc3NSSEticXFjOGlVcnZtemxPeTZtODAiLCJhbGciOiJSUzI1NiIsIng1dCI6IkwxS2ZLRklfam5YYndXYzIyeFp4dzFzVUhIMCIsImtpZCI6IkwxS2ZLRklfam5YYndXYzIyeFp4dzFzVUhIMCJ9.eyJhdWQiOiIwMDAwMDAwMy0wMDAwLTAwMDAtYzAwMC0wMDAwMDAwMDAwMDAiLCJpc3MiOiJodHRwczovL3N0cy53aW5kb3dzLm5ldC8yZmUzNWYzNy02NDIxLTQyMDktYTYwMS1hYWQ5ODk3NGFkMTcvIiwiaWF0IjoxNzE0NTA0NzcxLCJuYmYiOjE3MTQ1MDQ3NzEsImV4cCI6MTcxNDU5MTQ3MSwiYWNjdCI6MCwiYWNyIjoiMSIsImFpbyI6IkFWUUFxLzhXQUFBQVdZSEh3eHRkVnIvUUdvUGVDWnp5MjlxQTJmZml0Z0xibWRrNi80Rk1LcVRsZ3dTWUZBaGRBTGJuMTArcmJzNFFxb3IzdlRhejBjejVqenFHeXhEMDl6TFNtTWdUK3V5SHMzTTY1TFFhTEEwPSIsImFtciI6WyJwd2QiLCJtZmEiXSwiYXBwX2Rpc3BsYXluYW1lIjoiR3JhcGggRXhwbG9yZXIiLCJhcHBpZCI6ImRlOGJjOGI1LWQ5ZjktNDhiMS1hOGFkLWI3NDhkYTcyNTA2NCIsImFwcGlkYWNyIjoiMCIsImZhbWlseV9uYW1lIjoiRGV2IiwiZ2l2ZW5fbmFtZSI6IkFkbWluMDEiLCJpZHR5cCI6InVzZXIiLCJpcGFkZHIiOiIxMTEuMjIzLjE4My43MSIsIm5hbWUiOiJBZG1pbjAyLURldiIsIm9pZCI6ImJlNmNhMWMwLTIxMDgtNGJlNy05NTViLTkwZjM5YWJkYWIzNyIsInBsYXRmIjoiMyIsInB1aWQiOiIxMDAzMjAwMEVDQjU3REQ0IiwicHdkX2V4cCI6Ijg2OTQ3NSIsInB3ZF91cmwiOiJodHRwczovL3BvcnRhbC5taWNyb3NvZnRvbmxpbmUuY29tL0NoYW5nZVBhc3N3b3JkLmFzcHgiLCJyaCI6IjAuQVhFQU4xX2pMeUZrQ1VLbUFhclppWFN0RndNQUFBQUFBQUFBd0FBQUFBQUFBQUJ4QUpjLiIsInNjcCI6IkFQSUNvbm5lY3RvcnMuUmVhZC5BbGwgQVBJQ29ubmVjdG9ycy5SZWFkV3JpdGUuQWxsIEFwcENhdGFsb2cuUmVhZC5BbGwgQXBwbGljYXRpb24uUmVhZFdyaXRlLkFsbCBCb29raW5ncy5NYW5hZ2UuQWxsIEJvb2tpbmdzLlJlYWQuQWxsIENhbGVuZGFycy5SZWFkIENhbGVuZGFycy5SZWFkV3JpdGUgQ2hhbm5lbC5SZWFkQmFzaWMuQWxsIENoYW5uZWxNZW1iZXIuUmVhZC5BbGwgQ2hhbm5lbE1lc3NhZ2UuUmVhZC5BbGwgQ2hhbm5lbFNldHRpbmdzLlJlYWQuQWxsIENoYW5uZWxTZXR0aW5ncy5SZWFkV3JpdGUuQWxsIENoYXQuQ3JlYXRlIENoYXQuUmVhZEJhc2ljIENoYXRNZXNzYWdlLlJlYWQgQ29udGFjdHMuUmVhZCBDb250YWN0cy5SZWFkV3JpdGUgQ29udGFjdHMuUmVhZFdyaXRlLlNoYXJlZCBEZWxlZ2F0ZWRQZXJtaXNzaW9uR3JhbnQuUmVhZFdyaXRlLkFsbCBEZXZpY2VNYW5hZ2VtZW50QXBwcy5SZWFkLkFsbCBEZXZpY2VNYW5hZ2VtZW50QXBwcy5SZWFkV3JpdGUuQWxsIERldmljZU1hbmFnZW1lbnRDb25maWd1cmF0aW9uLlJlYWQuQWxsIERldmljZU1hbmFnZW1lbnRDb25maWd1cmF0aW9uLlJlYWRXcml0ZS5BbGwgRGlyZWN0b3J5LlJlYWQuQWxsIERpcmVjdG9yeS5SZWFkV3JpdGUuQWxsIGVEaXNjb3ZlcnkuUmVhZC5BbGwgZURpc2NvdmVyeS5SZWFkV3JpdGUuQWxsIGVtYWlsIEZpbGVzLlJlYWQuQWxsIEZpbGVzLlJlYWRXcml0ZS5BbGwgRmlsZXMuUmVhZFdyaXRlLkFwcEZvbGRlciBGaWxlcy5SZWFkV3JpdGUuU2VsZWN0ZWQgR3JvdXAuUmVhZFdyaXRlLkFsbCBNYWlsLlJlYWQgTWFpbC5TZW5kIE1haWxib3hTZXR0aW5ncy5SZWFkIE1haWxib3hTZXR0aW5ncy5SZWFkV3JpdGUgTm90ZXMuUmVhZC5BbGwgT25saW5lTWVldGluZ0FydGlmYWN0LlJlYWQuQWxsIE9ubGluZU1lZXRpbmdzLlJlYWQgb3BlbmlkIFBlb3BsZS5SZWFkIFBlb3BsZS5SZWFkLkFsbCBQb2xpY3kuUmVhZFdyaXRlLkF1dGhlbnRpY2F0aW9uTWV0aG9kIFByZXNlbmNlLlJlYWQgUHJlc2VuY2UuUmVhZC5BbGwgcHJvZmlsZSBSZXBvcnRzLlJlYWQuQWxsIFNjaGVkdWxlLlJlYWQuQWxsIFNlY3VyaXR5SW5jaWRlbnQuUmVhZC5BbGwgU2VjdXJpdHlJbmNpZGVudC5SZWFkV3JpdGUuQWxsIFNpdGVzLkZ1bGxDb250cm9sLkFsbCBTaXRlcy5NYW5hZ2UuQWxsIFNpdGVzLlJlYWQuQWxsIFNpdGVzLlJlYWRXcml0ZS5BbGwgVGFza3MuUmVhZCBUYXNrcy5SZWFkV3JpdGUgVGVhbS5DcmVhdGUgVGVhbS5SZWFkQmFzaWMuQWxsIFRlYW1zQWN0aXZpdHkuU2VuZCBUZWFtc0FwcC5SZWFkV3JpdGUgVGVhbXNBcHBJbnN0YWxsYXRpb24uUmVhZEZvclRlYW0gVGVhbXNBcHBJbnN0YWxsYXRpb24uUmVhZFdyaXRlRm9yVXNlciBUZWFtc0FwcEluc3RhbGxhdGlvbi5SZWFkV3JpdGVTZWxmRm9yVXNlciBUZWFtc1RhYi5DcmVhdGUgVGVhbXNUYWIuUmVhZC5BbGwgVGVhbXNUYWIuUmVhZFdyaXRlLkFsbCBUZWFtc1RhYi5SZWFkV3JpdGVGb3JDaGF0IFRlYW1zVGFiLlJlYWRXcml0ZUZvclVzZXIgVGhyZWF0SHVudGluZy5SZWFkLkFsbCBVc2VyLlJlYWQgQ2hhdC5SZWFkIiwic2lnbmluX3N0YXRlIjpbImttc2kiXSwic3ViIjoiaWJScTBvWS1wVjdBV3hmLUc0V09SczJ5NXpGb2R5U2lTZGxNU3k0OTdPQSIsInRlbmFudF9yZWdpb25fc2NvcGUiOiJBUyIsInRpZCI6IjJmZTM1ZjM3LTY0MjEtNDIwOS1hNjAxLWFhZDk4OTc0YWQxNyIsInVuaXF1ZV9uYW1lIjoiYWRtaW4wMUBkZXY1MDAub25taWNyb3NvZnQuY29tIiwidXBuIjoiYWRtaW4wMUBkZXY1MDAub25taWNyb3NvZnQuY29tIiwidXRpIjoiU2QyT1JMcVVUa3FhTm5yWnF1ZTNBUSIsInZlciI6IjEuMCIsIndpZHMiOlsiOWI4OTVkOTItMmNkMy00NGM3LTlkMDItYTZhYzJkNWVhNWMzIiwiNjJlOTAzOTQtNjlmNS00MjM3LTkxOTAtMDEyMTc3MTQ1ZTEwIiwiYjc5ZmJmNGQtM2VmOS00Njg5LTgxNDMtNzZiMTk0ZTg1NTA5Il0sInhtc19jYyI6WyJDUDEiXSwieG1zX3NzbSI6IjEiLCJ4bXNfc3QiOnsic3ViIjoiSmZnWGJPOW5PeFJFUy1DSnMybHAwX3dvR2l6VlFJXzMwdHF4M0dmbWo2SSJ9LCJ4bXNfdGNkdCI6MTYwMjU3MjM0Mn0.kRXna5BxiGgHrV1lrNEVotqn7BnWftFdOme1WNV6LCc2PZcL5vm0-UxZ6B7rghrxCSUUIKQn0Tp1tW32M4ZpN10z84JkYeDi5n4GIizRuMX4p1w_bn59mZxgQbXs1gupzriroJY2R9QXbK-CBNLLYLgaI60pdkEDEOXGhjwmdou8CQ5YW9fECGLRkzo7zjOfShefZxVXgPDt601-Dna1kjrWrYgP8agzYP-A81gfp2BUmFl3foQOESPNlVjn5Vn-j5GSU7jmBpN0NQHSs1cFRZC-7qMoOFuh9VRWVDKqpHthrYEbqLD7kzwONhBK2MFwpA13xK8_jNzTBnylUmbLnA";
    var authenticationProvider = new BaseBearerTokenAuthenticationProvider(new TokenProvider(accessToken));
    var graphClient = new GraphServiceClient(authenticationProvider);

    try
    {
        using (Stream userPhotoStream = await graphClient.Me.Chats["19:be6ca1c0-2108-4be7-955b-90f39abdab37_c80b365f-416d-4955-91ae-2d3cef779bdf@unq.gbl.spaces"]
            .Messages["1714505318594"]
            .HostedContents["aWQ9eF8wLXNhLWQxMC1mODM2ZThhNmFjYWYxMTcxYzU5MTBiMDhiNTBlOTU0ZCx0eXBlPTEsdXJsPWh0dHBzOi8vYXMtYXBpLmFzbS5za3lwZS5jb20vdjEvb2JqZWN0cy8wLXNhLWQxMC1mODM2ZThhNmFjYWYxMTcxYzU5MTBiMDhiNTBlOTU0ZC92aWV3cy9pbWdv"]
            .Content.GetAsync())
        {
            if (userPhotoStream != null)
            {
                // Convert photo content to Base64 string
                byte[] photoBytes;
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    await userPhotoStream.CopyToAsync(memoryStream);
                    photoBytes = memoryStream.ToArray();
                }

                string base64String = Convert.ToBase64String(photoBytes);
                Console.WriteLine($"base64String : {base64String}");

            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error occurred: {ex.Message}");
    }

}

static async Task ByteStreamToBase64()
{
    // Replace 'YOUR_ACCESS_TOKEN' with the actual access token obtained from Microsoft Graph authentication
    string accessToken = "eyJ0eXAiOiJKV1QiLCJub25jZSI6IllabUJMbk85YUItc3pNN1VmYmpQOGtRbXBWb0tKXzkwbEQxajlnZVFCbTgiLCJhbGciOiJSUzI1NiIsIng1dCI6IkwxS2ZLRklfam5YYndXYzIyeFp4dzFzVUhIMCIsImtpZCI6IkwxS2ZLRklfam5YYndXYzIyeFp4dzFzVUhIMCJ9.eyJhdWQiOiIwMDAwMDAwMy0wMDAwLTAwMDAtYzAwMC0wMDAwMDAwMDAwMDAiLCJpc3MiOiJodHRwczovL3N0cy53aW5kb3dzLm5ldC8yZmUzNWYzNy02NDIxLTQyMDktYTYwMS1hYWQ5ODk3NGFkMTcvIiwiaWF0IjoxNzE0NDk5NjUyLCJuYmYiOjE3MTQ0OTk2NTIsImV4cCI6MTcxNDU4NjM1MiwiYWNjdCI6MCwiYWNyIjoiMSIsImFpbyI6IkFWUUFxLzhXQUFBQUw0eFZNaXZjSW1SYTlCZFRWekcxMVdVQitJaHBsbmV2WUE5YnFvTlZNcGZWKyt3cjNtYWVyc0xuU0VUT091VUZMN0F3Q2JYbEx3dy91cnA2b3ZXNHhUQ2pkeThVbHRSQjFtb0xVcldTRFNFPSIsImFtciI6WyJwd2QiLCJtZmEiXSwiYXBwX2Rpc3BsYXluYW1lIjoiR3JhcGggRXhwbG9yZXIiLCJhcHBpZCI6ImRlOGJjOGI1LWQ5ZjktNDhiMS1hOGFkLWI3NDhkYTcyNTA2NCIsImFwcGlkYWNyIjoiMCIsImZhbWlseV9uYW1lIjoiRGV2IiwiZ2l2ZW5fbmFtZSI6IkFkbWluMDEiLCJpZHR5cCI6InVzZXIiLCJpcGFkZHIiOiIxMTEuMjIzLjE4My43MSIsIm5hbWUiOiJBZG1pbjAyLURldiIsIm9pZCI6ImJlNmNhMWMwLTIxMDgtNGJlNy05NTViLTkwZjM5YWJkYWIzNyIsInBsYXRmIjoiMyIsInB1aWQiOiIxMDAzMjAwMEVDQjU3REQ0IiwicHdkX2V4cCI6Ijg3NDU5NCIsInB3ZF91cmwiOiJodHRwczovL3BvcnRhbC5taWNyb3NvZnRvbmxpbmUuY29tL0NoYW5nZVBhc3N3b3JkLmFzcHgiLCJyaCI6IjAuQVhFQU4xX2pMeUZrQ1VLbUFhclppWFN0RndNQUFBQUFBQUFBd0FBQUFBQUFBQUJ4QUpjLiIsInNjcCI6IkFQSUNvbm5lY3RvcnMuUmVhZC5BbGwgQVBJQ29ubmVjdG9ycy5SZWFkV3JpdGUuQWxsIEFwcENhdGFsb2cuUmVhZC5BbGwgQXBwbGljYXRpb24uUmVhZFdyaXRlLkFsbCBCb29raW5ncy5NYW5hZ2UuQWxsIEJvb2tpbmdzLlJlYWQuQWxsIENhbGVuZGFycy5SZWFkIENhbGVuZGFycy5SZWFkV3JpdGUgQ2hhbm5lbC5SZWFkQmFzaWMuQWxsIENoYW5uZWxNZW1iZXIuUmVhZC5BbGwgQ2hhbm5lbE1lc3NhZ2UuUmVhZC5BbGwgQ2hhbm5lbFNldHRpbmdzLlJlYWQuQWxsIENoYW5uZWxTZXR0aW5ncy5SZWFkV3JpdGUuQWxsIENoYXQuQ3JlYXRlIENoYXRNZXNzYWdlLlJlYWQgQ29udGFjdHMuUmVhZCBDb250YWN0cy5SZWFkV3JpdGUgQ29udGFjdHMuUmVhZFdyaXRlLlNoYXJlZCBEZWxlZ2F0ZWRQZXJtaXNzaW9uR3JhbnQuUmVhZFdyaXRlLkFsbCBEZXZpY2VNYW5hZ2VtZW50QXBwcy5SZWFkLkFsbCBEZXZpY2VNYW5hZ2VtZW50QXBwcy5SZWFkV3JpdGUuQWxsIERldmljZU1hbmFnZW1lbnRDb25maWd1cmF0aW9uLlJlYWQuQWxsIERldmljZU1hbmFnZW1lbnRDb25maWd1cmF0aW9uLlJlYWRXcml0ZS5BbGwgRGlyZWN0b3J5LlJlYWQuQWxsIERpcmVjdG9yeS5SZWFkV3JpdGUuQWxsIGVEaXNjb3ZlcnkuUmVhZC5BbGwgZURpc2NvdmVyeS5SZWFkV3JpdGUuQWxsIGVtYWlsIEZpbGVzLlJlYWQuQWxsIEZpbGVzLlJlYWRXcml0ZS5BbGwgRmlsZXMuUmVhZFdyaXRlLkFwcEZvbGRlciBGaWxlcy5SZWFkV3JpdGUuU2VsZWN0ZWQgR3JvdXAuUmVhZFdyaXRlLkFsbCBNYWlsLlJlYWQgTWFpbC5TZW5kIE1haWxib3hTZXR0aW5ncy5SZWFkIE1haWxib3hTZXR0aW5ncy5SZWFkV3JpdGUgTm90ZXMuUmVhZC5BbGwgT25saW5lTWVldGluZ0FydGlmYWN0LlJlYWQuQWxsIE9ubGluZU1lZXRpbmdzLlJlYWQgb3BlbmlkIFBlb3BsZS5SZWFkIFBlb3BsZS5SZWFkLkFsbCBQb2xpY3kuUmVhZFdyaXRlLkF1dGhlbnRpY2F0aW9uTWV0aG9kIFByZXNlbmNlLlJlYWQgUHJlc2VuY2UuUmVhZC5BbGwgcHJvZmlsZSBSZXBvcnRzLlJlYWQuQWxsIFNjaGVkdWxlLlJlYWQuQWxsIFNlY3VyaXR5SW5jaWRlbnQuUmVhZC5BbGwgU2VjdXJpdHlJbmNpZGVudC5SZWFkV3JpdGUuQWxsIFNpdGVzLkZ1bGxDb250cm9sLkFsbCBTaXRlcy5NYW5hZ2UuQWxsIFNpdGVzLlJlYWQuQWxsIFNpdGVzLlJlYWRXcml0ZS5BbGwgVGFza3MuUmVhZCBUYXNrcy5SZWFkV3JpdGUgVGVhbS5DcmVhdGUgVGVhbS5SZWFkQmFzaWMuQWxsIFRlYW1zQWN0aXZpdHkuU2VuZCBUZWFtc0FwcC5SZWFkV3JpdGUgVGVhbXNBcHBJbnN0YWxsYXRpb24uUmVhZEZvclRlYW0gVGVhbXNBcHBJbnN0YWxsYXRpb24uUmVhZFdyaXRlRm9yVXNlciBUZWFtc0FwcEluc3RhbGxhdGlvbi5SZWFkV3JpdGVTZWxmRm9yVXNlciBUZWFtc1RhYi5DcmVhdGUgVGVhbXNUYWIuUmVhZC5BbGwgVGVhbXNUYWIuUmVhZFdyaXRlLkFsbCBUZWFtc1RhYi5SZWFkV3JpdGVGb3JDaGF0IFRlYW1zVGFiLlJlYWRXcml0ZUZvclVzZXIgVGhyZWF0SHVudGluZy5SZWFkLkFsbCBVc2VyLlJlYWQiLCJzaWduaW5fc3RhdGUiOlsia21zaSJdLCJzdWIiOiJpYlJxMG9ZLXBWN0FXeGYtRzRXT1JzMnk1ekZvZHlTaVNkbE1TeTQ5N09BIiwidGVuYW50X3JlZ2lvbl9zY29wZSI6IkFTIiwidGlkIjoiMmZlMzVmMzctNjQyMS00MjA5LWE2MDEtYWFkOTg5NzRhZDE3IiwidW5pcXVlX25hbWUiOiJhZG1pbjAxQGRldjUwMC5vbm1pY3Jvc29mdC5jb20iLCJ1cG4iOiJhZG1pbjAxQGRldjUwMC5vbm1pY3Jvc29mdC5jb20iLCJ1dGkiOiIyd2xpZnJ5dDRraVBNbWZLclkwR0FBIiwidmVyIjoiMS4wIiwid2lkcyI6WyI5Yjg5NWQ5Mi0yY2QzLTQ0YzctOWQwMi1hNmFjMmQ1ZWE1YzMiLCI2MmU5MDM5NC02OWY1LTQyMzctOTE5MC0wMTIxNzcxNDVlMTAiLCJiNzlmYmY0ZC0zZWY5LTQ2ODktODE0My03NmIxOTRlODU1MDkiXSwieG1zX2NjIjpbIkNQMSJdLCJ4bXNfc3NtIjoiMSIsInhtc19zdCI6eyJzdWIiOiJKZmdYYk85bk94UkVTLUNKczJscDBfd29HaXpWUUlfMzB0cXgzR2ZtajZJIn0sInhtc190Y2R0IjoxNjAyNTcyMzQyfQ.fHmA1eBJW7X6CPtcgd0XJv1RLUW0Q1uB8RI0lcUeXZKg_O4fKcVevsgQ1LWa3GgTUtKnjYdE-y7Ma4lS7V5i3Y1bGKzmvH56h_RsxaP29QpsneIFbYiuVxUol711kgBeL_U24byGYf_geXhlVtCcQoZIcPklLJr-3wdflpQf7FGzkOwUrP-slTdHkar-H-nbj3y_uuAoLgsAxQtyd0OvcYaXaOZ0_gKw7InR-NwE_RbNsur9HFFYn1q6h0vWNShc9bMt-0r7JVc1GoVigm-xYCY_JxFY8qcyETSLMX-i0BzyhSXP-DZwrfTFVuKKblX9Eju0QwVCQX7KZXwoO3W8Vg";

    // Microsoft Graph endpoint to get the user's photo
    string graphEndpoint = "https://graph.microsoft.com/v1.0/me/photo/$value";

    try
    {
        // Create an HttpClient instance
        using (var client = new HttpClient())
        {
            // Set the authorization header with the access token
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

            // Send GET request to the Microsoft Graph endpoint
            HttpResponseMessage response = await client.GetAsync(graphEndpoint);

            // Check if the request was successful
            if (response.IsSuccessStatusCode)
            {
                // Read the response content as a byte array
                byte[] photoBytes = await response.Content.ReadAsByteArrayAsync();
                var base645String = Convert.ToBase64String(photoBytes);

                Console.WriteLine($"-----Base64 string ----------");
                Console.WriteLine($"{base645String}");
                Console.WriteLine($"<img src=\"data:image/png;base64,{base645String}\">");

                // You can then further process or save this byte array as needed
                // For example, save the byte array to a file
                //File.WriteAllBytes("user_photo.jpg", photoBytes);
                //Console.WriteLine("Photo saved successfully.");
            }
            else
            {
                Console.WriteLine($"Failed to retrieve photo. Status code: {response.StatusCode}");
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error occurred: {ex.Message}");
    }

}

static async Task ByteStreamToBase64GraphClient_V5()
{
    string accessToken = "eyJ0eXAiOiJKV1QiLCJub25jZSI6IllabUJMbk85YUItc3pNN1VmYmpQOGtRbXBWb0tKXzkwbEQxajlnZVFCbTgiLCJhbGciOiJSUzI1NiIsIng1dCI6IkwxS2ZLRklfam5YYndXYzIyeFp4dzFzVUhIMCIsImtpZCI6IkwxS2ZLRklfam5YYndXYzIyeFp4dzFzVUhIMCJ9.eyJhdWQiOiIwMDAwMDAwMy0wMDAwLTAwMDAtYzAwMC0wMDAwMDAwMDAwMDAiLCJpc3MiOiJodHRwczovL3N0cy53aW5kb3dzLm5ldC8yZmUzNWYzNy02NDIxLTQyMDktYTYwMS1hYWQ5ODk3NGFkMTcvIiwiaWF0IjoxNzE0NDk5NjUyLCJuYmYiOjE3MTQ0OTk2NTIsImV4cCI6MTcxNDU4NjM1MiwiYWNjdCI6MCwiYWNyIjoiMSIsImFpbyI6IkFWUUFxLzhXQUFBQUw0eFZNaXZjSW1SYTlCZFRWekcxMVdVQitJaHBsbmV2WUE5YnFvTlZNcGZWKyt3cjNtYWVyc0xuU0VUT091VUZMN0F3Q2JYbEx3dy91cnA2b3ZXNHhUQ2pkeThVbHRSQjFtb0xVcldTRFNFPSIsImFtciI6WyJwd2QiLCJtZmEiXSwiYXBwX2Rpc3BsYXluYW1lIjoiR3JhcGggRXhwbG9yZXIiLCJhcHBpZCI6ImRlOGJjOGI1LWQ5ZjktNDhiMS1hOGFkLWI3NDhkYTcyNTA2NCIsImFwcGlkYWNyIjoiMCIsImZhbWlseV9uYW1lIjoiRGV2IiwiZ2l2ZW5fbmFtZSI6IkFkbWluMDEiLCJpZHR5cCI6InVzZXIiLCJpcGFkZHIiOiIxMTEuMjIzLjE4My43MSIsIm5hbWUiOiJBZG1pbjAyLURldiIsIm9pZCI6ImJlNmNhMWMwLTIxMDgtNGJlNy05NTViLTkwZjM5YWJkYWIzNyIsInBsYXRmIjoiMyIsInB1aWQiOiIxMDAzMjAwMEVDQjU3REQ0IiwicHdkX2V4cCI6Ijg3NDU5NCIsInB3ZF91cmwiOiJodHRwczovL3BvcnRhbC5taWNyb3NvZnRvbmxpbmUuY29tL0NoYW5nZVBhc3N3b3JkLmFzcHgiLCJyaCI6IjAuQVhFQU4xX2pMeUZrQ1VLbUFhclppWFN0RndNQUFBQUFBQUFBd0FBQUFBQUFBQUJ4QUpjLiIsInNjcCI6IkFQSUNvbm5lY3RvcnMuUmVhZC5BbGwgQVBJQ29ubmVjdG9ycy5SZWFkV3JpdGUuQWxsIEFwcENhdGFsb2cuUmVhZC5BbGwgQXBwbGljYXRpb24uUmVhZFdyaXRlLkFsbCBCb29raW5ncy5NYW5hZ2UuQWxsIEJvb2tpbmdzLlJlYWQuQWxsIENhbGVuZGFycy5SZWFkIENhbGVuZGFycy5SZWFkV3JpdGUgQ2hhbm5lbC5SZWFkQmFzaWMuQWxsIENoYW5uZWxNZW1iZXIuUmVhZC5BbGwgQ2hhbm5lbE1lc3NhZ2UuUmVhZC5BbGwgQ2hhbm5lbFNldHRpbmdzLlJlYWQuQWxsIENoYW5uZWxTZXR0aW5ncy5SZWFkV3JpdGUuQWxsIENoYXQuQ3JlYXRlIENoYXRNZXNzYWdlLlJlYWQgQ29udGFjdHMuUmVhZCBDb250YWN0cy5SZWFkV3JpdGUgQ29udGFjdHMuUmVhZFdyaXRlLlNoYXJlZCBEZWxlZ2F0ZWRQZXJtaXNzaW9uR3JhbnQuUmVhZFdyaXRlLkFsbCBEZXZpY2VNYW5hZ2VtZW50QXBwcy5SZWFkLkFsbCBEZXZpY2VNYW5hZ2VtZW50QXBwcy5SZWFkV3JpdGUuQWxsIERldmljZU1hbmFnZW1lbnRDb25maWd1cmF0aW9uLlJlYWQuQWxsIERldmljZU1hbmFnZW1lbnRDb25maWd1cmF0aW9uLlJlYWRXcml0ZS5BbGwgRGlyZWN0b3J5LlJlYWQuQWxsIERpcmVjdG9yeS5SZWFkV3JpdGUuQWxsIGVEaXNjb3ZlcnkuUmVhZC5BbGwgZURpc2NvdmVyeS5SZWFkV3JpdGUuQWxsIGVtYWlsIEZpbGVzLlJlYWQuQWxsIEZpbGVzLlJlYWRXcml0ZS5BbGwgRmlsZXMuUmVhZFdyaXRlLkFwcEZvbGRlciBGaWxlcy5SZWFkV3JpdGUuU2VsZWN0ZWQgR3JvdXAuUmVhZFdyaXRlLkFsbCBNYWlsLlJlYWQgTWFpbC5TZW5kIE1haWxib3hTZXR0aW5ncy5SZWFkIE1haWxib3hTZXR0aW5ncy5SZWFkV3JpdGUgTm90ZXMuUmVhZC5BbGwgT25saW5lTWVldGluZ0FydGlmYWN0LlJlYWQuQWxsIE9ubGluZU1lZXRpbmdzLlJlYWQgb3BlbmlkIFBlb3BsZS5SZWFkIFBlb3BsZS5SZWFkLkFsbCBQb2xpY3kuUmVhZFdyaXRlLkF1dGhlbnRpY2F0aW9uTWV0aG9kIFByZXNlbmNlLlJlYWQgUHJlc2VuY2UuUmVhZC5BbGwgcHJvZmlsZSBSZXBvcnRzLlJlYWQuQWxsIFNjaGVkdWxlLlJlYWQuQWxsIFNlY3VyaXR5SW5jaWRlbnQuUmVhZC5BbGwgU2VjdXJpdHlJbmNpZGVudC5SZWFkV3JpdGUuQWxsIFNpdGVzLkZ1bGxDb250cm9sLkFsbCBTaXRlcy5NYW5hZ2UuQWxsIFNpdGVzLlJlYWQuQWxsIFNpdGVzLlJlYWRXcml0ZS5BbGwgVGFza3MuUmVhZCBUYXNrcy5SZWFkV3JpdGUgVGVhbS5DcmVhdGUgVGVhbS5SZWFkQmFzaWMuQWxsIFRlYW1zQWN0aXZpdHkuU2VuZCBUZWFtc0FwcC5SZWFkV3JpdGUgVGVhbXNBcHBJbnN0YWxsYXRpb24uUmVhZEZvclRlYW0gVGVhbXNBcHBJbnN0YWxsYXRpb24uUmVhZFdyaXRlRm9yVXNlciBUZWFtc0FwcEluc3RhbGxhdGlvbi5SZWFkV3JpdGVTZWxmRm9yVXNlciBUZWFtc1RhYi5DcmVhdGUgVGVhbXNUYWIuUmVhZC5BbGwgVGVhbXNUYWIuUmVhZFdyaXRlLkFsbCBUZWFtc1RhYi5SZWFkV3JpdGVGb3JDaGF0IFRlYW1zVGFiLlJlYWRXcml0ZUZvclVzZXIgVGhyZWF0SHVudGluZy5SZWFkLkFsbCBVc2VyLlJlYWQiLCJzaWduaW5fc3RhdGUiOlsia21zaSJdLCJzdWIiOiJpYlJxMG9ZLXBWN0FXeGYtRzRXT1JzMnk1ekZvZHlTaVNkbE1TeTQ5N09BIiwidGVuYW50X3JlZ2lvbl9zY29wZSI6IkFTIiwidGlkIjoiMmZlMzVmMzctNjQyMS00MjA5LWE2MDEtYWFkOTg5NzRhZDE3IiwidW5pcXVlX25hbWUiOiJhZG1pbjAxQGRldjUwMC5vbm1pY3Jvc29mdC5jb20iLCJ1cG4iOiJhZG1pbjAxQGRldjUwMC5vbm1pY3Jvc29mdC5jb20iLCJ1dGkiOiIyd2xpZnJ5dDRraVBNbWZLclkwR0FBIiwidmVyIjoiMS4wIiwid2lkcyI6WyI5Yjg5NWQ5Mi0yY2QzLTQ0YzctOWQwMi1hNmFjMmQ1ZWE1YzMiLCI2MmU5MDM5NC02OWY1LTQyMzctOTE5MC0wMTIxNzcxNDVlMTAiLCJiNzlmYmY0ZC0zZWY5LTQ2ODktODE0My03NmIxOTRlODU1MDkiXSwieG1zX2NjIjpbIkNQMSJdLCJ4bXNfc3NtIjoiMSIsInhtc19zdCI6eyJzdWIiOiJKZmdYYk85bk94UkVTLUNKczJscDBfd29HaXpWUUlfMzB0cXgzR2ZtajZJIn0sInhtc190Y2R0IjoxNjAyNTcyMzQyfQ.fHmA1eBJW7X6CPtcgd0XJv1RLUW0Q1uB8RI0lcUeXZKg_O4fKcVevsgQ1LWa3GgTUtKnjYdE-y7Ma4lS7V5i3Y1bGKzmvH56h_RsxaP29QpsneIFbYiuVxUol711kgBeL_U24byGYf_geXhlVtCcQoZIcPklLJr-3wdflpQf7FGzkOwUrP-slTdHkar-H-nbj3y_uuAoLgsAxQtyd0OvcYaXaOZ0_gKw7InR-NwE_RbNsur9HFFYn1q6h0vWNShc9bMt-0r7JVc1GoVigm-xYCY_JxFY8qcyETSLMX-i0BzyhSXP-DZwrfTFVuKKblX9Eju0QwVCQX7KZXwoO3W8Vg";
    var authenticationProvider = new BaseBearerTokenAuthenticationProvider(new TokenProvider(accessToken));
    var graphClient = new GraphServiceClient(authenticationProvider);

    try
    {
        using (Stream userPhotoStream = await graphClient.Me.Photo.Content.GetAsync())
        {
            if (userPhotoStream != null)
            {
                // Convert photo content to Base64 string
                byte[] photoBytes;
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    await userPhotoStream.CopyToAsync(memoryStream);
                    photoBytes = memoryStream.ToArray();
                }

                string base64String = Convert.ToBase64String(photoBytes);
                Console.WriteLine($"base64String : {base64String}");

            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error occurred: {ex.Message}");
    }
}

public class TokenProvider : IAccessTokenProvider
{
    private readonly string _accessToken;

    public TokenProvider(string accessToken)
    {
        _accessToken = accessToken;
    }

    public AllowedHostsValidator AllowedHostsValidator => throw new NotImplementedException();

    public Task<string> GetAuthorizationTokenAsync(Uri requestUri, Dictionary<string, object>? additionalAuthenticationContext = null, CancellationToken cancellationToken = default)
    {
        return Task.FromResult(_accessToken);
    }
}
