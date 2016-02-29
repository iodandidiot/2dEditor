using UnityEngine;
using System.Collections;

public class SaveAnim : MonoBehaviour {

    public void Save()
    {
        SaveLoad.Save();
    }

    public void Load()
    {
        SaveLoad.Load();
    }
}
