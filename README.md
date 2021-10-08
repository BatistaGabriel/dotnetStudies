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