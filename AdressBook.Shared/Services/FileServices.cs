using AdressBook.Shared.Interfaces;
using System.Diagnostics;

namespace AdressBook.Shared.Services;

public class FileServices : IFileServices
{
    public string GetContactsFromFile(string filePath)
    {
        try 
        { 
            if(File.Exists(filePath))
            {
                string json =  File.ReadAllText(filePath);
                return json;
            }

        }
        catch (Exception ex){ Debug.WriteLine(ex.Message); }
        return null!;
    }

    public bool SaveContactsToFile(string filePath, string contacts)
    {
        try
        {
            using var sw = new StreamWriter(filePath);
            sw.Write(contacts);
            return true;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return false;
    }
}
// string filePath talar om för metoden att "du kommer få en sökväg till platsen som filen ska sparas".
// string contacts skickar med något ihop med sökvägen som ska sparas in
