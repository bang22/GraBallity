using UnityEngine;
using System.Collections;

public class CamMove : MonoBehaviour {

    public Transform target = null;
    public float speed;

    float curCamSize;

    [SerializeField]
    float CamSize = 5;

    Camera cam;

    float progress = 0;

    void Start()
    {
        cam = GetComponent<Camera>();
        curCamSize = cam.orthographicSize;
    }

	void LateUpdate ()
    {
        if (target)
        {
            Vector3 pos = this.transform.position;
            pos = Vector2.MoveTowards(pos, target.position, speed);
            pos.z = -10;

            this.transform.position = pos;
        }

        if(cam.orthographicSize != CamSize)
        {
            cam.orthographicSize = Mathf.Lerp(curCamSize, CamSize, progress);
            progress += 0.01f;
        }
    }

    public void smoothCamSize(int size)
    {
        CamSize = size;
        curCamSize = cam.orthographicSize;
        progress = 0;
    }
}
