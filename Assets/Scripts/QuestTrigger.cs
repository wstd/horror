using UnityEngine;
using System.Collections;

public class QuestTrigger : MonoBehaviour
{
	public QuestItem.ItemType MyItemType;
	public QuestItem.ItemType RequiredItemType;
	public QuestItem.ItemGroup ItemGroup;
	public bool DestroyMe;
	public bool DestroyUsedItem;
	public bool Takeable;
	public string NoItemPhrase;
	public string PickItemPhrase;

	protected void ActivateTrigger()
	{
		if (Takeable)
		{
			QuestController.AddToInventory(GetMyQuestItem());
			QuestController.onTalk(PickItemPhrase);
		}

		if (DestroyMe)
		{
			Destroy(gameObject);
		}

		if (RequiredItemType != QuestItem.ItemType.None)
		{
			if (QuestController.HasInInventory(RequiredItemType, ItemGroup))
			{
				QuestController.UseInventoryItem(RequiredItemType, ItemGroup, DestroyUsedItem);
				QuestController.onEventHappened(GetMyQuestItem());
			}
			else
			{
				QuestController.onTalk(NoItemPhrase);
			}
		}
		else
		{
			QuestController.onEventHappened(GetMyQuestItem());
		}
	}

	private QuestItem GetMyQuestItem()
	{
		return new QuestItem() {Type = MyItemType, Group = ItemGroup};
	}
}
