using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class adjustPlane : MonoBehaviour
{
    public Camera[] cameras;
    // Start is called before the first frame update
    void Start()
    {
        // get camera objects in scene
        cameras = GameObject.FindObjectsOfType<Camera>();
        // Debug.Log("Number of Cameras: " + cameras.Length);
            for (int i = 0; i < cameras.Length; i++)
            {
            // Debug.Log(cameras[i].name);
            cameras[i].nearClipPlane = .03f;
                cameras[i].farClipPlane = 10;

                //get child of camera
                GameObject mesh = cameras[i].transform.GetChild(0).gameObject;
               //  Debug.Log(cameras[i].name);
                // Debug.Log(mesh.name);
                ObjectRotation(mesh);
               //  Debug.Log("mesh" + mesh.transform.eulerAngles.y);
                cameras[i].Render();

            //add the models as children 
            //rotate all micus cameras Y by 180
            // scale ocus to 0.02, also rotate Y by 180
            if (cameras[i].name.Contains("Ocus"))
            {
                // private Mesh m = cameras[i].GetComponentInChildren.< Mesh > ();
            }
            }


        }
    public void ObjectRotation(GameObject you)
    {
        you.transform.localEulerAngles = new Vector3(0, 180, 0);
        // Debug.Log("you" + you.transform.eulerAngles.y);
    }
}

