
using UnityEngine;

public class Pizza : MonoBehaviour
{
   

    private void OnTriggerEnter2D(Collider2D collision)
    {
      
        if (collision.tag == "Player")
        {
            collision.GetComponent<player>().pizzaCount++;
            Destroy(this.gameObject);
        }

    }
    
        
    
}
