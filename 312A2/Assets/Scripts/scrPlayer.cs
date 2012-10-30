using UnityEngine;
using System.Collections;

public class scrPlayer : MonoBehaviour 
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
	private float jumpForce = 500;//jump force
	
	
	
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
		if(Input.GetButtonDown("Jump"))//if user pressed jump button
			rigidbody.AddForce(0, jumpForce, 0);//push player up
	}
	
	
	

	
}









