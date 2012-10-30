#pragma strict
var rot180 = 180;
function Start(){


}
	
function Update(){
    
    var hit : RaycastHit;
    var ray : Ray = Camera.main.ScreenPointToRay (Input.mousePosition);
    var myFaller = GameObject.Find("Faller");
	var myIndicator = GameObject.Find("Indicator");
    var Alan = GameObject.Find("PlayerAlan");
    
       
    if (collider.Raycast(ray, hit, 100.0) && Input.GetKeyDown ("e")) {
    	myFaller.GetComponent(Gravity).invert();
    	Alan.GetComponent(Gravity).invert();
    	Alan.GetComponent(AlanController).jumpForce = - Alan.GetComponent(AlanController).jumpForce;
    	Alan.transform.Rotate(0,0,-rot180);
    	myIndicator.GetComponent(ObjOnOff).activate();
    	
    	
    	
    	
    }
}