using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour
{
    
    public CharacterController ctrl;
    public float speed = 2f;
    public float turnSmooth = 0.1f;
    float turnVelocity;
    public Transform cam;

    void Start()
    {
        Cursor.visible = false;
    }
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f){
            float targetangle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetangle, ref turnVelocity, turnSmooth);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 movDir = Quaternion.Euler(0f, targetangle, 0f) * Vector3.forward;
            ctrl.Move(movDir.normalized * speed * Time.deltaTime);
        }
    }
}
