using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Collections;
using UnityExtensions;

public class PlayerController : StaticMonoBehaviour 
{
	//public static float hp;//hitpoints
	//public const float fullHp = 500.0f;//full hitpoints
	//private const float buffSpace = 10;//space around gui stuff so it's not just against the edge of the game screen
	//public Texture2D textureHealth;//healthbar image
	//public Texture2D textureDead;//image for the sayDead() message
	//private const int tdw = 128;//texture of the dead message's width
	//private const int tdh = 128;
	//private bool isDead = false;//toggle for when the player dies to ensure the sayDead() only happens once
	
	private float strafeSpd = 0.2f;//horizontal strafe speed
	private float fbSpd = 0.35f;//forward backward speed
	private float rotSpd = 2.0f;//rotation speed

    private Vector3? _contactNormal;
    private Vector3? ContactNormal
    {
        get { return _contactNormal; }
        set
        {
            print("contact normal is " + value);
            _contactNormal = value;
        }
    }

    public Vector3 JumpForce = new Vector3(0, 500, 0);
	
	// Use this for initialization
	public override void Start () 
	{
	}
	
	// Update is called once per frame
	public override void Update () 
	{
        var straif = strafeSpd * Input.GetAxis("Strafe");
        var forward = fbSpd * Input.GetAxis("ForwardBack");
        var rotation = rotSpd * Input.GetAxis("Rotate");

	    var motion = new Vector3(straif, 0, forward);


//        if (ContactNormal != null)
//        {
//            motion = (motion.normalized + ContactNormal.Value) * motion.magnitude;
//        }

        transform.Translate(motion);//movement in X , Z
        transform.Rotate(Vector3.up, rotation);//rotate player around Y

        if (Input.GetButtonDown("Jump") && ContactNormal != null)
        {
            rigidbody.AddForce(JumpForce); //push player up
        }
	}

    public override void OnCollisionEnter(Collision collision)
    {
        var contact = collision.contacts.Select(point => point.normal).Average().normalized;
        contact.y = 0;
        ContactNormal = contact;
    }
    public override void OnCollisionExit(Collision collision)
    {
        ContactNormal = null;
        print("exited colision");
    }

}

public struct WorkingVector
{
    public static WorkingVector Zero
    {
        get
        {
            return new WorkingVector();
        }
    } 

    public float x { get; set; }
    public float y { get; set; }
    public float z { get; set; }

    public static WorkingVector operator +(WorkingVector left, Vector3 right)
    {
        return new WorkingVector()
                   {
                       x = left.x + right.x,
                       y = left.y + right.y,
                       z = left.z + right.z
                   };
    }

    public Vector3 ToVector3()
    {
        return new Vector3(x, y, z);
    }
}

public static class Vector3Extensions
{
    public static Vector3 AsInverted(this Vector3 original)
    {
        return new Vector3(-original.x, -original.y, -original.z);
    }

    public static Vector3 Average(this IEnumerable<Vector3> vectors)
    {
        return vectors.Aggregate(WorkingVector.Zero, (workingVector, next) => workingVector + next).ToVector3();
    }
}

public static class RigidBodyExtensions
{
    public static void RemoveForce(this Rigidbody body, Vector3 force)
    {
        body.AddForce(force.AsInverted());
    }
}









