using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class TeleportController : MonoBehaviour
{
    public XRController leftTeleportRay;
    public XRController RightTeleportRay;
    public InputHelpers.Button telepoertActivationButton;
    public float activationThreshold = 0.1f;
    public bool EnableLeftTeleport { get; set; } = true;
    public bool EnableRightTeleport { get; set; } = true;


    private void Update()
    {
        if (leftTeleportRay && EnableLeftTeleport)
        {
            leftTeleportRay.gameObject.SetActive(CheckIfActivated(leftTeleportRay));
        }
        if (RightTeleportRay && EnableRightTeleport)
        {
            RightTeleportRay.gameObject.SetActive(CheckIfActivated(RightTeleportRay));
        }
    }

    public bool CheckIfActivated(XRController controller)
    {
        InputHelpers.IsPressed(controller.inputDevice, telepoertActivationButton, out bool isActivated, activationThreshold);
        return isActivated;
    }

}
