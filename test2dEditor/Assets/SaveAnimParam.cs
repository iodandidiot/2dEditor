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
    public static int countFrames = 0;//Количетсво фреймов анимации
    public static Dictionary<int, int> pointsAndParents = new Dictionary<int, int>();//привязка точек к кадру
    public static Dictionary<int, int> linesAndParents = new Dictionary<int, int>();//привязка линии к кадру
    public static Dictionary<int, int> linesAndPoints1 = new Dictionary<int, int>();//привязка линии к к 1-ой вершине
    public static Dictionary<int, int> linesAndPoints2 = new Dictionary<int, int>();//привязка линии к к 2-ой вершине
    public Node()
    {
        pointsAndParents = SaveAnimParam.pointsAndParents;
        linesAndParents = SaveAnimParam.linesAndParents;
        linesAndPoints1 = SaveAnimParam.linesAndPoints1;
        linesAndPoints2 = SaveAnimParam.linesAndPoints2;
    }
}
