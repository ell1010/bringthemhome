using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class critterspawner : MonoBehaviour
{
	public int spawnedcritters;
	public int crittercap;
	public float spawndelay;
	public GameObject critter;


	    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	IEnumerator spawn()
	{
		for(int i=0; i < crittercap; i++)
		{
			yield return new WaitForSeconds(spawndelay);
			//Instantiate(critter,new Vector3(transform.position.x + 0.5f, transform.position.y), quaternion.identity);
			print("spawn");
		}
		yield return null;
	}
}
