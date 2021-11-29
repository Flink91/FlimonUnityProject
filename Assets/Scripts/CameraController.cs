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

    // Update is called once per frame
    void Update()
    {
        //get current cam position
        Vector3 pos = transform.position;

        if(Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness){
            pos.z += panSpeed * Time.deltaTime;
        }
        if(Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness){
            pos.x -= panSpeed * Time.deltaTime;
        }
        if(Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness){
            pos.z -= panSpeed * Time.deltaTime;
        }
        if(Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness){
            pos.x += panSpeed * Time.deltaTime;
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        pos.y -= scroll * scrollSpeed * 100 * Time.deltaTime;


        pos.x = Mathf.Clamp(pos.x, -panLimit.x, panLimit.x);
        pos.z = Mathf.Clamp(pos.z, -panLimit.y, panLimit.y);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        

        transform.position = pos;
    }
}
