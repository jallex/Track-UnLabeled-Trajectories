using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class video : MonoBehaviour
{
    public RawImage rawImage;
    public VideoPlayer videoPlayer;
    public Camera cam;
    // Use this for initialization
    void Start()
    {
        StartCoroutine(PlayVideo());
        Rect r = new Rect();
        float a = cam.nearClipPlane;//get length
        float A = cam.fieldOfView * 0.5f;//get angle
        A = A * Mathf.Deg2Rad;//convert tor radians
        float h = (Mathf.Tan(A) * a);//calc height
        float w = (h / cam.pixelHeight) * cam.pixelWidth;//deduct width

        r.xMin = -w;
        r.xMax = w;
        r.yMin = -h;
        r.yMax = h;
    }
    IEnumerator PlayVideo()
    {
        videoPlayer.Prepare();
        WaitForSeconds waitForSeconds = new WaitForSeconds(1);
        while (!videoPlayer.isPrepared)
        {
            yield return waitForSeconds;
            break;
        }
        rawImage.transform.localPosition = new Vector3(cam.transform.localPosition.x, cam.transform.localPosition.y, cam.transform.localPosition.z + cam.nearClipPlane);
        rawImage.texture = videoPlayer.texture;
        videoPlayer.Play();
        // Debug.Log("here");
        // Debug.Log("frame rate:" + videoPlayer.frameRate);
        // Debug.Log(videoPlayer.frameCount);
    }
}
