using UnityEngine;
using System.Collections;

public class DrawHealthBars : MonoBehaviour {
	[SerializeField]
	private float barDisplay; //current progress

	[SerializeField]
	private Vector2 pos = new Vector2(20,40);
	[SerializeField]
	private Vector2 size = new Vector2(60,20);

	[SerializeField]
	private Texture2D emptyTex;
	[SerializeField]
	private Texture2D fullTex;

	[SerializeField]
	//private Health linkedHealth;

	void OnGUI() 
	{
		//draw the background:
		GUI.BeginGroup(new Rect(pos.x, pos.y, size.x, size.y));
		GUI.Box(new Rect(0,0, size.x, size.y), emptyTex);

		//draw the filled-in part:
		GUI.BeginGroup(new Rect(0,0, size.x * barDisplay, size.y));
		GUI.Box(new Rect(0,0, size.x, size.y), fullTex);
		GUI.EndGroup();
		GUI.EndGroup();
	}

	void Update() 
	{
		//barDisplay = (/);
		//        barDisplay = MyControlScript.staticHealth;
	}
}