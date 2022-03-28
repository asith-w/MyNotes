context.sp.web.regionalSettings.getInstalledLanguages()
                .then(x => {
                  console.log('==x==', x);
                })

              var currentPageId = context.spfxContex.pageContext.listItem.id;
              var currentListId = context.spfxContex.pageContext.list.id.toString();

              sp.web.lists
                .getById(currentListId)
                .items
                .getById(currentPageId)
                .select("Title", "FileLeafRef", "FileRef", "Description")
                .get()
                .then(w => {
                  console.log('==ww==', w);
                });

              context.spfxContex.spHttpClient.get(context.spfxContex.pageContext.web.absoluteUrl + `/_api/sitepages/pages(${currentPageId})?$select=Path,Version,Translations&$expand=Translations`
                , SPHttpClient.configurations.v1)

                .then((data: SPHttpClientResponse) => {
                  console.log('==response.json()==', data.json());
                });

           

              context.spfxContex.spHttpClient.get(context.spfxContex.pageContext.web.absoluteUrl + `/_api/sitepages/pages(${currentPageId})`
                , SPHttpClient.configurations.v1)
                .then((response) => {
                  response.json().then((responseJSON) => {
                    console.log(responseJSON);
                  }).catch((error) => {
                    console.warn(error);
                  });
                });
