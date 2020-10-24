using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FileReader
{
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
