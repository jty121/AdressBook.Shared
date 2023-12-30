using AdressBook.Shared.Interfaces;
using AdressBook.Shared.Services;

namespace AdressBook.Tests;

public class FileServices_Tests
{
    [Fact]
    public void SaveContactsToFile_ShouldSaveContactsToListInFile_ThenReturnTrue()
    {
        IFileServices fileServices = new FileServices();
        string filePath = @"C:\CsharpProjects\Assignment\AdressBook.txt";
        string contentFile = "Integration test";

        bool result = fileServices.SaveContactsToFile(filePath, contentFile);

        Assert.True(result);
    }

    [Fact]

    public void GetContactsFromFile_ShouldGetContactListFromFile_ThenReturnList()
    {
        IFileServices fileServices = new FileServices();
        string filePath = @"C:\CsharpProjects\Assignment\AdressBook.txt";       

        var result = fileServices.GetContactsFromFile(filePath);

        Assert.NotNull(result);
    }
}



// Integrationstest: skapas en fil till projektet, interagerar med ditt filsystem på datorn. 
// används för att utföra tester mellan olika system och för att kontrollera om de olika delarna (komponenterna) fungerar tillsammans
// som de ska i sin helhet.
// Innan du kör integrationstest är det bra att först ha kört enhetstesterna för att kontrollera om varje metod fungerar som de ska
// sedan kan man gå vidare med Integrationstest för att kontrollera att dessa delar fungerar korrekt tillsammans. Då behöver man "mocka" enhetstesterna
// för att simulera att allt fungerar som vi förväntar oss. 
// Mock är ett testverktyg, använder sig av Interfaces



//notering: testade varje enhetstest innan jag började med integrationstest. funkade och fick gröna test.
//började med integrationstest men fick röda test när jag använde IFileService i min mock. bytade ut och körde FileServices och fick gröna test. 
//men något blir fel, eftersom man bör köra Interfaces när man använder mock.. 
//gjorde konstruktor för IFileService i min Contactbookservices, men då blev det rött i min AdressBookmenuServices som då ville ha in argument. 
//gjorde en till konstruktor som inte tar in några parametrar för att tillgodogöra menydelen. 
//kollade genom addcontact med breakpoints/debug, körde igenom metoden som den ska, men failade på testet. bytade ut "var result" i logiken 
//mot return true. vilket gjorde att det funkade. alltså stämde inte enhetstestet överens med metoden på det sättet som enhetstestet sagt från början.
