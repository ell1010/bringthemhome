using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using Unity.Mathematics;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    Rigidbody2D rb;
    InputManager im;
    bool canpickup;
    public bool carry = false;
    public float movespeed = 10;
    public float currentmspeed;
    public bool jumping;
    bool jump;
    bool canjump;
    public float jumpvel = 2;
    public float fallmulti =2.5f;
    public float lowjumpmulti =4f;
    public GameObject carrypos;
    public GameObject carryblock;
    GameObject droppreview;
	bool previewoverlap;
    void Start()
    {
        im = InputManager.instance;
        rb = this.GetComponent<Rigidbody2D>();
        canjump = true;
        currentmspeed = movespeed;
        carrypos = transform.GetChild(0).gameObject;
        droppreview = transform.GetChild(1).gameObject;
        droppreview.SetActive(false);
		
		
    }

    // Update is called once per frame
    void Update()
    {
		
        jump = im.Uppressed();
        if(im.Interactpressed())
        {
            if(canpickup)
            {
            print("pickup");
            carryblock.GetComponentInParent<Rigidbody2D>().gravityScale = 0;
			carryblock.transform.parent.GetComponent<BoxCollider2D>().enabled = false;
            carry = true;
            canpickup = false;
            droppreview.SetActive(true);
			droppreview.transform.localPosition = new Vector3(droppreview.transform.localPosition.x, -0.25f);
            currentmspeed = 8;
            }
            else if (carry)
            {
                print("putdown");
				dropBlock();
            }
        }
        if(carry)
        {
            carryblock.transform.parent.position = carrypos.transform.position;
        }
	
		// Vector2 droppos = droppreview.transform.localPosition;
		// print(Physics2D.OverlapBox(droppos, new Vector2(0.5f,0.5f),0,~layermask));
		// if(droppreview.activeInHierarchy && Physics2D.OverlapBox(droppos, new Vector2(0.5f,0.5f),0,~layermask) != null) 
		// {
		// 	previewoverlap = true;
		// 	print(previewoverlap);
		// }
		// while (previewoverlap == true)
		// {
		// 	if(Physics2D.OverlapBox(droppos, new Vector2(0.5f,0.5f),0,~layermask) != null)
		// 	{
		// 		droppos.y = droppreview.transform.localPosition.y + 1;
		// 		droppreview.transform.localPosition = droppos;
		// 		Collider2D col = Physics2D.OverlapBox(droppos, new Vector2(0.5f,0.5f),0,~layermask);
		// 		print(col.gameObject);
		// 		previewoverlap = false;
		// 	}
		// 	else
		// 	{
		// 		previewoverlap = false;
		// 	}
		// }
    }
// private void OnDrawGizmos() 
// 	{
// 		Gizmos.color = Color.black;
// 		Gizmos.DrawWireCube(droppreview.transform.position, new Vector3(0.5f,0.5f));
// 	}
    private void FixedUpdate() 
    {
        Vector3 velocity;
        //print(im.Downpressed());
        velocity = new Vector3(im.Horizontal() * currentmspeed,rb.velocity.y,0);
        if(jump && canjump)
        {
            velocity.y = 1 *jumpvel;
            canjump = false;
        }
        if (rb.velocity.y < 0 )
		{
			velocity += Vector3.up * Physics2D.gravity.y * (fallmulti - 1) * Time.deltaTime;
		} else if (velocity.y > 0 && !jump )
		{
			velocity += Vector3.up * Physics2D.gravity.y * (lowjumpmulti - 1) * Time.deltaTime;
		}
		rb.velocity = velocity;
		if(velocity.x > 0)
		droppreview.transform.localPosition = new Vector3(1.5f,droppreview.transform.localPosition.y,0);
		else if(velocity.x < 0)
		droppreview.transform.localPosition = new Vector3(-1.5f,droppreview.transform.localPosition.y,0);
			if(droppreview.activeInHierarchy)
		{
			droppreview.GetComponent<previewoverlap>().dropPreview();
		}
    }
	void previewpos()
	{
		
	}
    void dropBlock()
    {
        carry = false;
        droppreview.SetActive(false);
        currentmspeed = movespeed;
		carryblock.GetComponentInParent<Rigidbody2D>().gravityScale = 1;
		carryblock.transform.parent.GetComponent<BoxCollider2D>().enabled = true;
		carryblock.transform.parent.position = droppreview.transform.position;
		carryblock = null;
    }
    private void OnTriggerStay2D(Collider2D other) 
    {
        if(other.tag == "block" && carryblock == null)
        {
            //print("Pickup");
            canpickup = true;
            carryblock = other.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.tag == "block")
        canpickup = false;
    }
    private void OnCollisionStay2D(Collision2D other) 
    {
        if(other.gameObject.tag == "ground")
        {
            canjump = true;
            //print("ground");
        } 
    }
}
