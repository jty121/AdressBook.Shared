using AdressBook.Shared.Models;
namespace AdressBook.Shared.Interfaces;
public interface IContactBookServices
    
{
    /// <summary>
    /// Add contact to a list
    /// </summary>
    /// <param name="contactPerson">enter as a string, refers to class ContactPerson</param>
    /// <returns>add a contact to list if it returns true, else return false if failed</returns>
    bool AddContactToList(ContactPerson contactPerson);



    /// <summary>
    /// Get a specified contact by email from list
    /// </summary>
    /// <param name="email">enter as a string, refers to object in class</param>
    /// <returns>if contact email exists return information about contact, else return null if failed</returns>
    IContactPerson GetContactPersonByEmail(string email);



    /// <summary>
    /// using a IEnumerable list to only get a readable list
    /// </summary>
    /// <returns>if list is not null or empty return list of contacts, else returns null if false</returns>
    IEnumerable<ContactPerson> GetAllContactsFromList();

    bool UpdateContactList(IEnumerable<IContactPerson> contactPersons);

    
    bool DeleteContactFromList(string email);
    /// <summary>
    /// Delete contact by typing in contacts email address
    /// </summary>
    /// <param name="email">enter as a string </param>
    /// <returns>if contact exists delete from list, else return false if failed</returns>
}
