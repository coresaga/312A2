using UnityEngine;
using System.Collections;
using UnityExtensions;

public class KillClank : StaticMonoBehaviour 
{
	// Update is called once per frame
    public override void Update()
    {
        //if the player is looking at clank at less than a distanc of 2, and pressing e
        if (collider.IsLookedAtInRange(2.0F) && Input.GetKeyDown("e"))
        {
            //TODO make this do something cool
            //for now, destory it? Thats not very cool...
            Destroy(GameObject.Find("clank"));
        }
    }
}