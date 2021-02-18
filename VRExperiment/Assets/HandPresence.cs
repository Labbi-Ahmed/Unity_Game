using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandPresence : MonoBehaviour
{   
    public bool ShowHandModel = true;
    public InputDeviceCharacteristics Characteristices;
    public GameObject Handprefb;
    public List<GameObject> controllerPrefab;// = new List<GameObject>();
    

    private GameObject spawnedController;
    private GameObject spawnedHand;
    private InputDevice targetDevice;
    private Animator handAnimator;
    // Start is called before the first frame update
    void Start()
    {
        TryInitialize();
    }

    void TryInitialize()
    {
        Debug.LogWarning("Call it ");

        List<InputDevice> device = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(Characteristices, device);

        if (device.Count > 0)
        {
            targetDevice = device[0];
            GameObject prefab = controllerPrefab.Find(controller => controller.name == targetDevice.name);
            if (prefab)
            {
                spawnedController = Instantiate(prefab, transform);
            }
            else
            {
                Debug.LogError("Didn't find the apropiat hand controller " + targetDevice.name);
                spawnedController = Instantiate(controllerPrefab[0], transform);
            }
        }


        spawnedHand = Instantiate(Handprefb, transform);
        handAnimator = spawnedHand.GetComponent<Animator>();

    }


    private void Update()
    {
        //if (!targetDevice.isValid)
        //{
        //    TryInitialize();
        //}
        //else
        //{
             if (ShowHandModel)
             {
                  spawnedHand.SetActive(true);
                  spawnedController.SetActive(false);
                  ControllerInputChecker();
             }
             else
             {
                 spawnedController.SetActive(true);
                 spawnedHand.SetActive(false);
           
             }
       // }     
    }

   
    void ControllerInputChecker()
    {
        
        if (targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue) && triggerValue > 0.1f)
        {
            handAnimator.SetFloat("Trigger", triggerValue);
            //Debug.Log(triggerValue);
        }


        if (targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue) && gripValue > 0.1f)
            handAnimator.SetFloat("Grip", gripValue);

       
       // if (targetDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 axisvalue) && axisvalue != Vector2.zero)
            //Debug.Log("axis value " + axisvalue);
       
        //if (targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButton) && primaryButton)
           // Debug.Log("Show primary Value :" + primaryButton);

    }

}
