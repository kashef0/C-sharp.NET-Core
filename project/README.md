# Lagerhanteringsapplikation

## Inledning
Välkommen till lagerhanteringsapplikationen! Detta projekt är utvecklat i C# och .NET med syftet att skapa en användarvänlig applikation för att hantera produkter, kategorier och transaktioner. Med applikationen kan användare enkelt spåra och organisera lagerstatus, produktinformation och transaktioner.

## Bakgrund
Under flera år har jag arbetat inom lager och butik hantering och har sett de utmaningar som företag står inför när det gäller att effektivt övervaka sina produkter. Denna applikation syftar till att erbjuda en lösning som inte bara gör det enklare att hantera produkter och kategorier, utan även ger en möjlighet för mig att utveckla mina färdigheter inom mjukvaruutveckling.

## Funktioner
Applikationen erbjuder flera funktioner:
- **Lägg till, visa, uppdatera och ta bort produkter**: Hantera produktinformation enkelt.
- **Skapa och hantera kategorier**: Organisera produkter i olika kategorier.
- **Registrera transaktioner**: Håll koll på inköp och försäljningar.
- **Visa en lista över tidigare transaktioner**: Spåra historiska data.
- **Sök transaktioner**: Hitta specifika transaktioner baserat på kassörens namn eller datumintervall.

## Struktur
Applikationen är organiserad i flera moduler:
- **Modeller**: Inkluderar klasser för `Product`, `Category` och `Transaction`.
- **Repository-mapp**: Hanterar CRUD-operationer för produkter, kategorier och transaktioner.
- **Methods-mapp**: Innehåller logik för hur användaren interagerar med applikationen.
- **Validering**: Säkerställer att användarinmatning är korrekt.

## Teknologier
- **Språk**: C#
- **Ramverk**: .NET
- **Verktyg**: ConsoleTables (för snygg presentation av data)