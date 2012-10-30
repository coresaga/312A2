using UnityEngine;

namespace UnityExtensions
{   
    /// <summary>
    /// Provides a static interface to all methods that can be implemented via MonoDevelop.
    /// 
    /// Normally these methods are reflected on by MonoBehavior subclasses (that is, all scripts).
    /// 
    /// This class allows you to override those methods statically, giving less room for error 
    /// and inline with more traditional C# code.
    /// <seealso cref="http://docs.unity3d.com/Documentation/ScriptReference/MonoBehaviour.html"/>
    /// </summary>
    // ReSharper disable InconsistentNaming naming -- specified by MonoBehavior, cant be changed.
    // ReSharper disable VirtualMemberNeverOverriden.Global
    public abstract class StaticMonoBehaviour : MonoBehaviour
    {
        public virtual void Update(){}
        public virtual void FixedUpdate(){}
        public virtual void LateUpdate(){}
        public virtual void Awake(){}
        public virtual void Start(){}
        public virtual void Reset(){}
        public virtual void OnMouseEnter(){}
        public virtual void OnMouseOver(){}
        public virtual void OnMouseExit(){}
        public virtual void OnMouseDown(){}
        public virtual void OnMouseUp(){}
        public virtual void OnMouseUpAsButton(){}
        public virtual void OnMouseDrag(){}
        public virtual void OnTriggerEnter(Collider collision) { }
        public virtual void OnTriggerExit(){}
        public virtual void OnTriggerStay(){}
        public virtual void OnCollisionEnter(Collision collision){}
        public virtual void OnCollisionExit(Collision collision){}
        public virtual void OnCollisionStay(Collision collision){}
        public virtual void OnControllerColliderHit(){}
        public virtual void OnJointBreak(){}
        public virtual void OnParticleCollision(){}
        public virtual void OnBecameVisible(){}
        public virtual void OnBecameInvisible(){}
        public virtual void OnLevelWasLoaded(){}
        public virtual void OnEnable(){}
        public virtual void OnDisable(){}
        public virtual void OnDestroy(){}
        public virtual void OnPreCull(){}
        public virtual void OnPreRender(){}
        public virtual void OnPostRender(){}
        public virtual void OnRenderObject(){}
        public virtual void OnWillRenderObject(){}
        public virtual void OnRenderImage(RenderTexture source, RenderTexture destination) { }
        public virtual void OnDrawGizmosSelected(){}
        public virtual void OnDrawGizmos(){}
        public virtual void OnApplicationPause(){}
        public virtual void OnApplicationFocus(){}
        public virtual void OnApplicationQuit(){}
        public virtual void OnPlayerConnected(){}
        public virtual void OnServerInitialized(){}
        public virtual void OnConnectedToServer(){}
        public virtual void OnPlayerDisconnected(){}
        public virtual void OnDisconnectedFromServer(){}
        public virtual void OnFailedToConnect(){}
        public virtual void OnFailedToConnectToMasterServer(){}
        public virtual void OnMasterServerEvent(){}
        public virtual void OnNetworkInstantiate(NetworkMessageInfo info){}
        public virtual void OnSerializeNetworkView(BitStream stream, NetworkMessageInfo info) { }
        public virtual void OnAudioFilterRead(float[] data, int channels){}
    }
}
