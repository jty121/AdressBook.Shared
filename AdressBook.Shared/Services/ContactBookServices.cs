using AdressBook.Shared.Interfaces;
using AdressBook.Shared.Models;
using Newtonsoft.Json;
using System.Diagnostics;

namespace AdressBook.Shared.Services;

public class ContactBookServices : IContactBookServices
{

    private static List<ContactPerson> _contacts = [];
    private readonly IFileServices _fileServices = new FileServices();


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
                var result = _fileServices.SaveContactsToFile(@"C:\CsharpProjects\Assignment\AdressBook.json", json);
                return result;
            }

        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
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
                    var result = _fileServices.SaveContactsToFile(@"C:\CsharpProjects\Assignment\AdressBook.json", json);
                    return result;
                // return result ger tillbaka den uppdaterade listan OM kontakten tagits bort
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return false;
    }


    public IEnumerable<ContactPerson> GetAllContactsFromList()
    {
        try
        {
            var contacts = _fileServices.GetContactsFromFile(@"C:\CsharpProjects\Assignment\AdressBook.json");
            if(!string.IsNullOrEmpty(contacts))
            {
                _contacts = JsonConvert.DeserializeObject<List<ContactPerson>>(contacts)!;
                return _contacts;
            }
               
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }


    public IContactPerson GetContactPersonByEmail(string email)
    {
        try
        {
            if(email != null)
            {
                var contact = _fileServices.GetContactsFromFile(@"C:\CsharpProjects\Assignment\AdressBook.json");
                var contactToFind = _contacts.Find(x =>x.Email == email);

                if( contactToFind != null)
                {
                    _contacts = JsonConvert.DeserializeObject<List<ContactPerson>>(contact)!;
                    return contactToFind;
                }
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!; 
    }


    public bool UpdateContactList(IEnumerable<IContactPerson> contactPersons)
    {
        try
        {
            return true;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return false;
    }
}
