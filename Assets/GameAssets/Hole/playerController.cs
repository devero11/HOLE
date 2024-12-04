using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class playerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float speed= 5;
    public int score = 0;



    void FixedUpdate()
    {
        Vector3 cameraForward = Camera.main.transform.forward;
Vector3 cameraRight = Camera.main.transform.right;

// Project the vectors onto the XZ plane (ignore Y axis)
cameraForward.y = 0;
cameraRight.y = 0;

cameraForward.Normalize();
cameraRight.Normalize();

// Compute the desired movement direction
Vector3 movement = cameraRight * Input.GetAxis("Horizontal") + cameraForward * Input.GetAxis("Vertical");

// Normalize the movement vector (optional, to ensure consistent speed in all directions)
movement.Normalize();

// Apply movement, factoring in speed and deltaTime
transform.position += movement * speed * Time.fixedDeltaTime;
        


        
    
    }



}
