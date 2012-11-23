using System;
using System.Collections.Generic;
using Assets.Source_Extensions.UnityExtensions.UnityExtensions;
using UnityEngine;
using UnityExtensions;

public class GravityInverter : StaticMonoBehaviour
{
    private PlayerController _player; //the player's running script
    private bool _rotatingToNewGround; // bool used when rotation starts
    private float _rotationSoFar; // how far we've rotated since setting _rotatingToNewGround to true


    public const float RotationDelta = 2F; //how far to rotate on each frame


    public override void Start()
    {       
        _player = GameObjectExtensions.FindObjectOfType<PlayerController>();
    }


	public override void OnCollisionEnter (Collision collision)
	{
        //make sure we didn't already start rotating to new ground. This could happen if the player accidentally hits the switch twice.
        if( ! _rotatingToNewGround)
        {
            Physics.gravity = Physics.gravity.AsInverted(); //invert global gravity!
            GameObjectExtensions.FindObjectOfType<PlayerController>().JumpForce *= -1; //up is now down, so invert the jump direction

            _rotationSoFar = 0f; //reset the previous rotation value
            _rotatingToNewGround = true; //order update to start rotating the player
        }
	}


    public override void Update()
    {
        //if a rotation has been ordered
        if(_rotatingToNewGround)
        {
            _rotationSoFar += RotationDelta; //keep track of how far we've rotated

            _player.transform.Rotate(Vector3.left, RotationDelta); //Rotate about the player's left by the delta.
            //BUG: this will mess with orientation if the player looks around while being rotated.

            _rotatingToNewGround = _rotationSoFar < 180; //are we still rotating? We are if rotationSoFar is less than 180 degrees.
        }
    }

    //previously:
    //            player.transform.forward = Vector3.Slerp(player.transform.forward, player.transform.forward.AsInverted(), Time.time / 100F);
    //attempt at smoother rotation. 
    //I need f(time), where f(time) = rotation delta, and 
    //integral from now till rotation ends of f(time) = 180 degrees. 
    //            var delta = Time.time - rotatingStart;
    //            var periodAdjusted = delta * 10F;
    //            var rotationNormal = Mathf.Cos(periodAdjusted + Mathf.PI) + 1;
    //            var rotationAmplified = rotationNormal*5;
}
