using UnityEngine;
using System.Collections;

public class VisibleQuestTrigger : QuestTrigger {

	[HideInInspector]
	public bool InFocus = false;
	private bool prevFocusValue = false;
	
	public void LateUpdate()
	{
		if (Input.GetMouseButtonDown(0) && InFocus)
		{
			ActivateTrigger();
		}

		if (InFocus && !prevFocusValue)
		{
			EnterRaycast();
		}
		if (!InFocus && prevFocusValue)
		{
			LeaveRaycast();
		}
		
		prevFocusValue = InFocus;
		InFocus = false;
	}
	
	private void EnterRaycast()
	{
		QuestController.onItemHighlighted(MyItemType);
	}
	
	private void LeaveRaycast()
	{
		QuestController.onResetHighlight();
	}

}
