using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class ChangeFrames : MonoBehaviour {
    public GameObject frame;
    public List<GameObject> frames;
    public int number=0;
    public int tempNumber = 0;
    private GameObject AnimParent;
    public Text frameNumber;
    public Text startText;
	// Use this for initialization
	void Start () 
    {
        frameNumber.text = "0";
	}
	
	// Update is called once per frame
	public void CreateFrame()
    {
        startText.gameObject.SetActive(false);
        ChangeFrame();
        GameObject nextframe = (GameObject)Instantiate(frame, new Vector2(0, 0), Quaternion.identity);
        frames.Add(nextframe);
        number++;
        tempNumber = number;
        nextframe.gameObject.transform.name = "frame_" + number.ToString();
        FramesScript frameScript = nextframe.GetComponent<FramesScript>();
        frameScript.ID = number;
        SaveAnimParam.countFrames++;
        print(SaveAnimParam.countFrames);
        frameNumber.text = string.Format("{0}", tempNumber);
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
        frameNumber.text = string.Format("{0}", tempNumber);
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
        frameNumber.text = string.Format("{0}", tempNumber);
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

    public void CreateFrameAfterLoad(int count)
    {
        startText.gameObject.SetActive(false);
        foreach (GameObject i in frames)
        {
            Destroy(i.gameObject);
        }
        SaveAnimParam.countFrames = 0;

        frames.Clear();
        number = 0;
        tempNumber = 0;
        for (int i = 0; i < count; i++)
        {
            //ChangeFrame();
            GameObject nextframe = (GameObject)Instantiate(frame, new Vector2(0, 0), Quaternion.identity);
            frames.Add(nextframe);
            number++;
            tempNumber = number;
            nextframe.gameObject.transform.name = "frame_" + number.ToString();
            FramesScript frameScript = nextframe.GetComponent<FramesScript>();
            frameScript.ID = number;
            SaveAnimParam.countFrames++;
            print(SaveAnimParam.countFrames);
        }

    }
    public void ChangeFrameAfterLoad()
    {
        foreach (GameObject i in frames)
        {
            i.gameObject.tag = "Untagged";
            i.gameObject.SetActive(false);
        }
        frames[0].gameObject.tag = "cur_frame";
        frames[0].gameObject.SetActive(true);
        tempNumber = 1;
        frameNumber.text = string.Format("{0}", tempNumber);
    }
}
