using UnityEngine;
public class PauseMenu : MonoBehaviour 
{
	[SerializeField]
	private GameObject[] pauseGameobjects;
	[SerializeField]
	private GameObject[] nonPauseGameobjects;

	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			Pause ();		
		}
	}

	public void Pause()
	{
			if (Time.timeScale == 0)
			{
				Time.timeScale = 1;
				foreach (GameObject g in pauseGameobjects) 
				{
					g.SetActive (false);
				}
				foreach (GameObject g in nonPauseGameobjects) 
				{
					g.SetActive (true);
				}
			} 
			else 
			{
				Time.timeScale = 0;
				foreach (GameObject g in pauseGameobjects) 
				{
					g.SetActive (true);
				}
				foreach (GameObject g in nonPauseGameobjects) 
				{
					g.SetActive (false);
				}
		}    
	}
}
