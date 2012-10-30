#pragma strict






function update()

{



}


function OnCollisionEnter(collision : Collision) {
	var Alan = GameObject.Find("PlayerAlan");
	if(collision.gameObject.tag=="Player"){ 
		Alan.GetComponent(Gravity).bounce();
 	}
}