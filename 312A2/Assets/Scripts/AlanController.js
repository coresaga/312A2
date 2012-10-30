	var strafeSpd = 0.2;//horizontal strafe speed
	var fbSpd = 0.35;//forward backward speed
	var rotSpd = 2.0;//rotation speed
	var jumpForce = 500;//jump force
	
	
	
	// Use this for initialization
	function Start () 
		{
		rigidbody.freezeRotation = true;
	}
	
	
	
	// Update is called once per frame
	function Update () 
	{
	
	}
	
	
	
	//sure to run each frame
	function FixedUpdate()
	{
		var s = strafeSpd * Input.GetAxis("Strafe");
		var fb = fbSpd * Input.GetAxis("ForwardBack");
		var r = rotSpd * Input.GetAxis("Rotate");
		
		transform.Translate(s, 0, fb);//movement in X , Z
		transform.Rotate(Vector3.up, r);//rotate player around Y
		if(Input.GetButtonDown("Jump"))
		{
			rigidbody.AddForce(0, jumpForce, 0);
		}//push player up
	}
	
	
	

	










