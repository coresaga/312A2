using UnityEngine;
using System.Collections;

public class VisibillityToggler : MonoBehaviour
{
    public bool ExistsInitially;

    public void Start()
    {
        Exists = ExistsInitially;
    }

    private bool _exists;
    public bool Exists
    {
        get { return _exists; }
        set
        {
            this.renderer.enabled = value;
            this.collider.enabled = value;
            _exists = value;
        }
    }
}
