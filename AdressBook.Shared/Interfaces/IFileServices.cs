namespace AdressBook.Shared.Interfaces;

public interface IFileServices
{
    string GetContactsFromFile(string filePath);
    /// <summary>
    /// get contacts from specified file
    /// </summary>
    /// <param name="filePath">enter the filepath (c:\CsharpProjects\...</param>
    /// <returns>if file exists return contacts in list, else return null if failed</returns>
    /// 


    bool SaveContactsToFile (string filePath, string contacts);
    /// <summary>
    /// save contacts to specified file
    /// </summary>
    /// <param name="filePath">enter the filepath (c:\CsharpProjects\...</param> 
    /// <param name="contacts">enter as a string, takes argument to save content to a list</param>
    /// <returns>if file exists return list of contact, else return false if failed </returns>
}
