using UnityEngine;
using System.Collections;

public class ColliderQuestTrigger : QuestTrigger {

	[HideInInspector]
	public bool InFocus = false;
	private bool prevFocusValue = false;
	
	private void OnTriggerEnter()
	{
		ActivateTrigger();
	}

}
