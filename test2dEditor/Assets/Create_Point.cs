using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;


public class Create_Point : MonoBehaviour {
    public GameObject point;
    GameObject lastPoint;
    public delegate void CreateLine();
    public event CreateLine onCreateLine;
    public event CreateLine onDestroyPoint;
    public event CreateLine onCreate;
    GameObject curFrame;
    private int points_id=0;
    public void _CreatePoint()
    {
        curFrame = GameObject.FindGameObjectWithTag("cur_frame");
        lastPoint=(GameObject)Instantiate(point, new Vector2(0,0), Quaternion.identity);
        PointScript lastPoinScript = lastPoint.GetComponent<PointScript>();
        lastPoinScript.ID = points_id;
        onCreateLine += lastPoinScript.CreateLine;
        onDestroyPoint += lastPoinScript.DestroyPoint;
        onCreate += lastPoinScript.CreatePoint;
        lastPoint.transform.parent = curFrame.transform;
        FramesScript frameScript = curFrame.GetComponent<FramesScript>();
        SaveAnimParam.pointsAndParents.Add(points_id, frameScript.ID);
        points_id++;
    }
    public void _onCreateLine()
    {
        onCreateLine();
    }
    public void _onDestroyPoint()
    {
        onDestroyPoint();
    }

    public void UnsignAndDestroy(GameObject unsign)
    {
        PointScript _unsign = unsign.GetComponent<PointScript>();
        onCreateLine -= _unsign.CreateLine;
        onDestroyPoint -= _unsign.DestroyPoint;
        onCreate -= _unsign.CreatePoint;
        //Destroy(unsign.gameObject);
    }

    public void _CreatePointAfterLoad(Dictionary<int, int> pointsAndParents,Dictionary<int, Vector2Serializer> pointsAndPosition)
    {
        points_id=0;
        foreach (int i in pointsAndParents.Keys)
        {
            string frameName = string.Format("{0}", pointsAndParents[i]);
            curFrame = GameObject.Find("frame_"+frameName);
            lastPoint = (GameObject)Instantiate(point, pointsAndPosition[i].V2, Quaternion.identity);
            PointScript lastPoinScript = lastPoint.GetComponent<PointScript>();
            lastPoinScript.ID = i;
            onCreateLine += lastPoinScript.CreateLine;
            onDestroyPoint += lastPoinScript.DestroyPoint;
            onCreate += lastPoinScript.CreatePoint;
            lastPoint.transform.parent = curFrame.transform;
            FramesScript frameScript = curFrame.GetComponent<FramesScript>();
            SaveAnimParam.pointsAndParents.Add(points_id, frameScript.ID);
            points_id=i+1;
        }

    }
}
