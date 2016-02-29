using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Create_Point : MonoBehaviour {
    public GameObject point;
    GameObject lastPoint;
    public delegate void CreateLine();
    public event CreateLine onCreateLine;
    public event CreateLine onDestroyPoint;
    public event CreateLine onCreate;
    GameObject curFrame;
    public void _CreatePoint()
    {
        curFrame = GameObject.FindGameObjectWithTag("cur_frame");
        lastPoint=(GameObject)Instantiate(point, new Vector2(0,0), Quaternion.identity);
        PointScript lastPoinScript = lastPoint.GetComponent<PointScript>();
        onCreateLine += lastPoinScript.CreateLine;
        onDestroyPoint += lastPoinScript.DestroyPoint;
        onCreate += lastPoinScript.CreatePoint;
        lastPoint.transform.parent = curFrame.transform;
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
}
