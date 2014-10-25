using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HighlightController : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		Text text = GetComponent<Text>();

		QuestController.onItemHighlighted += (type) =>
		{
			text.text = QuestController.GetItemName(type);
			text.CrossFadeAlpha(1, .4f, false);
		};
		QuestController.onResetHighlight += () =>
		{
			text.CrossFadeAlpha(0, .4f, false);
		};
	}
}
