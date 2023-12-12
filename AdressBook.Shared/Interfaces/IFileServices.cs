namespace AdressBook.Shared.Interfaces;

public interface IFileServices
{
    /// <summary>
    /// get contacts from specified file
    /// </summary>
    /// <param name="filePath">enter the filepath (c:\CsharpProjects\...</param>
    /// <returns>if file exists return contacts in list, else return false if failed</returns>
    /// 
    string GetContactsFromFile(string filePath);



    /// <summary>
    /// save contacts to specified file
    /// </summary>
    /// <param name="filePath">enter the filepath (c:\CsharpProjects\...</param> 
    /// <param name="contacts">contact information deklared as a string to be saved in a list</param>
    /// <returns>if file exists return list of contact, else return false if failed </returns>
    bool SaveContactsToFile (string filePath, string contacts);
}
