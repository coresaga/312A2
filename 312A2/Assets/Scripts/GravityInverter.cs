using UnityEngine;
using System.Collections;
using UnityExtensions;

public class GravityInverter : StaticMonoBehaviour{

	// Update is called once per frame
	public override void OnCollisionEnter (Collision collision)
	{
	    var alan = GameObjectExtensions.FindObjectOfType<PlayerController>();

        Physics.gravity = Physics.gravity.AsInverted();
        GameObjectExtensions.FindObjectOfType<PlayerController>().JumpForce *= -1;
        alan.transform.up = Vector3.up.AsInverted();
        alan.rigidbody.freezeRotation = true;
	}
}
