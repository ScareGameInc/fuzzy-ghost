using UnityEngine;
using System.Collections;

public class Respawner : MonoBehaviour
{
	private ArrayList respawnList;
	private ArrayList respawnTimes;
		
	// Use this for initialization
	void Start ()
	{
		respawnList = new ArrayList();
		respawnTimes = new ArrayList();
	}
	
	// Update is called once per frame
	void Update ()
	{
		for(int i = 0; i<respawnTimes.Count; ++i){
			float val = (float)respawnTimes[i];
			val +=Time.deltaTime;
			respawnTimes[i] = val;
			if(val>=10.0f){
				GameObject g = (GameObject)respawnList[i];
				g.SetActive(true);
			
				g.transform.position = g.GetComponent<Item>().getSpawnCoordinates();
				GameObject originalObject = g.GetComponent<Item>().originalObject;
				GameObject t = (GameObject)GameObject.Instantiate(g);
				t.transform.parent = g.transform.parent;
				t.transform.position = g.transform.position;
				t.transform.rotation = originalObject.transform.rotation;
				Renderer[] render = t.GetComponentsInChildren<Renderer>();
				for(int j = 0; j<render.Length; ++j){
					render[j].enabled = true;
				}
				g.SetActive(false);
				originalObject.SetActive(false);
				respawnList.RemoveAt(i);
				respawnTimes.RemoveAt(i);
				
			}
		}
	}
	
	public void addToRespawnList(GameObject o){
		respawnList.Add(o);
		ArrayList temp = new ArrayList(respawnList.Count);
		for(int i = 0; i<respawnTimes.Count; ++i)
		{
			temp.Add(respawnTimes[i]);
		}
		temp.Add(0.0f);
		respawnTimes = temp;
	}
	
}

