
using AdressBook.Shared.Interfaces;
using AdressBook.Shared.Models;
using AdressBook.Shared.Services;

namespace AdressBook.Tests;

public class ContactBookServices_Tests
{

    [Fact]
    public void AddContactToList_ShouldAddOneContactToList_ThenReturnTrue()
    {
        // Arrange: Här skapas alla förberedelser för det vi ska testa
        // skapa en användare
        ContactPerson person = new ContactPerson();

        // Act: Här är det vi ska göra, alltså lägga till en person
        IContactBookServices contactBookServices = new ContactBookServices();

        var result = contactBookServices.AddContactToList(person);
        // Assert: vad väntar vi oss att få för resultat, kan göra flera olika 
        // jämförelser för att se om testet har lyckats eller inte

        Assert.True(result);
    }

    [Fact]
    public void DeleteContactByEmailFromList_ShouldDeleteContactFromList_ThenReturnTrue()
    {
        IContactBookServices contactBookServices = new ContactBookServices();
        ContactPerson person = new ContactPerson();
        contactBookServices.GetAllContactsFromList(); //hämta listan för att kunna ta bort en person

        bool result = contactBookServices.DeleteContactFromList(person.Email);

        Assert.True(result);
    }

    [Fact]
    public void GetAllContactsFromList_ShouldGetListOfAllContacts_ThenReturnList()
    {
        IContactBookServices contactBookServices = new ContactBookServices();
        ContactPerson person = new ContactPerson();
        contactBookServices.AddContactToList(person);

        IEnumerable<ContactPerson> contacts = contactBookServices.GetAllContactsFromList();

        Assert.NotNull(contacts);
    }

    [Fact]
    public void GetOneContactFromListByEmail_ShouldGetContactInformationFromList_TheReturnContactInList()
    {
        IContactBookServices contactBookServices = new ContactBookServices();
        ContactPerson person = new ContactPerson();
        contactBookServices.GetContactPersonByEmail(person.Email);

        IEnumerable<ContactPerson> ContactToFind = contactBookServices.GetAllContactsFromList();

        Assert.NotNull(ContactToFind);
    }
}
