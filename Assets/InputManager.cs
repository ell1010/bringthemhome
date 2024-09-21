using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
	public static InputManager instance
	{
		get { return im; }
	}
	private static InputManager im = null;
	[SerializeField]
	private KeybindingsObject keybinds;
	private void Awake()
	{
		if (im != null)
		{
			DestroyImmediate(gameObject);
			return;
		}
		DontDestroyOnLoad(gameObject);
		im = this;
	}

	public bool Uppressed()
	{
		return Input.GetKey(keybinds.keybinds[(int)inputs.Up].keyCode);
	}
	public bool Downpressed()
	{
		return Input.GetKey(keybinds.keybinds[(int)inputs.Down].keyCode);
	}
	public bool Leftpressed()
	{
		return Input.GetKey(keybinds.keybinds[(int)inputs.Left].keyCode);
	}
	public bool Rightpressed()
	{
		return Input.GetKey(keybinds.keybinds[(int)inputs.Right].keyCode);
	}
	public bool Pausepressed()
	{
		return Input.GetKeyDown(keybinds.keybinds[(int)inputs.pause].keyCode);
	}

	public bool Interactpressed()
	{
		return Input.GetKeyDown(keybinds.keybinds[(int)inputs.interact].keyCode);
	}

	public int Horizontal()
	{
		return Convert.ToInt32 (Rightpressed()) - Convert.ToInt32 (Leftpressed());
	}

	public int vertical()
	{
		return Convert.ToInt32 (Uppressed()) - Convert.ToInt32 (Downpressed());
	}
}
