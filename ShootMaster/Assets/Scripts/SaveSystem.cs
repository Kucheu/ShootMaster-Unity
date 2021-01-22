using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SaveBestPoints(float points)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/gameStatus.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        Points data = new Points(points);

        formatter.Serialize(stream, data);
        stream.Close();
        Debug.Log("Save");  
    }

    public static Points LoadBestPoints()
    {
        string path = Application.persistentDataPath + "/gameStatus.fun";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            Debug.Log(stream);
            Points data = formatter.Deserialize(stream) as Points;
            stream.Close();

            
            return data;
        } 
        else
        {
            return null;
        }
        
    }
}
