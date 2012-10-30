using UnityEngine;
using System.Collections.Generic;
using UnityExtensions;
using System.Linq;

public class VisibillityToggler : StaticMonoBehaviour
{
    public List<string> ThingsToToggle;
    public float minDistanceToItem = 100f;

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
        var foundItems = GameObjectExtensions.FindObjectsOfType<VisibillityTogglee>();
        var itemsToToggle = foundItems.Where(item => ThingsToToggle.Contains(item.name));

        foreach (var visibillityTogglee in itemsToToggle)
        {
            visibillityTogglee.Toggle();
        }
    }
}
