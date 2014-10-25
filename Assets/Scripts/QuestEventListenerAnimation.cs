using UnityEngine;
using System.Collections;

public class QuestEventListenerAnimation : MonoBehaviour {

	public QuestItem.ItemType MyType;
	public QuestItem.ItemGroup MyGroup;
	public Animation TargetAnim;
	public string OnTriggeredPhase;

	// Use this for initialization
	void Start ()
	{
		QuestController.onEventHappened += (item) =>
		{
			if ((item.Type == MyType) && (item.Group == MyGroup))
			{
				TargetAnim.Play();
				QuestController.onTalk(OnTriggeredPhase);
			}
		};
	}
}
