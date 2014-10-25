using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Logger : MonoBehaviour {

	private string currentText;
	private Text text;
	private float lastLogTime;

	// Use this for initialization
	void Start ()
	{
		text = GetComponent<Text>();
		currentText = "";
		lastLogTime = Time.time;

		QuestController.onTalk += (phrase) =>
		{
			text.color = new Color(1,1,1,1);
			currentText = phrase;
			lastLogTime = Time.time;
		};
	}

	void Update()
	{
		float coef = Mathf.Clamp(Time.time - lastLogTime, 0, 1);
		if (coef == 1)
		{
			float secondCoef = Mathf.Clamp(Time.time - lastLogTime, 1, 2) - 1;
			text.color = new Color(1,1,1, 1 - secondCoef);
		}

		text.text = currentText.Substring(0, Mathf.RoundToInt((float)currentText.Length * coef));
	}

}
