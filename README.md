# MyNotes
##### Pre build event to copy file
xcopy "$(ProjectDir)Program.cs" "$(OutDir)" /Y


#### AWS Deploy
C:\Program Files (x86)\AWS Tools\Deployment Tool>awsdeploy -v C:\publish\files\C01.txt

#### AWS Redeploy
C:\Program Files (x86)\AWS Tools\Deployment Tool>awsdeploy -r C:\publish\files\C01.txt



https://github.com/Vanlightly/Taskling.NET

```c#
var conditions = groups.Aggregate(new List<ConditionGroup>(), (conditions, group) =>
                {
                    conditions.AddRange(JsonConvert.DeserializeObject<List<ConditionGroup>>(group.Conditions));
                    return conditions;
                }); 


   
   
### Request the permissions from a directory admin

https://docs.microsoft.com/en-us/azure/active-directory/develop/v2-permissions-and-consent#request-the-permissions-from-a-directory-admin                
                
                
https://login.microsoftonline.com/common/adminconsent?client_id={client-id}
