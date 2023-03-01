using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLocation : MonoBehaviour
{
    public GameObject player;
	private Vector3 uzaklik=new Vector3(0,-12,15);
    // Update is called once per frame
    void Update()
    {
        transform.position=player.transform.position-uzaklik;
    }
}
