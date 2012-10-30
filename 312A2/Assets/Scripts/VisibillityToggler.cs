using UnityEngine;
using UnityExtensions;
using System.Collections.Generic;
using System.Linq;
using System;

public class VisibillityToggler : StaticMonoBehaviour
{
    public List<string> ThingsToToggle;
    public float minDistanceToItem = 100f;

    private IEnumerable<VisibillityTogglee> togglees;

    public override void Start()
    {
        var foundItems = GameObjectExtensions.FindObjectsOfType<VisibillityTogglee>();
        togglees = foundItems.Where(item => ThingsToToggle.Contains(item.name));

        var namedButNotFoundItems = ThingsToToggle.Except(foundItems.Select(item => item.name));
        if (namedButNotFoundItems.Any())
        {
            throw new Exception("the following items were requested as togglees, but could not be found: " + namedButNotFoundItems.ToList());
        }
    }

    public override void Update()
    {
        if (Input.GetButtonDown("Fire1") && UserViewingAndProximateToItem())
        {
            print("fire and viewing and proxmiate!");
            ToggleAppropriateTogglees();
        }
    }

    private bool UserViewingAndProximateToItem()
    {
        print("asking if user is viewing and proximate");
        var cameraView = Camera.main.ScreenPointToRay(new Vector3(Screen.width/2F, Screen.height/2F, 0));
        Debug.DrawRay(cameraView.origin, cameraView.direction, Color.yellow);
        RaycastHit castHit;
        return collider.Raycast(cameraView, out castHit, minDistanceToItem);
    }

    private void ToggleAppropriateTogglees()
    {
        var itemsToToggle = togglees;

        foreach (var visibillityTogglee in itemsToToggle)
        {
            visibillityTogglee.Toggle();
        }
    }
}
