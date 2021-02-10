using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject winTextObject;
    public TextMeshProUGUI countText;
    // Start is called before the first frame update
    void Start()
    {
        winTextObject.SetActive(false);
        SetCountText(0);
    }
    
    public void SetCountText(int score)
    {
        countText.text = "Count: " + score;

        if(score >= 12)
        {
            winTextObject.SetActive(true);
            
            //change to next level
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
    }
}
