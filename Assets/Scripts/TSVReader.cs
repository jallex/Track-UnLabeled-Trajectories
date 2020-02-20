using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using System.IO;

public class TSVReader : MonoBehaviour
{
    public TextAsset tsvFile;

    // The prefab for the data points that will be instantiated
    public GameObject PointPrefab;

    // Object which will contain instantiated prefabs in hiearchy
    public GameObject PointHolder;

    private int frameNum = 0;

    private List<GameObject> destroyList = new List<GameObject>(); 


    // Update is called once per frame
    void Update()
    {
            readTSV();
        frameNum += 1;
        //get rid of markers drawn from last frame
        for (int i = 0; i < destroyList.Count; i++)
        {
            Destroy(destroyList[i]);
        }
    }

    void readTSV()
    {
        int numPoints = 0;
        string[] records = tsvFile.text.Split('\n');
        //iterate each vertical row (going down)
        for (int i = 11 + frameNum; i < 11 + frameNum + 1; i++)
        {
            string[] fields = records[i].Split('\t');
            //find how many groups of 3 using %
            numPoints = (fields.Length - 2) / 3;
            // create an array of arrays representing each point- 3 (x, y, z) rows and numPoints columns
            float[,] flarray = new float[3, numPoints];
            Debug.Log("NumPoints: " + numPoints);
            int counter = 0;
            // iterate each horizonal row (going across)
            for (int j = 0; j < fields.Length - 2; j++)
            {
                Debug.Log("j: " + j);
                Debug.Log("counter " + counter);
                Debug.Log("(int)(j / 3)" + (int)(j / 3));
                Debug.Log("parse " + float.Parse(fields[j + 2])); // 2 because we don't want to count frame or time as points
                flarray[counter, (int)(j / 3)] = float.Parse(fields[j + 2]);
                counter += 1;
                //if we've reached the z position
                if (counter == 3)
                {
                    counter = 0;
                    //draw each point 
                }
            }

            for (int x = 0; x < flarray.GetLength(1); x++)
            {
                    GameObject dataPoint2 = Instantiate(
                    PointPrefab,
                    new Vector3(flarray[0, x], flarray[2, x], flarray[1, x]),
                    Quaternion.identity);

                destroyList.Add(dataPoint2);
            }

            // Instantiate as gameobject variable so that it can be manipulated within loop
            Debug.Log("Prefab points: " + flarray[0, i] + " " + flarray[1, i] + " " + flarray[2, i]);
            GameObject dataPoint = Instantiate(
                    PointPrefab,
                    new Vector3(flarray[0, i], flarray[1, i], flarray[2, i]),
                    Quaternion.identity);
            Debug.Log("Break");
            Debug.Log(flarray[0, 0] + ", " + flarray[1, 0] + ", " + flarray[2, 0]);
            Debug.Log(flarray[0, 1] + ", " + flarray[1, 1] + ", " + flarray[2, 1]);
            Debug.Log(flarray[0, numPoints - 1] + ", " + flarray[1, numPoints - 1] + ", " + flarray[2, numPoints - 1]);

            // Debug.Log("Here TSV " + float.Parse(fields[2]));
            //cubeTest.transform.Rotate(float.Parse(fields[1]), float.Parse(fields[2]), float.Parse(fields[3]));



        //Draw 
        //Account for frames and time -- Start -> Update 
        }
    }
}