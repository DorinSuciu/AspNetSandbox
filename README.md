# Dorin's sandbox project for backend course

name | value 
--- | ---
language | C#
database | postgres
deployed | https://asp--net--sandbox.herokuapp.com

## How to run in Docker from the commandline

Navigate to [AspNetSandbox](AspNetSandbox) directory

### Application screenshot

![alt text](https://github.com/DorinSuciu/AspNetSandbox/blob/master/app_ss.PNG)

### Build in container
```
docker build -t web_dorin .
```

to run

```
docker run -d -p 8081:80 --name asp--net--sandbox web_dorin
```

to stop container
```
docker stop asp--net--sandbox
```

to remove container
```
docker rm asp--net--sandbox
```

## Deploy to heroku

1. Create heroku account
2. Create application
3. Make sure application works locally in Docker


Login to heroku
```
heroku login
heroku container:login
```

Push container
```
heroku container:push -a asp--net--sandbox web
```

Release the container
```
heroku container:release -a asp--net--sandbox web
```