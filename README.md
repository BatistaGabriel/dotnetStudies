# dotnetStudies

## Docker
This command will create the mongo container that we are going to use into the project

```
docker run -d --rm --name mongo -p 27017:27017 -v monodbdata:/data/db mongo

-d          -> used to don't keep being attached to the docker process all the time.
--rm        -> used to once we stop running the container it gets deleted
--name      -> used to specify the name of the container
-p          -> used to specify a port to talk to mongodb server
27017:27017 -> the first port is used to reach mongoDB container; the second one is used to get mapped into the internal mongoDB server
-v          -> used to specify the volume (how we are going to store the database files mongoDB will be using)
mongo       -> the name of the docker image we want to run

---

docker ps

ps          -> used to display on terminal all the running containers
```

To run a docker-compose file you first need to navigate to the folder where that file is located, and then run the following command:

```
docker-compose up -d

-d 		-> run in detached mode, which means the output should not be fully displayed.
```

## VS Code
By default VS Code will open a browser to you once you hit F5 to run the project. In order to don't do that you will need to go to:

**.vscode/launch.json**

and inside that file you will search for the section '*serverReadyAction*'  that looks like this one:

```
"serverReadyAction": {
	"action": "openExternally",
	"pattern": "\\bNow listening on:\\s+(https?://\\S+)"
},
```

Go ahead and remove it! Now your project will run but without opening the browser.

## Postman
In order to test the routes without using only the swagger page you can use postman, here is the generated collection that you can use:

