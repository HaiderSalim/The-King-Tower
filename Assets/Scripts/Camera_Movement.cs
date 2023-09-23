using UnityEngine;

public class Camera_Movement : MonoBehaviour
{
    [Header("Mouse Controls Parameters")]
    private float Mousex;
    private float Mousey;

    [Header("Camera Movement Paremeters")]
    [SerializeField] private float PCSensitivity = 1f;
    [SerializeField] private float MobileSensitivity = 1f;
    [SerializeField] private SpriteRenderer BackSprite;
    [SerializeField] private Camera Cam;
    [SerializeField] private float smoothing = 0.1f;

    private float CamWidth;
    private float CamHeight;
    private float MapmaxX;
    private float MapminX;
    private float MapmaxY;
    private float MapminY;

    private void Awake()
    {
        Cam = Camera.main;
    }

    private void Start()
    {

        CamHeight = Cam.orthographicSize;
        CamWidth = CamHeight * Cam.aspect;


        MapminX = BackSprite.bounds.min.x + CamWidth;
        MapmaxX = BackSprite.bounds.extents.x - CamWidth;

        MapminY = BackSprite.bounds.min.y + CamHeight;
        MapmaxY = BackSprite.bounds.extents.y - CamHeight;
    }

    private void Update()
    {
        Mousex = Input.GetAxis("Mouse X") * PCSensitivity;
        Mousey = Input.GetAxis("Mouse Y") * PCSensitivity;
    }

    private void FixedUpdate()
    {
        Vector2 cambounds;

        //Camera Movement Touch Controls
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                Vector2 touchDeltaPosition = touch.deltaPosition;
                Vector3 cameraPosition = transform.position;

                // Adjust the camera's position based on touch movement.
                cameraPosition.x -= touchDeltaPosition.x * MobileSensitivity;
                cameraPosition.y -= touchDeltaPosition.y * MobileSensitivity;

                //Applay The map Bounds to the camera movement
                cambounds = GetCameraBounds(cameraPosition.x, cameraPosition.y);

                // Apply the new camera position smoothly using Lerp.
                transform.position = new Vector3(Mathf.Lerp(transform.position.x, cambounds.x, smoothing * Time.deltaTime),
                    Mathf.Lerp(transform.position.y, cambounds.y, smoothing * Time.deltaTime),
                    -10f);
            }
        }
        else
        {
            //Camera Movement Mouse Controls
            if (Input.GetMouseButton(1))
            {
                float x = this.transform.position.x + (-Mousex * Time.deltaTime);
                float y = this.transform.position.y + (-Mousey * Time.deltaTime);
                cambounds = GetCameraBounds(x, y);
                this.transform.position = new Vector3(cambounds.x, cambounds.y, -10f);
            }
        }
    }

    private Vector2 GetCameraBounds(float inx, float iny)
    { 
        inx = Mathf.Clamp(inx, MapminX, MapmaxX);
        iny = Mathf.Clamp(iny, MapminY, MapmaxY);

        return new Vector2(inx, iny);
    }
}
