using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class QuestItem
{
	public enum ItemType
	{
		None = 0,
		Key = 1,
		Door = 2,
		Mystery = 3
	}

	public enum ItemGroup
	{
		None = 0,
		StoreRoom = 1,
		Corridor = 2
	}

	public ItemType Type;
	public ItemGroup Group;
}

public class QuestController
{
	private static Dictionary<QuestItem.ItemType, string> ItemNames = new Dictionary<QuestItem.ItemType, string>()
	{
		{QuestItem.ItemType.None, "Ничего"},
		{QuestItem.ItemType.Door, "Дверь"},
		{QuestItem.ItemType.Key, "Ключ"}
	};

	private static List<QuestItem> inventory = new List<QuestItem>();

	public static Action<QuestItem> onEventHappened = (o)=>{};
	public static Action<string> onTalk = (o)=>{};
	public static Action<QuestItem> onItemUsed = (o)=>{};
	public static Action<QuestItem.ItemType> onItemHighlighted = (o)=>{};
	public static Action onResetHighlight = ()=>{};

	public static void AddToInventory(QuestItem item)
	{
		inventory.Add(item);
	}

	public static bool HasInInventory(QuestItem.ItemType type, QuestItem.ItemGroup group)
	{
		return inventory.Exists(x => x.Type == type && x.Group == group);
	}

	public static void UseInventoryItem(QuestItem.ItemType type, QuestItem.ItemGroup group, bool withDestroy)
	{
		QuestItem needItem = inventory.Find(x => x.Type == type && x.Group == group);
		onItemUsed(needItem);
		if (withDestroy)
		{
			inventory.Remove(needItem);
		}
	}

	public static string GetItemName(QuestItem.ItemType type)
	{
		return ItemNames[type];
	}
}
