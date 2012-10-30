using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	
	

	void Start () 
    {
        Physics.gravity = new Vector3(0, -30, 0);

	}
	
	// Update is called once per frame
	void Update () 
    {
	Screen.showCursor = false;
	}
}
