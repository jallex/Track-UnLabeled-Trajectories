
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class MoveToNearPlane : MonoBehaviour
{
    public RawImage rawImage;
    public Camera cam;
    public GameObject cube;
    // Start is called before the first frame update
    void Start()
    {
        rawImage.transform.localPosition = new Vector3(cam.transform.localPosition.x, cam.transform.localPosition.y, cam.transform.localPosition.z);
        cube.transform.localPosition = new Vector3(cam.transform.localPosition.x - cam.nearClipPlane, cam.transform.localPosition.y, cam.transform.localPosition.z);

        /**
        Rect r = new Rect();
        float a = cam.nearClipPlane;//get length
        float A = cam.fieldOfView * 0.5f;//get angle
        A = A * Mathf.Deg2Rad;//convert tor radians
        float h = (Mathf.Tan(A) * a);//calc height
        float w = (h / cam.pixelHeight) * cam.pixelWidth;//width


        r.xMin = -w;
        r.xMax = w;
        r.yMin = -h;
        r.yMax = h;

        Debug.Log(a);
        Debug.Log(h);
        Debug.Log(w);
        cube.transform.localScale = new Vector3(a, h, w);
    **/

        Vector3 pos = cam.transform.position;
        float halfFOV = (cam.fieldOfView * 0.5f) * Mathf.Deg2Rad;
        float aspect = cam.aspect;

        float halfHeight = Mathf.Tan(halfFOV);
        float halfWidth = halfHeight * aspect;

         float h = 2.0f * 0.3f * Mathf.Tan(cam.fieldOfView * 0.5f * Mathf.Deg2Rad);
        float w = h * cam.aspect;


        Debug.Log(halfWidth * 2);
        Debug.Log(halfHeight * 2);
        cube.transform.localScale = new Vector3(h, w, 0.02f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
