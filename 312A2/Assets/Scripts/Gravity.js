#pragma strict


var force = -25;
var bounceForce = 120;

function Start () {


}

function Update () {
    rigidbody.AddForce (0, force, 0);
}


function invert() {


force = -force;

}

function bounce(){
 	rigidbody.AddForce (0, -force * bounceForce, 0);
 	}