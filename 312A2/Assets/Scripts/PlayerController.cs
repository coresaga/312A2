using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Collections;
using UnityExtensions;

public class PlayerController : MonoBehaviour 
{
	
	private const float strafeSpd = 0.2f;//horizontal strafe speed
	private const float fbSpd = 0.175f;//forward backward speed
	private const float rotSpd = 2.0f;//rotation speed
    private readonly Vector3 defaultJumpForce = new Vector3(0, 500, 0);//the default jumping force of the player
    //WARN: Unity reference has angry warnings about these kind of constructor-time assignments, but it doesnt seem to do any harm...

    private Vector3[] _contactNormals; //used to keep track of the things currently contacting the player

    public Vector3 JumpForce; //the force the player jumps with.
	

	// Use this for initialization
	public void Start ()
	{
        _contactNormals = Enumerable.Empty<Vector3>().ToArray(); //initially, assume the player isn't contacting anything. 
	    JumpForce = JumpForce == default(Vector3) ? defaultJumpForce : JumpForce; //make sure the jump force isnt zero.
	}
	

	// Update is called once per frame
	public void Update () 
	{
        var straif = strafeSpd * Input.GetAxis("Strafe"); // the distance to straif = the users input in the straif direction * the straif speed factor
        var forward = fbSpd * Input.GetAxis("ForwardBack"); // the distance to move forward or backward (fb) = the users input fb * the fb speed factor
        var rotation = rotSpd * Input.GetAxis("Rotate"); // the rotation to apply = the users rotational input * the rotational speed factor

	    var motion = new Vector3(straif, 0, forward); // total motion vector is a vector containing straif in X, fb in Z, nothing in y (no vertical movement is possible outside of jump)

        //ensure the player cant move in the direction of a contact: remove the projection of the all contacts normal vectors from the motion vector
	    motion = _contactNormals.Aggregate(motion, (current, contactNormal) => current - Vector3.Project(current, contactNormal));

	    transform.Translate(motion);//movement in X , Z
        transform.Rotate(Vector3.up, rotation);//rotate player around Y

        //if the user is trying to jump and hes contacting something
        //BUG allows for wall jumping.
        if (Input.GetButtonDown("Jump") && _contactNormals.Any())
        {
            rigidbody.AddForce(JumpForce); //push player up
        }
	}


    public void OnCollisionEnter(Collision collision)
    {
        //get each of the contacts direction of contact. 
        _contactNormals = collision.contacts.Select(contact => contact.normal).ToArray();
    }


    public void OnCollisionExit(Collision collision)
    {
        //remove the contacts that we're leaving from the collision
        _contactNormals = _contactNormals.Except(collision.contacts.Select(contact => contact.normal)).ToArray();
    }

}







