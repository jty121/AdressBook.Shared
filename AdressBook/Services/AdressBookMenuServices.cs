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
            Console.WriteLine(
                "\n1. Add a contact" +
                "\n2. Show all contacts" + 
                "\n3. Search for a contact" +
                "\n4. Delete contact" +
                "\n5. Exit");
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
        //instansiering av ny person från klassen ContactPerson, ger tillgång till properties för att lagra värden i variabeln contactPerson. 
        ContactPerson contactPerson = new ContactPerson();

        MenuTitle("*** Add a contact to your address book ***");
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
        MenuTitle("All contacts in Address Book");
        
        IEnumerable<ContactPerson> contacts = _contactBookServices.GetAllContactsFromList();
        //instansiering av IEnumerable lista av klass ContactPerson och anropar metoden GetAllContactsFromList i contactBookServices.
            foreach (var contact in contacts)
                {
                if (contact is ContactPerson)
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
        MenuTitle("Search for contact in the Address book");
        Console.WriteLine("Enter contacts email to view information: ");

        string findContactByEmail = Console.ReadLine()!;
        var contact = _contactBookServices.GetContactPersonByEmail(findContactByEmail);

            if(contact != null)
            {
                Console.WriteLine();
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
        MenuTitle("Delete contact from Address book");
        Console.WriteLine("Enter email of contact to remove: ");
        string deleteContactByEmail = Console.ReadLine()!;

        var deleteContact = _contactBookServices.DeleteContactFromList(deleteContactByEmail);

            if (!string.IsNullOrEmpty(deleteContactByEmail)) 
            {

                if(deleteContact)
                {
                    Console.WriteLine();
                    Console.WriteLine($"contact with email: {deleteContactByEmail} deleted successfully!");
                }
                else
                {
                    Console.WriteLine("Couldn´t find any contact, please try again!");
                }
            }
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    private void ShowExit()
    {
        MenuTitle("Exit Address Book");
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
    private void MenuTitle(string title)
    {
        Console.Clear();
        Console.WriteLine($"*** {title} ***");
        Console.WriteLine();
    }
    
}
