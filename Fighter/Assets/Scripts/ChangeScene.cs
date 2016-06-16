using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {
	
    //change scene... takes scene index integer as parameter
	public void ChangeToScene (int sceneToChangeTo)
	{
		Application.LoadLevel (sceneToChangeTo);
	}

    //reload the scene
    public void ReloadCurrentScene()
    {
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }

    //quit gimma
	public void Quit()
	{
		Application.Quit();
		Debug.Log("Quit game");
	}
}
