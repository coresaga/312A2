using UnityEngine;
using System.Collections;
using UnityExtensions;
using System.Linq;

public class GameController : StaticMonoBehaviour 
{
	
	public override void Awake () 
    {
        Screen.showCursor = false; //BUG does not function as expected...
	    Physics.gravity = 1.5F * new Vector3(0, -9.8F, 0); //whatever shinanigens we did to gravity previously, lets make sure it makes sense when we reload the game Controller.

        //TODO figure out how to stop prefabs from over-ruling their in-unity field setters when "applied"
        //if the loaded level is level 3...
        if(Application.loadedLevelName == "level3")
        {
            //algorithmically get all the togglees: this level simply binds all of the toglees to the player, so get all of them.
            var allSceneTogglees = GameObjectExtensions.FindObjectsOfType<VisibillityTogglee>().Select(item => item.gameObject);
            var toggler = GameObjectExtensions.FindObjectOfType<VisibillityToggler>(); //get the controlling toggler
            toggler.ThingsToToggle.AddRange(allSceneTogglees); //add the things to toggle to the toggling controller
        }
            
    }

}
