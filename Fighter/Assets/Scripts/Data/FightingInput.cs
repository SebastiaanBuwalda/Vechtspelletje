using UnityEngine;
public class FightingInput
{
	public string[] buttons;
	private int currentIndex = 0;
	private float allowedTimeBetweenButtons = 0.3f;
	//Use this float to define how much time there is allowed between the inputs
	private float timeLastButtonPressed;
	public FightingInput(string[] _buttonsPushed)
	{
		buttons = _buttonsPushed;
	}
	public bool GetInput()
	{
		//Call this function in a a update.
		if (Time.time > timeLastButtonPressed + allowedTimeBetweenButtons) currentIndex = 0;
		{
			if (currentIndex < buttons.Length)
			{
				//Make sure that no other buttons are pressed
				if ((buttons[currentIndex] == "down" && Input.GetAxisRaw("Vertical") == -1) ||
					(buttons[currentIndex] == "up" && Input.GetAxisRaw("Vertical") == 1) ||
					(buttons[currentIndex] == "left" && Input.GetAxisRaw("Vertical") == -1) ||
					(buttons[currentIndex] == "right" && Input.GetAxisRaw("Horizontal") == 1) ||
					(buttons[currentIndex] != "down" && buttons[currentIndex] != "up" && buttons[currentIndex] != "left" && buttons[currentIndex] != "right" && Input.GetButtonDown(buttons[currentIndex])))
				{
					timeLastButtonPressed = Time.time;
					currentIndex++;
				}
				if (currentIndex >= buttons.Length)
				{
					currentIndex = 0;
					return true;
				}
				else return false;
			}
		}
		return false;
	}
}
