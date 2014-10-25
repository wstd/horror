using UnityEngine;
using System.Collections;

public class QuestEventListenerSound : MonoBehaviour {

	public QuestItem.ItemType MyType;
	public QuestItem.ItemGroup MyGroup;
	public AudioSource TargetSound;
	public string OnTriggeredPhase;

	// Use this for initialization
	void Start ()
	{
		QuestController.onEventHappened += (item) =>
		{
			if ((item.Type == MyType) && (item.Group == MyGroup))
			{
				TargetSound.Play();
				if (!string.IsNullOrEmpty(OnTriggeredPhase))
				{
					QuestController.onTalk(OnTriggeredPhase);
				}
			}
		};
	}
}
