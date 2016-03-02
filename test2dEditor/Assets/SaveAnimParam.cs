using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public static class SaveAnimParam//Статический класс для запоминания параметров
{
    public static int countFrames=0;//Количетсво фреймов анимации
    public static Dictionary<int, int> pointsAndParents=new Dictionary<int,int>();//привязка точек к кадру
    public static Dictionary<int, int> linesAndParents = new Dictionary<int, int>();//привязка линии к кадру
    public static Dictionary<int, int> linesAndPoints1 = new Dictionary<int, int>();//привязка линии к к 1-ой вершине
    public static Dictionary<int, int> linesAndPoints2 = new Dictionary<int, int>();//привязка линии к к 2-ой вершине
    
}

    [System.Serializable]
public class Vector2Serializer//класс который мы сериализуем в файл
    {
        public float x;
        public float y;
        public Vector2Serializer(Vector2 v2)
        {
            x = v2.x;
            y = v2.y;
        }
        public void Fill(Vector2 v2)
        {
            x = v2.x;
            y = v2.y;
        }

        public Vector2 V2 { get { return new Vector2(x, y); } set { Fill(value); } }
     
    }


    [System.Serializable]
    public class Node//класс который мы сериализуем в файл
    {

        public int countFrames = 0;//Количетсво фреймов анимации
        public Dictionary<int, int> pointsAndParents = new Dictionary<int, int>();//привязка точек к кадру
        public Dictionary<int, int> linesAndParents = new Dictionary<int, int>();//привязка линии к кадру
        public Dictionary<int, int> linesAndPoints1 = new Dictionary<int, int>();//привязка линии к к 1-ой вершине
        public Dictionary<int, int> linesAndPoints2 = new Dictionary<int, int>();//привязка линии к к 2-ой вершине
        public Dictionary<int, Vector2Serializer> pointsAndPosition = new Dictionary<int, Vector2Serializer>();
        public Node()
        {
            countFrames = SaveAnimParam.countFrames;
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
                string pointName = i.ToString() + "_Point";
                GameObject point = GameObject.Find(pointName);
                pointsAndPosition.Add(i, new Vector2Serializer((Vector2)point.transform.position));
                
            }
            _changeFrames.unsetActiveAllFrames();
        }

        public void AfterLoad()//загрузить по очереди все фреймы, точки и линии
        {            
            GameObject CreateFrame = GameObject.Find("CreateFrame");
            ChangeFrames _ChangeFrames = CreateFrame.GetComponent<ChangeFrames>();
            _ChangeFrames.CreateFrameAfterLoad(countFrames);
            GameObject CreatePoint = GameObject.Find("PointButton");
            Create_Point _Create_Point = CreatePoint.GetComponent<Create_Point>();
            _Create_Point._CreatePointAfterLoad(pointsAndParents, pointsAndPosition);
            GameObject CreateLine = GameObject.Find("Create_Line");
            Create_Line _CreateLine = CreateLine.GetComponent<Create_Line>();
            _CreateLine.CreateLineAfterLoad(linesAndParents, linesAndPoints1, linesAndPoints2);
            _ChangeFrames.ChangeFrameAfterLoad();
        }       

       
    }
