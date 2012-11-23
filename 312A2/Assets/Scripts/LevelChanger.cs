using System;
using UnityEngine;
using System.Collections;
using UnityExtensions;

public class LevelChanger : StaticMonoBehaviour {

    public string NextLevel;

    public override void Start()
    {
        //if no next level was specified
        if (NextLevel == null)
        {

            //this script is useless, throw an error
            throw new Exception("no level specified to load!");
        }
    }

    //when the user clips this box load the next level
    //TODO use a trigger? Conceptually it fits better.
    public override void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Changing levels to " + NextLevel);
        Application.LoadLevel(NextLevel);
    }
}
