using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


public class SaveLoad : MonoBehaviour
{
    public static GameObject curFrame;
    //public static List<Node> savedAnim = new List<Node>();
    public static Node savedAnim;
    public static void Save()
    {
        Node curNode=new Node();
        BinaryFormatter bf = new BinaryFormatter();
        print(Application.persistentDataPath);
        FileStream file = File.Create(Application.persistentDataPath + "/savedanim.oi");
        bf.Serialize(file, curNode);
        file.Close();
    }
    public static void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/savedanim.oi"))
        {
            SaveAnimParam.countFrames = 0;//Количетсво фреймов анимации
            SaveAnimParam.pointsAndParents.Clear();
            SaveAnimParam.linesAndParents.Clear();
            SaveAnimParam.linesAndPoints1.Clear();
            SaveAnimParam.linesAndPoints2.Clear();
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/savedanim.oi", FileMode.Open);
            SaveLoad.savedAnim = (Node)bf.Deserialize(file);
            file.Close();
            SaveLoad.savedAnim.AfterLoad();
        }
    }
}


