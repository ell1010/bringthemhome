using System.Collections.Generic;
using UnityEngine;

public class quests : MonoBehaviour
{
	public List<QuestList> questLists = new List<QuestList>();

	[System.Serializable]
	public class QuestList
	{
		public string name;
		public Sprite icon;
		public string hoverText;
		public string scrollText;
		public Sprite scrollIcon;
		public bool repeatable;
		public int repeatCount;
		public availability availability;

		public void questClicked()
		{
		
		}

	}
	public enum availability
	{
		locked,
		unlocked,
		complete
	}
}
