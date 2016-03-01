using UnityEngine;
using System.Collections;


public class LinePosition : MonoBehaviour {

    public GameObject point1;
    public GameObject point2;
    private Vector2 pointPos1;
    private Vector2 pointPos2;
    LineRenderer _lineRenderer;
    public int id;
	// Use this for initialization
	void Start () 
    {
        _lineRenderer = gameObject.GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (point1 != null)
        {
            if (point1.transform.position != (Vector3)pointPos1)
            {
                _lineRenderer.SetPosition(0, point1.transform.position);
                pointPos1 = point1.transform.position;
            }
        }
        else
        {
            //SaveAnimParam.linesAndPoints1.Remove(id);
            //SaveAnimParam.linesAndPoints2.Remove(id);
            SaveAnimParam.linesAndParents.Remove(id);
            Destroy(gameObject);
        }
        if (point2 != null)
        {
            if (point2.transform.position != (Vector3)pointPos2)
            {
                _lineRenderer.SetPosition(1, point2.transform.position);
                pointPos2 = point2.transform.position;
            }
        }
        else
        {
            //SaveAnimParam.linesAndPoints1.Remove(id);
            //SaveAnimParam.linesAndPoints2.Remove(id);
            SaveAnimParam.linesAndParents.Remove(id);
            Destroy(gameObject);
        }
        
	}
    public GameObject Point1
    {
        set
        {
            point1 = value;
            PointScript _pointID=value.GetComponent<PointScript>();
            SaveAnimParam.linesAndPoints1.Add(id, _pointID.ID);
        }
    }
    public GameObject Point2
    {
        set
        {
            point2 = value;
            PointScript _pointID = value.GetComponent<PointScript>();
            SaveAnimParam.linesAndPoints2.Add(id, _pointID.ID);
        }
    }

    public int ID
    {
        set
        {
            id = value;
            transform.gameObject.name = id.ToString() + "_Line";

        }
        get
        {
            return id;
        }
    }
}
