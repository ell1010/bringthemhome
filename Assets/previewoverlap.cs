using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class previewoverlap : MonoBehaviour
{
	public Vector2 droppos;
	public Vector2 startpos;
	public int layermask;
	public bool poverlap = false;

	void Awake()
	{
		layermask = 0;
		startpos = transform.position;
	}
	public void dropPreview()
	{
		//droppos = new Vector2(transform.position.x, -0.25f);
		droppos = new Vector2(transform.position.x, transform.parent.position.y -0.5f);
		transform.position = droppos;
		if(Physics2D.OverlapBox(droppos, new Vector2(0.5f,0.5f),0,~layermask) != null) 
		{
				poverlap = true;
				print(poverlap);
		}
		while (poverlap == true)
		{
			if(Physics2D.OverlapBox(droppos, new Vector2(0.5f,0.5f),0,~layermask) != null)
			{
				droppos.y = transform.position.y + 0.5f;
				transform.position = droppos;
				// Collider2D col = Physics2D.OverlapBox(droppos, new Vector2(0.5f,0.5f),0,~layermask);
				print("overlap");
			}
			else
			{
				poverlap = false;
			}
		}

	}
}
