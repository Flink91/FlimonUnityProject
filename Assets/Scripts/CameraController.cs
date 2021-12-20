using UnityEngine;

public class CameraController : MonoBehaviour
{
    //pan speed of the camera
    public float panSpeed = 20f;
    //the border to trigger mouse pan
    public float panBorderThickness = 20f;
    //stop cam movement at map border
    public Vector2 panLimit;

    public float scrollSpeed = 20f;
    public float minY = 10f;
    public float maxY = 40f;
    public float zoomSensitivity= 15.0f;
    public float zoomSpeed= 5.0f;

    private float zoom;

    void Start(){
        zoom = Camera.main.fieldOfView;
    }

    // Update is called once per frame
    void Update()
    {
        //disable camera when game is over
        if (GameManager.GameIsOver)
        {
            this.enabled = false;
            return;
        }
        //get current cam position
        Vector3 pos = transform.position;

        if(Input.GetKey("w")){
            pos.z += panSpeed * Time.deltaTime;
            pos.x -= panSpeed * Time.deltaTime;
        }
        if(Input.GetKey("a")){
            pos.x -= panSpeed * Time.deltaTime;
             pos.z -= panSpeed * Time.deltaTime;
        }
        if(Input.GetKey("s")){
            pos.z -= panSpeed * Time.deltaTime;
            pos.x += panSpeed * Time.deltaTime;
        }
        if(Input.GetKey("d")){
            pos.z += panSpeed * Time.deltaTime;
            pos.x += panSpeed * Time.deltaTime;
        }

        zoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSensitivity;
         zoom = Mathf.Clamp(zoom, minY, maxY);


        pos.x = Mathf.Clamp(pos.x, -panLimit.x, panLimit.x);
        pos.z = Mathf.Clamp(pos.z, -panLimit.y, panLimit.y);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        

        transform.position = pos;
    }

    void LateUpdate() {
         Camera.main.fieldOfView = Mathf.Lerp (Camera.main.fieldOfView, zoom, Time.deltaTime * zoomSpeed);
     }
}
