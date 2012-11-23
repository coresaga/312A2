using System.Linq;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityExtensions;

public class VisibillityTogglee : MonoBehaviour
{
    public bool ExistsInitially; //public specification for whether or not we can see this object right away

    public void Start()
    {
        //assign the interal tracker to use the one specified by unity
        Exists = ExistsInitially;
    }

    private bool _exists; //internal tracker of existence
    public bool Exists //public tracker of existence
    {
        get { return _exists; } //on reads just return whats already there
        set
        {
            //copy to the internal value
            _exists = value;
            renderer.enabled = _exists; //set the renderer on this object
            collider.enabled = _exists; //set the collider on this object

            //make sure all child objects also have their renderes disabled, if they have one
            foreach (var childRenderer in  gameObject.GetComponentsInChildren<Renderer>())
            {
                childRenderer.enabled = _exists;
            }
            //make sure all child objects also have their colliders disabled, again, if they have one.
            foreach (var childCollider in gameObject.GetComponentsInChildren<Collider>())
            {
                childCollider.enabled = _exists;
            }
        }
    }

    //public convienience method, simply invert the value as it is. 
    public void Toggle()
    {
        Exists = !Exists;
    }
}
