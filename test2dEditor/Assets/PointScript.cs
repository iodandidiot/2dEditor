using UnityEngine;
using System.Collections;

public class PointScript : MonoBehaviour {
    public bool _changePosition;
    private bool _lineCreate;
    private bool _destroy=false;
    private GameObject _Create_Line;
    Vector2 mousePos;
	// Use this for initialization
	void Start () 
    {
        _Create_Line = GameObject.FindGameObjectWithTag("Create_line");
        changePosition();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (_changePosition && Input.GetMouseButton(0))
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mousePos;
        }
        else
        {
            _changePosition = false;
        }
	}

    public void changePosition()
    {
        _changePosition = true;
    }
    public void CreateLine()
    {
        _lineCreate = true;
        _destroy = false;
    }

    public void DestroyPoint()
    {
        _destroy = true;
        _lineCreate = false;
    }

    public void CreatePoint()
    {
        _destroy = false;
        _lineCreate = false;
    }

    void OnDestroy() 
    {
        
        GameObject pointButton = GameObject.FindGameObjectWithTag("point_button");
        if (pointButton != null)
        {
            Create_Point pointButtonScript = pointButton.GetComponent<Create_Point>();
            pointButtonScript.UnsignAndDestroy(gameObject);
        }
        

    }

    void OnMouseDown() 
    {
        if (_destroy)
        {
            Destroy(gameObject);
        }
        if (_lineCreate)
        {
            Create_Line create_Line = _Create_Line.GetComponent<Create_Line>();
            create_Line.ChangePoints(transform.position, gameObject);

            _lineCreate = false;
        }
        else
        {
            changePosition();
        }        
    }
}
