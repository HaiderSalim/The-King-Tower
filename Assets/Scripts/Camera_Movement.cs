using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Movement : MonoBehaviour
{
    private float Mousex;
    private float Mousey;
    //private Camera _camera;
    [Header("Camera Movement Paremeters")]
    [SerializeField] private float Sensitivity = 1f;
    [SerializeField] private float MapResX;
    [SerializeField] private float MapResY;

    private void Start()
    {
        //_camera = GetComponent<Camera>();
    }

    private void Update()
    {
        Mousex = Input.GetAxis("Mouse X") * Sensitivity;
        Mousey = Input.GetAxis("Mouse Y") * Sensitivity;
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButton(1))
        {
            float x = this.transform.position.x + (-Mousex * Time.deltaTime);
            float y = this.transform.position.y + (-Mousey * Time.deltaTime);
            x = Mathf.Clamp(x, -PixelsToUnityTransformUnits(MapResX) / 2, PixelsToUnityTransformUnits(MapResX) / 2);
            y = Mathf.Clamp(y, -PixelsToUnityTransformUnits(MapResY) / 2, PixelsToUnityTransformUnits(MapResY) / 2);
            this.transform.position = new Vector3(x, y, -10f);
        }
    }

    private float PixelsToUnityTransformUnits(float value)
    {
        return (value / 100) / 2;
    }
}
