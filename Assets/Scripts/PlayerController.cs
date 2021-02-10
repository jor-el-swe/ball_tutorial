using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    public float speed = 10;

    private Rigidbody rb;
    private float movementX;
    private float movementY;

    private int _score = 0;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        InputSystem.EnableDevice(UnityEngine.InputSystem.Gyroscope.current);
        InputSystem.EnableDevice(UnityEngine.InputSystem.Accelerometer.current);
        InputSystem.EnableDevice(UnityEngine.InputSystem.GravitySensor.current);
    }
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        
        Vector3 movement2 = new Vector3(Input.acceleration.x, 0, Input.acceleration.y);
        Debug.Log("x: " + Input.acceleration.x + "y: " + Input.acceleration.y);
        rb.AddForce(movement * speed);
        rb.AddForce(movement2 * speed);
    }


    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("PickupTag"))
        {
            other.gameObject.SetActive(false);
            _score++;
            FindObjectOfType<GameController>().SetCountText(_score);
        }

    }
}
