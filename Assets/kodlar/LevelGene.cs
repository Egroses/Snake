using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGene : MonoBehaviour
{
	
	public float distance=40f;
    [SerializeField]private List<Transform> Levels;
	public GameObject player;
	private Vector3 LastEnd;

	private void Awake() {
		LastEnd=Levels[4].Find("EndPosition").position;
	}
	private void Update() {
		if(Vector3.Distance(player.transform.position,LastEnd)<distance){
			SpawnLevel();
		}
	}

	void SpawnLevel(){
		Transform randommap=Levels[Random.Range(0,Levels.Count)];
		Transform endfinder=SpawnLevel(randommap,LastEnd);
		LastEnd=endfinder.transform.Find("EndPosition").position;
	}

	Transform SpawnLevel(Transform map,Vector3 location){
		Transform donus=Instantiate(map,location,Quaternion.identity);
		return donus;
	}


}
