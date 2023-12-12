using AdressBook.Shared.Interfaces;
using AdressBook.Shared.Models;
using AdressBook.Shared.Services;
namespace AdressBook.Services;
public class AdressBookMenuServices
{

    private readonly IContactBookServices _contactBookServices = new ContactBookServices();
  

    public void ShowMainMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("*** Addressbook ***");
            Console.WriteLine();
            Console.WriteLine("Choose an option from the menu");
            Console.WriteLine("1. Add a contact");
            Console.WriteLine("2. Show all contacts");
            Console.WriteLine("3. Search for a contact");
            Console.WriteLine("4. Delete contact from the addressbook");
            Console.WriteLine("5. Exit");
            Console.WriteLine();
            string option = Console.ReadLine()!;

            switch(option) 
            {
                case "1":
                    AddContact();
                    break;
                case "2":
                    ShowAllContacts(); 
                    break;
                case "3":
                    ShowContact();
                    break;
                case "4":
                    DeleteContact();
                    break;
                case "5":
                    ShowExit();
                    break;
                default: Console.WriteLine("Invalid option, press any key to continue..");
                    break;                  
            }        
        }
    }

    private void AddContact()
    {
        ContactPerson contactPerson = new ContactPerson();

        Console.WriteLine("Enter firstname: ");
        contactPerson.FirstName = Console.ReadLine()!;

        Console.WriteLine("Enter lastname: ");
        contactPerson.LastName = Console.ReadLine()!;

        Console.WriteLine("Enter email: ");
        contactPerson.Email = Console.ReadLine()!;

        Console.WriteLine("Enter Adress: ");
        contactPerson.Address = Console.ReadLine()!;

        Console.WriteLine("Enter Phonenumber: ");
        contactPerson.PhoneNumber = Console.ReadLine()!;

        _contactBookServices.AddContactToList(contactPerson);
        Console.ReadKey();
    }

    private void ShowAllContacts()
    {
        var contacts = _contactBookServices.GetAllContactsFromList();
        foreach (var contact in contacts)
        {
            if(contact is ContactPerson)
            {
                Console.WriteLine($"{contact.FirstName}, {contact.LastName}, {contact.Email}, {contact.Address}, {contact.PhoneNumber}");
            }
            else
            {
                Console.WriteLine("Couldn´t find any information, are you sure you entered right email?");
                Console.WriteLine("Press any key to continue...");
            }
        }
        Console.ReadKey();
    }

    private void ShowContact()
    {
        Console.WriteLine("Enter email of contact to get full contactinformation: ");
        string findContactByEmail = Console.ReadLine()!;
        var contact = _contactBookServices.GetContactPersonByEmail(findContactByEmail);

        if(contact != null)
        {
            Console.WriteLine($"{contact.FirstName}, {contact.LastName}, {contact.Email}, {contact.Address}, {contact.PhoneNumber}");
        }
        else
        {
            Console.WriteLine("Couldn´t find any information, are you sure you entered right email?");
            Console.WriteLine("Press any key to continue...");
        }

        Console.ReadKey();
    }

    private void DeleteContact()
    {
        Console.WriteLine("Enter email of contact you want to delete from the adressbook: ");
        string deleteContactByEmail = Console.ReadLine()!;

        var deleteContact = _contactBookServices.DeleteContactFromList(deleteContactByEmail);

        if (!string.IsNullOrEmpty(deleteContactByEmail)) 
        {

            if(deleteContact)
            {
                Console.WriteLine($"contact with email: {deleteContactByEmail} is deleted from list!");
            }
            else
            {
                Console.WriteLine("Couldn´t find any contact with that email in list!");
            }
        }
        Console.ReadKey();
    }
    private void ShowExit()
    {
        Console.Write("Are you sure you want to quit? y/n: ");
        var option = Console.ReadLine()!;

        if (option.ToLower() == "y")
        {
            Environment.Exit(5);
        }
        else option.Equals("n", StringComparison.CurrentCultureIgnoreCase);
        {
            ShowMainMenu();
        }
    }
}
