using UnityEngine;
using System.Collections;
using UnityExtensions;

public class BouncePad : StaticMonoBehaviour
{
    public float ForceMultiplier = 2F; //the bounce force will be equal to this number * (the players jump force)


    public override void OnCollisionEnter(Collision collision)
    {
        //TODO use the contacting object, stop looking for the player.
        var player = GameObjectExtensions.FindObjectOfType<PlayerController>(); //get the player
        player.rigidbody.AddForce(player.JumpForce * ForceMultiplier); //add the bounce force to the players rigidbody
    }
}

