using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneChanger : MonoBehaviour {

    public void change(string name)
    {
        SceneManager.LoadScene(name);
    }
}
