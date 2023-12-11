using AdressBook.Shared.Interfaces;
using AdressBook.Shared.Services;
namespace AdressBook.Services;
public class AdressBookMenuServices
{

    private readonly IContactBookServices _contactBookServices = new ContactBookServices();
    /// <summary>
    /// Main menu, implement methods/logic from AdressBook.shared
    /// </summary>

    public void ShowMainMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("*** Adressbook ***");
            Console.WriteLine();
            Console.WriteLine("Choose an option from the menu");
            Console.WriteLine("1. Add a contact");
            Console.WriteLine("2. Show all contacts");
            Console.WriteLine("3. Search for a contact");
            Console.WriteLine("4. Delete a contact from the adressbook");
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

    }

    private void ShowAllContacts()
    {

    }

    private void ShowContact()
    {

    }

    private void DeleteContact()
    {

    }
    private void ShowExit()
    {

    }
}
