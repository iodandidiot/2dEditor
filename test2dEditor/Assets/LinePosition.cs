using UnityEngine;
using System.Collections;

public class LinePosition : MonoBehaviour {

    public GameObject point1;
    public GameObject point2;
    private Vector2 pointPos1;
    private Vector2 pointPos2;
    LineRenderer _lineRenderer;

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
            Destroy(gameObject);
        }
        
	}
    public GameObject Point1
    {
        set
        {
            point1 = value;
        }
    }
    public GameObject Point2
    {
        set
        {
            point2 = value;
        }
    }
}
