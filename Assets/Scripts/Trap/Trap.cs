using UnityEngine.UI;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] private GameObject heart1, heart2, heart3;
    [SerializeField] private Canvas loseCanvas;

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {   
        if (collision.GetComponent<player>() != null)
        {
            if (heart1.activeSelf && heart2.activeSelf && heart3.activeSelf)
               heart3.SetActive(false);
            else if (heart1.activeSelf && heart2.activeSelf)
               heart2.SetActive(false);
            else if(heart1.activeSelf)
                heart1.SetActive(false);

            if (!heart1.activeSelf && !heart2.activeSelf && !heart3.activeSelf)
             loseCanvas.gameObject.SetActive(true);
      
               
        }
        

    }
}
