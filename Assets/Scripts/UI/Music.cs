using UnityEngine;


public class Music : MonoBehaviour
{
    public static Music instance = null;
    public AudioSource musicSource;
    [SerializeField] private GameObject go, on, off;

void Awake ()
    {
        if(instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    public void OnandOff()
    {
        if (go.gameObject.activeSelf)
        {
            go.SetActive(false);
            off.SetActive(true);
            on.SetActive(false);
        }  
        else if (!go.gameObject.activeSelf)
        {
           go.SetActive(true);
            off.SetActive(false);
            on.SetActive(true);
        }
            
    }
   
}
