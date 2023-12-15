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
// sedan kan man gå vidare med Integrationstest för att kontrollera att dessa delar fungerar korrekt ihop. Då behöver man "mocka" enhetstesterna
// för att simulera att allt fungerar som vi förväntar oss. 
// Mock är ett testverktyg, använder sig av Interfaces