using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


public class SaveLoad : MonoBehaviour
{
    public static GameObject curFrame;
    public static List<Node> savedAnim = new List<Node>();

    public static void Save()
    {
        Node curNode=new Node();
        BinaryFormatter txt = new BinaryFormatter();
        print(Application.persistentDataPath);
        FileStream file = File.Create(Application.persistentDataPath + "/savedanim.txt");
        txt.Serialize(file, SaveLoad.savedAnim);
        file.Close();
    }
    public static void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/savedanim.txt"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/savedanim.txt", FileMode.Open);
            SaveLoad.savedAnim = (List<Node>)bf.Deserialize(file);
            file.Close();
        }
    }
}


