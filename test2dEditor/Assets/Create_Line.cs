using UnityEngine;
using System.Collections;


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
        SaveAnimParam.linesAndParents.Add(lines_id, int.Parse(curFrame.gameObject.name));        
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

}
