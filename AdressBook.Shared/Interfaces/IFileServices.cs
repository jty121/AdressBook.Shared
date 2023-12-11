namespace AdressBook.Shared.Interfaces;

public interface IFileServices
{
    /// <summary>
    /// save and get contacts from file
    /// </summary>
    /// <param name="filePath">enter the filepath (c:\CsharpProjects\...</param>
    /// <returns>if file exists return contacts in list, else return false if failed</returns>
    /// 
    string GetContactsFromFile(string filePath);

    bool SaveContactsToFile (string filePath, string contacts);
}
