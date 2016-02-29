using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class ChangeFrames : MonoBehaviour {
    public GameObject frame;
    public List<GameObject> frames;
    public int number=1;
    public int tempNumber = 1;
    private GameObject AnimParent;
	// Use this for initialization
	void Start () 
    {
        AnimParent = GameObject.FindGameObjectWithTag("animParent");
        GameObject frame1=(GameObject)Instantiate(frame, new Vector2(0, 0), Quaternion.identity);
        frames.Add(frame1);
        frame1.gameObject.transform.name = number.ToString();
        SaveAnimParam.countFrames++;
        print(SaveAnimParam.countFrames);
	}
	
	// Update is called once per frame
	public void CreateFrame()
    {
        ChangeFrame();
        GameObject nextframe = (GameObject)Instantiate(frame, new Vector2(0, 0), Quaternion.identity);
        frames.Add(nextframe);
        number++;
        tempNumber = number;
        nextframe.gameObject.transform.name = number.ToString();
        SaveAnimParam.countFrames++;
        print(SaveAnimParam.countFrames);
	}

    void ChangeFrame()
    {
        foreach (GameObject i in frames)
        {
            i.gameObject.tag = "Untagged";
            i.gameObject.SetActive(false);
        }
    }

    public void PrefFrame()
    {
        if (tempNumber-1 > 0)
        {
            tempNumber--;
            ChangeFrame();
            frames[tempNumber-1].gameObject.tag = "cur_frame";
            frames[tempNumber-1].gameObject.SetActive(true);
        }        
    }
    public void NextFrame()
    {
        if (tempNumber-1 < frames.ToArray().Length - 1)
        {
            tempNumber++;
            ChangeFrame();
            frames[tempNumber-1].gameObject.tag = "cur_frame";
            frames[tempNumber-1].gameObject.SetActive(true);
        }        
    }

    public void setActiveAllFrames()
    {
        foreach (GameObject i in frames)
        {
            i.gameObject.SetActive(true);
        }
    }
    public void unsetActiveAllFrames()
    {
        foreach (GameObject i in frames)
        {
            if(i.gameObject.tag == "Untagged")
            {
                i.gameObject.SetActive(false);
            }
            
        }
    }
}
