using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float CameraDistance = 10;
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
            float delta_x = Input.mousePosition.x - _prevPos.x;
            float delta_y = Input.mousePosition.y - _prevPos.y;
            float h_angle = transform.rotation.eulerAngles.y;
            float v_angle = transform.rotation.eulerAngles.x;
            Vector3 newPos = Vector3.zero;
            v_angle = v_angle > 180 ? v_angle - 360 : v_angle;
            float new_v_angle = (90 - Mathf.Clamp((-delta_y * CameraSpeedV + v_angle), -45, 45));
            float new_h_angle = (delta_x * CameraSpeedH + h_angle);

            newPos.z = -CameraDistance * Mathf.Sin(new_v_angle * Mathf.Deg2Rad) * Mathf.Cos(new_h_angle * Mathf.Deg2Rad);
            newPos.x = -CameraDistance * Mathf.Sin(new_v_angle * Mathf.Deg2Rad) * Mathf.Sin(new_h_angle * Mathf.Deg2Rad);
            newPos.y = CameraDistance * Mathf.Cos(new_v_angle * Mathf.Deg2Rad);

            transform.position = newPos;
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
