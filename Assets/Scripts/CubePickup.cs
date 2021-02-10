using UnityEngine;


public class CubePickup : MonoBehaviour
{
    private Rigidbody rb;

    private int _score = 0;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
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
