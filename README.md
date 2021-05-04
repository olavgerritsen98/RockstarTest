# RockstarTest
 Music library made for Rockstars

Welkom bij mijn music library!
In mijn opdracht heb ik verschillende keuzes gemaakt en ik zal in deze Readme uitleggen waarom en welke keuzes ik heb gemaakt.

Allereerst is er een ASP.NET Web API project aangemaakt.

Vervolgens heb ik een MVC structuur gehandhaafd in dit project om zo de business logica te scheiden. Ondanks dat er geen views zijn kunnen die toegevoegd worden als een andere Rockstar verder gaat met deze opdracht!

In de controllers worden alle API calls afgevangen die vervolgens in een Repository afgehandeld worden door een connectie met de database. Ook wordt er bij bijvoorbeeld de Post methode gecheckt of de modelstate correct is. Zo wordt er gebruik gemaakt van de Modelstate.

Zoals ik al zei is het Repository pattern toegepast. Dit is gedaan om zo de logica wat betreft de database te scheiden. Dit is gedaan zodat als er iets aangepast moet worden het duidelijk is welke logica waar staat.

Verder is er nog een Models folder waar de objecten zoals Artiesten in staan. Dit zijn overigens ook de tables die in de database staan. In deze classes is er Data Annotation gebruikt voor het valideren van de data.

Voor het afvangen van de routes wordt er een WebAPIConfig gebruikt. Deze zal kijken welke route er wordt aangeroepen en dan de juiste controller en de juiste methode koppelen zodat de juiste informatie wordt teruggegeven.

Voor het aanmaken van de database is entityframework gebruikt die een context class heeft. Via deze class kan de database aangepast worden.
Als de Models worden aangepast dan zal er een nieuwe migration moeten worden uitgevoerd door het command: add-migration {naam}
Hierdoor zal er een script gegenereerd worden dat uitgevoerd wordt als het command: update-database wordt aangeroepen.
Als deze commands na elkaar worden aangeroepen dan zal de database geupdate worden. 
Vergeet niet de connectionstring aan te passen!

Voor het parsen van de JSON is er een JSONParser geschreven. Hierin wordt Linq gebruikt om makkelijk queries te schrijven en zo de database te vullen met nummers die het genre Metal bevatten en voor het jaar 2016 zijn uitgebracht.

Ik heb als laatste nog een aantal unit tests geschreven om zo de functionaliteit van de repositories te testen. Hierin wordt Moq gebruikt om zo de classes los te kunnen testen.
Wegens een gebrek aan tijd heb ik niet alle tests kunnen schrijven die ik had gewild. Sommige setup puntjes hebben langer geduurd dan verwacht.
Ik heb hierdoor ook geen querystring search kunnen toevoegen waardoor de R in CRUD kan worden uitgevoerd zonder de querystring dus op id en alle.

Er zijn de volgende calls die kunnen worden aangeroepen:

GET: https://localhost:44337/api/Songs: Deze call zal alle songs weergeven in JSON.
GET: https://localhost:44337/api/Artists: Deze call zal alle artists weergeven in JSON.

GET: https://localhost:44337/api/Songs/{id}: Deze call zal een specifieke song weergeven in JSON.
GET: https://localhost:44337/api/Artists/{id}: Deze call zal een specifieke artist weergeven in JSON.

PUT: https://localhost:44337/api/Songs/{id}: Deze call zal een specifieke song updaten, vergeet niet alle required velden in te vullen!
PUT: https://localhost:44337/api/Artists/{id}: Deze call zal een specifieke artist updaten, vergeet niet alle required velden in te vullen!

POST: https://localhost:44337/api/Songs: Deze call zal een song toevoegen aan de database mits deze aan de eisen voldoet.
POST: https://localhost:44337/api/Artists: Deze call zal een artist toevoegen aan de database mits deze aan de eisen voldoet.

DELETE: https://localhost:44337/api/Songs/{id}: Deze call zal een specifieke song verwijderen.
DELETE: https://localhost:44337/api/Artists/{id}: Deze call zal een specifieke song verwijderen.
