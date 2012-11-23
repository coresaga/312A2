using UnityEngine;
using UnityExtensions;
using System.Collections.Generic;
using System.Linq;
using System;

public class VisibillityToggler : StaticMonoBehaviour
{
    public List<GameObject> ThingsToToggle; //list of things to toggle, to be taken from Unity editor

    private IEnumerable<VisibillityTogglee> _togglees; //internal list of things to toggle, parsed from the suggested list.

    public override void Awake()
    {
        ThingsToToggle = ThingsToToggle ?? Enumerable.Empty<GameObject>().ToList(); //ensure that ThingsToToggle isn't null, but is at least an empty list
        _togglees = _togglees ?? Enumerable.Empty<VisibillityTogglee>(); //ensure the private list of things to toggle isnt null, but is at least an empty set.
    }


    public override void Start()
    {
        //if Unity specified that we need to toggle null objects
        if (ThingsToToggle.Contains(null))
        {
            //throw an error, this isn't possible and it means something needs to be cleaned up in the editor. 
            throw new Exception("null element specified as target togglee");
        }

        var foundItems = GameObjectExtensions.FindObjectsOfType<VisibillityTogglee>(); //get all of the possible togglees in the level
        _togglees = foundItems.Where(item => ThingsToToggle.Contains(item.gameObject)); //our toggless = all toggles where the name matches the name of the game object specified.
        //TODO: understand the composite-component pattern here, you can probably do this with equality.

        var namedButNotFoundItems = ThingsToToggle.GameObjectNames().Except(foundItems.GameObjectNames()).ToList(); //get any items that were asked for but couldnt be found in the level

        //if there are any items that were specified by the editor but couldnt be found at runtime
        if (namedButNotFoundItems.Any())
        {
            //throw an error, something strange has happened.
            throw new Exception("the following items were requested as togglees, but could not be found: " + String.Join(", ", namedButNotFoundItems.ToArray()));
        }
    }


    public override void Update()
    {
        //if the user is pressing the fire button
        if (Input.GetButtonDown("Fire1"))
        {
			audio.Play(); //play the audio bound to fire
            
            ToggleAppropriateTogglees();//invert the existence of any bound togglees

//            Debug.Log("have togglees " + String.Join(",", _togglees.GameObjectNames().ToArray()));
//			Debug.Log("have ThingsToToggle " + String.Join(",", this.ThingsToToggle.GameObjectNames().ToArray()));
        }
	}

    private void ToggleAppropriateTogglees()
    {
        //for each of the togglees we've privately determined to be the ones we're after
        foreach (var visibillityTogglee in _togglees)
        {
            //toggle its existence
            visibillityTogglee.Toggle();
        }
    }
}
