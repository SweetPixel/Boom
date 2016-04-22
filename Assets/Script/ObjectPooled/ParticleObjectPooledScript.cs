using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ParticleObjectPooledScript : MonoBehaviour {

	public static ParticleObjectPooledScript current;

	List<GameObject> pooledPraticle;
	public int pooledAmount = 10;
	public bool willGrow = true;

	public GameObject particleSystem;


	void Awake()
	{
		current = this;
	}

	void Start () {
		pooledPraticle = new List<GameObject>();

		for(int i =0; i < pooledAmount; i++)
		{
			GameObject obj = (GameObject)Instantiate(particleSystem);
			obj.SetActive(false);
			pooledPraticle.Add(obj);
		}
	}

	public GameObject GetPooledObject()
	{
		for(int i=0; i < pooledPraticle.Count; i++)
		{
			if(!pooledPraticle[i].activeInHierarchy)
			{
				return pooledPraticle[i];
			}
		}

		if(willGrow)
		{
			GameObject obj = (GameObject)Instantiate(particleSystem);
			obj.SetActive(false);
			pooledPraticle.Add(obj);
		}

		return null;

	}

}
