using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Create_Line : MonoBehaviour {

    Vector3 [] linePoints=new Vector3[2];
    GameObject [] linePointsObject = new GameObject[2];
    public GameObject line;
    private GameObject lastLine;
    private bool point = false;
    GameObject curFrame;
    private int lines_id = 0;
	// Use this for initialization
	
    public void CheckPositionLine()
    {
        curFrame = GameObject.FindGameObjectWithTag("cur_frame");
        lastLine = (GameObject)Instantiate(line, new Vector2(0, 0), Quaternion.identity);
        LineRenderer _lineRenderer = lastLine.GetComponent<LineRenderer>();
        _lineRenderer.SetPositions(linePoints);
        LinePosition _linePoints = lastLine.AddComponent<LinePosition>();
        _linePoints.ID = lines_id;
        _linePoints.Point1 = linePointsObject[0];
        _linePoints.Point2 = linePointsObject[1];
        lastLine.transform.parent = curFrame.transform;
        point = false;
        FramesScript frameScript = curFrame.GetComponent<FramesScript>();
        SaveAnimParam.linesAndParents.Add(lines_id, frameScript.ID);        
        lines_id++;
    }
    public void ChangePoints(Vector2 pointPosition,GameObject _pointObject)
    {
        if (!point)
        {
            linePoints[0] = pointPosition;
            linePointsObject[0] = _pointObject;
            point=true;
        }
        else
        {
            linePoints[1] = pointPosition;
            linePointsObject[1] = _pointObject;
            CheckPositionLine();
        }
    }
    public void falsePoint()
    {
        point = false;
    }


    public void CreateLineAfterLoad(Dictionary<int, int> linesAndParents, Dictionary<int, int> linesAndPoints1,Dictionary<int, int> linesAndPoints2)
    {
        lines_id = 0;
        foreach (int i in linesAndParents.Keys)
        {
            string frameName = string.Format("{0}", linesAndParents[i]);
            curFrame = GameObject.Find("frame_" + frameName);
            lastLine = (GameObject)Instantiate(line, new Vector2(0, 0), Quaternion.identity);
            lastLine.transform.parent = curFrame.transform;
            string point1Name = string.Format("{0}", linesAndPoints1[i]);
            GameObject point1 = GameObject.Find(point1Name+"_Point");
            linePoints[0] = point1.transform.position;
            string point2Name = string.Format("{0}", linesAndPoints2[i]);
            GameObject point2 = GameObject.Find(point2Name + "_Point");
            linePoints[1] = point2.transform.position;
            LineRenderer _lineRenderer = lastLine.GetComponent<LineRenderer>();
            _lineRenderer.SetPositions(linePoints);
            LinePosition _linePoints = lastLine.AddComponent<LinePosition>();
            _linePoints.ID = i;
            _linePoints.Point1 = point1;
            _linePoints.Point2 = point2;
            point = false;
            FramesScript frameScript = curFrame.GetComponent<FramesScript>();
            SaveAnimParam.linesAndParents.Add(lines_id, frameScript.ID);
            lines_id=i+1;           
        }
    }
}
