using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
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

    private bool jumped;

    public Vector3 JumpForce = new Vector3(0, 500, 0);
	
	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
	}
	
	//sure to run each frame
	void FixedUpdate()
	{
		float s = strafeSpd * Input.GetAxis("Strafe");
		float fb = fbSpd * Input.GetAxis("ForwardBack");
		float r = rotSpd * Input.GetAxis("Rotate");
		
		transform.Translate(s, 0, fb);//movement in X , Z
		transform.Rotate(Vector3.up, r);//rotate player around Y

        if (Input.GetButtonDown("Jump"))
        {
            jumped = true;
            rigidbody.AddForce(JumpForce); //push player up
        }
	}


}

public static class Vector3Extensions
{
    public static Vector3 AsInverted(this Vector3 original)
    {
        return new Vector3(-original.x, -original.y, -original.z);
    }
}

public static class RigidBodyExtensions
{
    public static void RemoveForce(this Rigidbody body, Vector3 force)
    {
        body.AddForce(force.AsInverted());
    }
}









