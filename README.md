# PawPaw

![image](https://ci.appveyor.com/api/projects/status/github/madsny/PawPaw)

## Hvordan kjøre React-appen lokalt

### Oppsett av DB

**Hvis du har SQLExpress installert lokalt:**  
Opprett en ny tom database som du kaller *PawPaw*.

**Hvis du ikke har SQLExpress installert lokalt:**  
Endre connectionstring-en kalt *PawPaw* i `Web.config` under *PawPaw.IIS*-prosjektet til å peke på en annen tom database. Brukeren må ha rettigheter til å opprette tabeller.

### Bygging av frontend

Prosjektet benytter Node med hjelp av Gulp for kompilering av LESS og js. Sørg derfor å ha node installert lokalt på utviklermaskinen.  
Via (power)shell, gå til mappen PawPaw.Web og skriv  
`npm install` (hvis du får en feilmelding ala "Error: ENOENT, stat 'C:\Users...\AppData\Roaming\npm'", opprett en mappe `npm` under *Roaming*-mappen)  
`npm install gulp -g` (innstallerer Gulp globalt på maskinen)  
`gulp watch`  
CSS og JS vil da bundles og legges i *PawPaw.React/public/js* og *PawPaw.React/public/css*.  
Kjør `gulp watch` for å automatisk bygge på nytt ved endringer i js- eller less-filene.

### Kjøre prosjektet

* Sett *PawPaw.IIS* som "startup"-prosjekt
* Trykk F5
