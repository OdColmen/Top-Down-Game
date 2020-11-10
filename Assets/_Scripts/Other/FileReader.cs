using UnityEngine;

// This class reads the text of a given file and returns its content as a string.
public class FileReader
{
    // Reads the text of a given file
    public string ReadFile(string fileName)
    {
        // Read file
        TextAsset textAsset = (TextAsset)Resources.Load(fileName, typeof(TextAsset));
        
        // Check if file was found
        if (textAsset == null)
        {
            Debug.LogError("File Not Found!");
        }

        // Load text
        string content = textAsset.text;

        // Return text
        return content;
    }
}
