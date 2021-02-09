
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;


public class PlayerController : MonoBehaviour
{
    public float speed = 10;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;

    private Rigidbody rb;
    private float movementX;
    private float movementY;

    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        SetCountText();
        winTextObject.SetActive(false);
        
        InputSystem.EnableDevice(UnityEngine.InputSystem.Gyroscope.current);
        InputSystem.EnableDevice(UnityEngine.InputSystem.Accelerometer.current);
        InputSystem.EnableDevice(UnityEngine.InputSystem.GravitySensor.current);
    }

    // Update is called once per frame
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

    void SetCountText()
    {
        countText.text = "Count: " + score;

        if(score >= 12)
        {
            winTextObject.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "PickupTag")
        {
            other.gameObject.SetActive(false);
            score++;
            SetCountText();
        }

    }

    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "PickupTag")
        {
            collision.gameObject.SetActive(false);
        }
    }*/

}
