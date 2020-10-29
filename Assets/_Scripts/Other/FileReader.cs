using UnityEngine;

/// <summary>
/// This class reads the text of a given file and returns its content as a string.
/// </summary>
public class FileReader
{
    /// <summary>
    /// Reads the text of a given file
    /// </summary>
    /// <param name="fileName">The name of the file</param>
    /// <returns>The content of the file as a string</returns>
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
