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
            Console.WriteLine("*** The Address book ***");
            Console.WriteLine();
            Console.WriteLine("Choose an option from the menu");
            Console.WriteLine("1. Add a contact");
            Console.WriteLine("2. Show all contacts");
            Console.WriteLine("3. Search for contact in address book");
            Console.WriteLine("4. Delete contact");
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
    // privata fält här, behöver bara kommas åt i den här klassen.
    private void AddContact()
    {
        //instansiering av ny person från klassen ContactPerson, ger tillgång till properties för att lagra värdena i variabel contactPerson. 
        ContactPerson contactPerson = new ContactPerson();
        Console.Clear();
        Console.WriteLine("*** Add a contact to your address book ***");
        Console.WriteLine();

        Console.WriteLine("Firstname: ");
        contactPerson.FirstName = Console.ReadLine()!;

        Console.WriteLine("Lastname: ");
        contactPerson.LastName = Console.ReadLine()!;

        Console.WriteLine("Email: ");
        contactPerson.Email = Console.ReadLine()!;

        Console.WriteLine("Address: ");
        contactPerson.Address = Console.ReadLine()!;

        Console.WriteLine("Phonenumber: ");
        contactPerson.PhoneNumber = Console.ReadLine()!;

        _contactBookServices.AddContactToList(contactPerson);
        //anropa metoden i _contactBookServices för att lägga till en person, contactPerson är lokalt deklarerad variabel för att lagra värdena som matas in
        //och skicka med till metoden AddContactToList...

        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    private void ShowAllContacts()
    {   
        //instansiering av IEnumerable lista av klass ContactPerson och anropar metoden GetAllContactsFromList i contactBookServices.
        IEnumerable<ContactPerson> contacts = _contactBookServices.GetAllContactsFromList();
        foreach (var contact in contacts)
        {
            if(contact is ContactPerson)
            {
                Console.WriteLine("- " +$" {contact.FirstName}\n   {contact.LastName}\n   {contact.Email}\n   {contact.Address}\n   {contact.PhoneNumber}\n");
            }
            else
            {
                Console.WriteLine("Couldn´t find any information, please try again!");
            }
        }
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    private void ShowContact()
    {
        Console.Clear();
        Console.WriteLine("*** Search for contact in Address book ***");
        Console.WriteLine();
        Console.WriteLine("Enter contacts email to view information: ");
        string findContactByEmail = Console.ReadLine()!;
        var contact = _contactBookServices.GetContactPersonByEmail(findContactByEmail);

        if(contact != null)
        {
            Console.WriteLine("- " +$" {contact.FirstName}\n    {contact.LastName}\n   {contact.Email}\n   {contact.Address}\n   {contact.PhoneNumber}\n");
        }
        else
        {
            Console.WriteLine("Couldn´t find any information, please try again!"); 
        }
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    private void DeleteContact()
    {
        Console.Clear();
        Console.WriteLine("*** Delete contact from Address book ***");
        Console.WriteLine();
        Console.WriteLine("Enter email of contact to remove: ");
        string deleteContactByEmail = Console.ReadLine()!;

        var deleteContact = _contactBookServices.DeleteContactFromList(deleteContactByEmail);

        if (!string.IsNullOrEmpty(deleteContactByEmail)) 
        {

            if(deleteContact)
            {
                Console.WriteLine($"contact with email: {deleteContactByEmail} deleted!");
            }
            else
            {
                Console.WriteLine("Couldn´t find any contact with that email address, try again please!");
            }
        }
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    private void ShowExit()
    {
        Console.Clear();
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
