using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Keybindings", menuName = "Keybindings")]
public class KeybindingsObject : ScriptableObject
{
	[System.Serializable]
	public class keybindingcheck
	{
		public inputs input;
		public KeyCode keyCode;
	}
	public keybindingcheck[] keybinds;
}
