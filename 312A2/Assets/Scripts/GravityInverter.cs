using UnityEngine;
using System.Collections;
using UnityExtensions;

public class GravityInverter : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	    RaycastHit hitResults;
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
	    var alan = GameObjectExtensions.FindObjectOfType<PlayerController>();

        if (collider.Raycast(ray, out hitResults, 100.0F) && Input.GetKeyDown("e"))
        {
            print("raycast hit and E was down!");

            Physics.gravity = Physics.gravity.AsInverted();
            GameObjectExtensions.FindObjectOfType<PlayerController>().JumpForce *= -1;
            alan.transform.up = Vector3.up.AsInverted();
            alan.rigidbody.freezeRotation = true;

            var lightables = GameObjectExtensions.FindObjectsOfType<VisibillityToggler>();
            foreach (var visibillityToggler in lightables)
            {
                visibillityToggler.Exists = true;
            }
        }
	}
}
