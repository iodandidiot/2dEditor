using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public static class SaveAnimParam 
{
    public static int countFrames=0;//Количетсво фреймов анимации
    public static Dictionary<int, int> pointsAndParents=new Dictionary<int,int>();//привязка точек к кадру
    public static Dictionary<int, int> linesAndParents = new Dictionary<int, int>();//привязка линии к кадру
    public static Dictionary<int, int> linesAndPoints1 = new Dictionary<int, int>();//привязка линии к к 1-ой вершине
    public static Dictionary<int, int> linesAndPoints2 = new Dictionary<int, int>();//привязка линии к к 2-ой вершине
    
}
[System.Serializable]
public class Node
{
    public int countFrames = 0;//Количетсво фреймов анимации
    public Dictionary<int, int> pointsAndParents = new Dictionary<int, int>();//привязка точек к кадру
    public Dictionary<int, int> linesAndParents = new Dictionary<int, int>();//привязка линии к кадру
    public Dictionary<int, int> linesAndPoints1 = new Dictionary<int, int>();//привязка линии к к 1-ой вершине
    public Dictionary<int, int> linesAndPoints2 = new Dictionary<int, int>();//привязка линии к к 2-ой вершине
    public Dictionary<int, Vector2> pointsAndPosition = new Dictionary<int, Vector2>();
    public Node()
    {
        pointsAndParents = SaveAnimParam.pointsAndParents;
        linesAndParents = SaveAnimParam.linesAndParents;
        linesAndPoints1 = SaveAnimParam.linesAndPoints1;
        linesAndPoints2 = SaveAnimParam.linesAndPoints2;
        savePointsAndPosition();
    }

    public void savePointsAndPosition()
    {
        GameObject CreateFrame = GameObject.Find("CreateFrame");
        ChangeFrames _changeFrames = CreateFrame.GetComponent<ChangeFrames>();
        _changeFrames.setActiveAllFrames();
        foreach (int i in pointsAndParents.Keys)
        {
            string pointName=i.ToString() + "_Point";
            GameObject point=GameObject.Find(pointName);
            pointsAndPosition.Add(i, point.transform.position);
        } 
        _changeFrames.unsetActiveAllFrames();
    }
}
