using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class StageChanger : MonoBehaviour {

	public void Go(int SceneNum)
    {
        SceneManager.LoadScene("stage" + SceneNum.ToString());
    }
}
