using UnityEngine.SceneManagement;
using UnityEngine;

public class Restart : MonoBehaviour
{
    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void NextLevel()
    {
        var index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index + 1);
    }
    public void toMenu()
    {
        SceneManager.LoadScene(1);
    }

}
