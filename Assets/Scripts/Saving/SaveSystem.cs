using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem 
{
    public static void SaveStats (PlayerStats stats)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Stats.txt";
        FileStream stream = new FileStream(path, FileMode.Create);
        SaveFile file = new SaveFile(stats);
        formatter.Serialize(stream, file);
        stream.Close();
    }

    public static SaveFile LoadStats()
    {
        string path = Application.persistentDataPath + "/Stats.txt";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SaveFile file = (SaveFile)formatter.Deserialize(stream);
            stream.Close();
            return file;
        }
        else
        {
            Debug.LogError("save file not found in" + path);
            return null;
        }
    }

    public static void SaveOptions (Options options)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Options.txt";
        FileStream stream = new FileStream(path, FileMode.Create);
        OptionsFile file = new OptionsFile(options);
        formatter.Serialize(stream, file);
        stream.Close();
    }

    public static OptionsFile LoadOptions()
    {
        string path = Application.persistentDataPath + "/Options.txt";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            OptionsFile file = (OptionsFile)formatter.Deserialize(stream);
            stream.Close();
            return file;
        }
        else { return null; }
        
    }
}
