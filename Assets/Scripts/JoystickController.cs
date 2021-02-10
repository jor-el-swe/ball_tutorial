using UnityEngine;


public class JoystickController : MonoBehaviour
{
    public float speed = 10;
    private Rigidbody rb;
    private float movementX;
    private float movementY;

    private int _score = 0;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {

    }

    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "PickupTag")
        {
            other.gameObject.SetActive(false);
            _score++;
            FindObjectOfType<GameController>().SetCountText(_score);
        }
    }
}
