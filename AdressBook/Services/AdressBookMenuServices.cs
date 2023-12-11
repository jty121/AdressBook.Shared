using AdressBook.Shared.Interfaces;
using AdressBook.Shared.Services;
namespace AdressBook.Services;
public class AdressBookMenuServices
{

    private readonly IContactBookServices _contactBookServices = new ContactBookServices();
}
