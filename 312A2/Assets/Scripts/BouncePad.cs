using UnityEngine;
using System.Collections;
using UnityExtensions;

public class BouncePad : StaticMonoBehaviour
{
    public float ForceMultiplier = 20f;

    public override void OnCollisionEnter(Collision collision)
    {
        //TODO b009f218b0c6: use the contacting object, stop looking for the player.
        var player = GameObjectExtensions.FindObjectOfType<PlayerController>();
        player.rigidbody.AddForce(Physics.gravity * -1 * ForceMultiplier);
    }
}

