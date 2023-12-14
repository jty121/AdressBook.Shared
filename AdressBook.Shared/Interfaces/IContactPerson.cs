namespace AdressBook.Shared.Interfaces;

/// <summary>
/// Kontrakt för vilka egenskaper/properties som definierar och ska ingå för en kontaktperson
/// </summary>
public interface IContactPerson
{
    string FirstName { get; set; }
    string LastName { get; set; }
    string Email { get; set; }
    string PhoneNumber { get; set; }
    string Address { get; set; }

}
