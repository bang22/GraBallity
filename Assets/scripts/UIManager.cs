using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class UIManager : MonoBehaviour {

    public GameObject pause;

    public string HomeScene;
    public string ThisScene;

    public void Stop()
    {
       pause.SetActive(true);
       Time.timeScale = 0;

    }

    public void resume()
    {
        pause.SetActive(false);
        Time.timeScale = 1;
    }

    public void Home()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(HomeScene);
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(ThisScene);
    }
}
