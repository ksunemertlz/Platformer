using UnityEngine.SceneManagement;
using UnityEngine;

public class ChooseLevel : MonoBehaviour
{
    [SerializeField] GameObject ob1, ob2, ob3, ob4, ob5, ob6, ob7, ob8, ob9, ob10; 
    public void toLevelMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void toLevel1()
    {
        SceneManager.LoadScene(2);
    }
    public void toLevel2()
    {
        if(PlayerPrefs.GetInt("1") == 1)
            SceneManager.LoadScene(3);    }
    public void toLevel3()
    {
        if (PlayerPrefs.GetInt("2") == 2)
            SceneManager.LoadScene(4);
    }
    public void toLevel4()
    {
        if (PlayerPrefs.GetInt("3") == 3)
            SceneManager.LoadScene(5);     
    }
    public void toLevel5()
    {
        if (PlayerPrefs.GetInt("4") == 4)
            SceneManager.LoadScene(6);  
    }
    public void toLevel6()
    {
        if (PlayerPrefs.GetInt("5") == 5)
            SceneManager.LoadScene(7);
    }
    public void toLevel7()
    {
        if (PlayerPrefs.GetInt("6") == 6)
            SceneManager.LoadScene(8);
    }
    public void toLevel8()
    {
        if (PlayerPrefs.GetInt("7") == 7)
            SceneManager.LoadScene(9);
    }
    public void toLevel9()
    {
        if (PlayerPrefs.GetInt("8") == 8)
            SceneManager.LoadScene(10);
    }
    public void toLevel10()
    {
        if (PlayerPrefs.GetInt("9") == 9)
            SceneManager.LoadScene(11);
    }
    public void toLevel11()
    {
        if (PlayerPrefs.GetInt("10") == 10)
            SceneManager.LoadScene(12);
    }
    public void prefs()
    {
        PlayerPrefs.DeleteAll();
    }
    private void Update()
    {
        if (PlayerPrefs.GetInt("1") == 1)
            ob1.SetActive(false);
        if (PlayerPrefs.GetInt("2") == 2)
            ob2.SetActive(false);
        if (PlayerPrefs.GetInt("3") == 3)
            ob3.SetActive(false);
        if (PlayerPrefs.GetInt("4") == 4)
            ob4.SetActive(false);
        if (PlayerPrefs.GetInt("5") == 5)
            ob5.SetActive(false);
        if (PlayerPrefs.GetInt("6") == 6)
            ob6.SetActive(false);
        if (PlayerPrefs.GetInt("7") == 7)
            ob7.SetActive(false);
        if (PlayerPrefs.GetInt("8") == 8)
            ob8.SetActive(false);
        if (PlayerPrefs.GetInt("9") == 9)
            ob9.SetActive(false);
        if (PlayerPrefs.GetInt("10") == 10)
            ob10.SetActive(false);

        }    
}   
