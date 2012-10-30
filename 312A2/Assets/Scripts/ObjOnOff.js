#pragma strict

/*function Update () {

if (Input.GetMouseButtonDown(0)) {
    	if(renderer.enabled == false){
       		renderer.enabled = true;
       		collider.enabled = true;
       		}
       	else{
       		renderer.enabled = false;
       		collider.enabled = false;
       		}
    }


}
*/

function activate(){
	if(renderer.enabled == false){
       		renderer.enabled = true;
       		collider.enabled = true;
       		}
       	else{
       		renderer.enabled = false;
       		collider.enabled = false;
       		}
}