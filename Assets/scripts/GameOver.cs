using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameOver : MonoBehaviour {

    public AudioSource clap;

    public string NextScene;

    public GameObject GmaeOver;

	void OnTriggerEnter2D(Collider2D coll)
    {
        clap.Play();
        GmaeOver.SetActive(true);
    }

    public void change()
    {
        SceneManager.LoadScene(NextScene);
    }
}
