using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LandMinePooledScript : MonoBehaviour {

	public static LandMinePooledScript current;

	List<GameObject> pooledBullets;
	public int pooledAmount = 10;
	public bool willGrow = true;

	public GameObject Landmine;


	void Awake()
	{
		current = this;
	}

	void Start () {
		pooledBullets = new List<GameObject>();

		for(int i =0; i < pooledAmount; i++)
		{
			GameObject obj = (GameObject)Instantiate(Landmine);
			obj.SetActive(false);
			pooledBullets.Add(obj);
		}
	}

	public GameObject GetPooledObject()
	{
		for(int i=0; i < pooledBullets.Count; i++)
		{
			if(!pooledBullets[i].activeInHierarchy)
			{
				return pooledBullets[i];
			}
		}

		if(willGrow)
		{
			GameObject obj = (GameObject)Instantiate(Landmine);
			obj.SetActive(false);
			pooledBullets.Add(obj);
		}

		return null;

	}
}
