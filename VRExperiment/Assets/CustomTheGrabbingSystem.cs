using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class CustomTheGrabbingSystem : XRGrabInteractable
{
    public Transform Handler ;

  
    
    // custom grabable code. whene release the handeller then its move to the pervious position 
    protected override void OnSelectExited(XRBaseInteractor interactor)
    {
        base.OnSelectExited(interactor);
        Rigidbody rbHandler = Handler.GetComponent<Rigidbody>();
        rbHandler.velocity = Vector3.zero;
        rbHandler.angularVelocity = Vector3.zero;
        transform.position = Handler.position;
        transform.rotation = Handler.rotation;
        transform.localScale = new Vector3(1, 1, 1);
    }

}
