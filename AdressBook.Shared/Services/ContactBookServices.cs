using AdressBook.Shared.Interfaces;
using AdressBook.Shared.Models;
using Newtonsoft.Json;
using System.Diagnostics;

namespace AdressBook.Shared.Services;

public class ContactBookServices : IContactBookServices
{

    private static List<ContactPerson> _contacts = [];
    private readonly IFileServices _fileServices = new FileServices();
    private readonly string _filePath = @"C:\CsharpProjects\Assignment\AdressBook.json";

    public ContactBookServices(IFileServices fileServices)
    {
        _fileServices = fileServices;
    }

    public ContactBookServices() 
    {
        _fileServices = new FileServices();
    }

    //sätt sökväg här för att säkerställa att när du använder dig av _filePath så kommer det alltid att bli samma i resterande kod. 
    //går att ha flera olika sökvägar om man har olika objekt som ska sparas in i separata listor. 

    public bool AddContactToList(ContactPerson contactPerson)
    {
        try
        {
            if(!_contacts.Any(x => x.Email == contactPerson.Email))
            {
                _contacts.Add(contactPerson);

                string json = JsonConvert.SerializeObject(_contacts, new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All,
                });
                var result = _fileServices.SaveContactsToFile(_filePath, json);
                return result;
            }

        }
        catch (Exception ex) { Debug.WriteLine("ContactBookServices - AddContactToList::" + ex.Message); }
        return false;
    }


    public bool DeleteContactFromList(string email)
    {
        try
        {
            var contactToDelete = _contacts.Find(x => x.Email == email);

            if (contactToDelete != null)
                {
                    _contacts.Remove(contactToDelete);
                    string json = JsonConvert.SerializeObject(_contacts, new JsonSerializerSettings
                    {
                        TypeNameHandling = TypeNameHandling.All,
                    });
                    var result = _fileServices.SaveContactsToFile(_filePath, json);
                    return result;
                // return result ger tillbaka den uppdaterade listan OM kontakten tagits bort
            }
        }
        catch (Exception ex) { Debug.WriteLine("ContactBookServices - DeleteContactFromFile::" + ex.Message); }
        return false;
    }


    public IEnumerable<ContactPerson> GetAllContactsFromList()
    {
        try
        {
            var contacts = _fileServices.GetContactsFromFile(_filePath);
            if(!string.IsNullOrEmpty(contacts))
            {
                _contacts = JsonConvert.DeserializeObject<List<ContactPerson>>(contacts)!;
                return _contacts;
            }
               
        }
        catch (Exception ex) { Debug.WriteLine("ContactBookServices - GetAllContactsFromList::" + ex.Message); }
        return null!;
        //sätt meddelande i din exception del för att lättare kunna felsöka om något går fel, skrivs ut i output
        //lättare att kolla om du får ett error-message, då står det i vilken del av din kod som felet uppstått i
    }


    public IContactPerson GetContactPersonByEmail(string email)
    {
        try
        {
            if(email != null)
            {
                var contact = _fileServices.GetContactsFromFile(_filePath);
                var contactToFind = _contacts.Find(x =>x.Email == email);

                if( contactToFind != null)
                {
                    _contacts = JsonConvert.DeserializeObject<List<ContactPerson>>(contact)!;
                    return contactToFind;
                    //om man inte har en lista som är av ett Interface, behövs inte settings delen och typenamehandling? 
                    //Json kan inte hantera Interfaces 
                }
            }
        }
        catch (Exception ex) { Debug.WriteLine("ContactBookServices - GetContactPersonByEmail::" + ex.Message); }
        return null!; 
    }
}
