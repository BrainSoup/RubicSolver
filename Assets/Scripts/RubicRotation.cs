using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubicRotation : MonoBehaviour
{
    public float CameraSpeedH = 1;
    public float CameraSpeedV = 1;
    private bool _rotationMode = false;
    private const int MouseMiddleButton = 2;


    private Vector3 _prevPos = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    void Update()
    {
        if (_rotationMode)
        {
            float delta_x = (Input.mousePosition.x - _prevPos.x) * CameraSpeedH;
            float delta_y = (Input.mousePosition.y - _prevPos.y) * CameraSpeedV;

            var orientation = transform.rotation.eulerAngles;

            orientation.x = orientation.x > 180 ? orientation.x - 360 : orientation.x;
            float new_v_angle = Mathf.Clamp(orientation.x + delta_y, -45, 45);
            transform.rotation = Quaternion.Euler(new_v_angle, orientation.y + delta_x, orientation.z);

            _prevPos = Input.mousePosition;
            transform.LookAt(Vector3.zero, Vector3.up);
        }

        if(Input.GetMouseButtonDown(MouseMiddleButton))
        {
            _rotationMode = true;
            _prevPos = Input.mousePosition;
        }
        if(!Input.GetMouseButton(MouseMiddleButton))
        {
            _rotationMode = false;
        }
    }
}
