using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//options: 
//1 make them run on the same frame rate and make an if statement that checks 
// if one timestamp is less than the other in update 

    //or if they run at different frame rates do it independently 
    //load in next row of csv information, format nicely?
    //plot all untracked 

    //blow apart video into single images for synchronozation
public class FrameRate : MonoBehaviour
{

    public int target = 300;

    // Start is called before the first frame update
    void Start()
    {
        QualitySettings.vSyncCount = 0; 
    }

    // Update is called once per frame
    void Update()
    {
        if (target != Application.targetFrameRate)
        {
            Application.targetFrameRate = target;
        }
    }
}
