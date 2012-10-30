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
            var CameraView = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit castHit;
            if (collider.Raycast(CameraView, out castHit, minDistanceToItem))
            {
                ToggleAppropriateTogglees();
            }
        }
    }

    private bool UserViewingAndProximateToItem()
    {
        var CameraView = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit castHit;
        return collider.Raycast(CameraView, out castHit, minDistanceToItem);
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
