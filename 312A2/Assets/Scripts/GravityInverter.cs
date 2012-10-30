using UnityEngine;
using System.Collections;
using UnityExtensions;

public class GravityInverter : StaticMonoBehaviour
{
    private PlayerController player;
    private bool rotatingToNewGround;

    public override void Start()
    {
        player = GameObjectExtensions.FindObjectOfType<PlayerController>();
    }

	// Update is called once per frame
	public override void OnCollisionEnter (Collision collision)
	{
        Physics.gravity = Physics.gravity.AsInverted();
        GameObjectExtensions.FindObjectOfType<PlayerController>().JumpForce *= -1;
        player.rigidbody.freezeRotation = true;

	    rotatingToNewGround = true;
	}

    public override void Update()
    {
        if(rotatingToNewGround)
        {
            player.transform.up = Vector3.Slerp(player.transform.up, Vector3.up.AsInverted(), Time.time / 100F);
            
            if(player.transform.up == Vector3.up.AsInverted())
            {
                rotatingToNewGround = false;
            }
        }
    }
}