```
{"info":{"_postman_id":"b57e71df-9805-43dd-8413-527cda023d2d","name":"Play.Catalog.Service","schema":"https://schema.getpostman.com/json/collection/v2.1.0/collection.json"},"item":[{"name":"items","item":[{"name":"{id}","item":[{"name":"/items/:id","request":{"method":"GET","header":[],"url":{"raw":"{{baseUrl}}/items/:id","host":["{{baseUrl}}"],"path":["items",":id"],"variable":[{"key":"id","value":"urn:uuid:b671e164-2474-685b-9a67-5855c3469fb1","description":"(Required) "}]}},"response":[{"name":"Success","originalRequest":{"method":"GET","header":[],"url":{"raw":"{{baseUrl}}/items/:id","host":["{{baseUrl}}"],"path":["items",":id"],"variable":[{"key":"id"}]}},"status":"OK","code":200,"_postman_previewlanguage":"json","header":[{"key":"Content-Type","value":"application/json"}],"cookie":[],"body":"{\n \"id\": \"urn:uuid:d03a6af8-6566-3610-fb5f-c0879b3fe289\",\n \"name\": \"id dolore\",\n \"description\": \"cillum fugiat\",\n \"price\": 79804906.24753204,\n \"createdDate\": \"1970-01-26T08:56:48.684Z\"\n}"}]},{"name":"/items/:id","request":{"method":"PUT","header":[{"key":"Content-Type","value":"application/json"}],"body":{"mode":"raw","raw":"{\n    \"name\": \"exercitation qui ullamco magna dolore\",\n    \"description\": \"nisi sit magna\",\n    \"price\": -40742614.5247491\n}"},"url":{"raw":"{{baseUrl}}/items/:id","host":["{{baseUrl}}"],"path":["items",":id"],"variable":[{"key":"id","value":"urn:uuid:b671e164-2474-685b-9a67-5855c3469fb1","description":"(Required) "}]}},"response":[{"name":"Success","originalRequest":{"method":"PUT","header":[],"body":{"mode":"raw","raw":"{\n    \"name\": \"exercitation qui ullamco magna dolore\",\n    \"description\": \"nisi sit magna\",\n    \"price\": -40742614.5247491\n}"},"url":{"raw":"{{baseUrl}}/items/:id","host":["{{baseUrl}}"],"path":["items",":id"],"variable":[{"key":"id"}]}},"status":"OK","code":200,"_postman_previewlanguage":"text","header":[{"key":"Content-Type","value":"text/plain"}],"cookie":[],"body":""}]},{"name":"/items/:id","request":{"method":"DELETE","header":[],"url":{"raw":"{{baseUrl}}/items/:id","host":["{{baseUrl}}"],"path":["items",":id"],"variable":[{"key":"id","value":"urn:uuid:b671e164-2474-685b-9a67-5855c3469fb1","description":"(Required) "}]}},"response":[{"name":"Success","originalRequest":{"method":"DELETE","header":[],"url":{"raw":"{{baseUrl}}/items/:id","host":["{{baseUrl}}"],"path":["items",":id"],"variable":[{"key":"id"}]}},"status":"OK","code":200,"_postman_previewlanguage":"text","header":[{"key":"Content-Type","value":"text/plain"}],"cookie":[],"body":""}]}]},{"name":"/items","request":{"method":"GET","header":[],"url":{"raw":"{{baseUrl}}/items","host":["{{baseUrl}}"],"path":["items"]}},"response":[{"name":"Success","originalRequest":{"method":"GET","header":[],"url":{"raw":"{{baseUrl}}/items","host":["{{baseUrl}}"],"path":["items"]}},"status":"OK","code":200,"_postman_previewlanguage":"json","header":[{"key":"Content-Type","value":"application/json"}],"cookie":[],"body":"[\n {\n  \"id\": \"urn:uuid:d29d5d0c-ad4e-8f66-4c7a-65d2a4ab9e26\",\n  \"name\": \"amet Excepteur\",\n  \"description\": \"commodo et est velit in\",\n  \"price\": 22747176.855057567,\n  \"createdDate\": \"1945-09-16T18:17:31.172Z\"\n },\n {\n  \"id\": \"b08b9043-5618-e873-e8f0-fbd1554787fe\",\n  \"name\": \"sunt dolore\",\n  \"description\": \"esse\",\n  \"price\": -52609391.80679251,\n  \"createdDate\": \"1970-03-08T08:32:26.802Z\"\n }\n]"}]},{"name":"/items","request":{"method":"POST","header":[{"key":"Content-Type","value":"application/json"}],"body":{"mode":"raw","raw":"{\n    \"name\": \"exercitation qui ullamco magna dolore\",\n    \"description\": \"nisi sit magna\",\n    \"price\": -40742614.5247491\n}"},"url":{"raw":"{{baseUrl}}/items","host":["{{baseUrl}}"],"path":["items"]}},"response":[{"name":"Success","originalRequest":{"method":"POST","header":[],"body":{"mode":"raw","raw":"{\n    \"name\": \"exercitation qui ullamco magna dolore\",\n    \"description\": \"nisi sit magna\",\n    \"price\": -40742614.5247491\n}"},"url":{"raw":"{{baseUrl}}/items","host":["{{baseUrl}}"],"path":["items"]}},"status":"OK","code":200,"_postman_previewlanguage":"json","header":[{"key":"Content-Type","value":"application/json"}],"cookie":[],"body":"{\n \"id\": \"urn:uuid:d03a6af8-6566-3610-fb5f-c0879b3fe289\",\n \"name\": \"id dolore\",\n \"description\": \"cillum fugiat\",\n \"price\": 79804906.24753204,\n \"createdDate\": \"1970-01-26T08:56:48.684Z\"\n}"}]}]}],"event":[{"listen":"prerequest","script":{"type":"text/javascript","exec":[""]}},{"listen":"test","script":{"type":"text/javascript","exec":[""]}}],"variable":[{"key":"baseUrl","value":"https://localhost:5001"}]}
```

To beautify the minified JSON above just copy it and search for a JSON beautifier like https://codebeautify.org/jsonviewer and do the beautify process.

## Nuget
In order to generate the nuget package you can do it using the .Net cli by the following coomand:

```
dotnet pack -o ..\..\..\packages\

-o 	-> specify the destination of the generated nuget package

```

To "tell" nuget where to find packages we can use the following command line:

```
dotnet nuget add source <PACKAGES LOCATION> -n PlayEconomy

-n 	-> specify a name for the source reference
```