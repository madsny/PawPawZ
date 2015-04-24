# PawPaw

![image](https://ci.appveyor.com/api/projects/status/github/madsny/PawPaw)

Running the web demo: 
- you have sqlexpress running locally: create a empty database named 'PawPaw'
- you don't have sqlexpress: point the connection string to some other empty database. The user must be able to create tables

VS + F5 gogo 

## Bygging lokalt

Prosjektet benytter Node med hjelp av Gulp for kompilering av LESS og js. Sørg derfor å ha node installert lokalt på utviklermaskinen.
Via (power)shell, gå til mappen PawPaw.Web og skriv
npm install
gulp watch
CSS og JS vil da bundles og legges i PawPaw.Web/public/js og PawPaw.Web/public/css.
