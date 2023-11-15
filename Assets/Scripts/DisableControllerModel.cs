using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DisableControllerModel : MonoBehaviour
{
    [SerializeField] private GameObject leftController;
    [SerializeField] private GameObject rightController;

    private void Start()
    {
        var interactable = GetComponent<XRGrabInteractable>();
        interactable.selectEntered.AddListener(HideController);
        interactable.selectExited.AddListener(ShowController);
    }

    private void HideController(SelectEnterEventArgs args)
    {
        if (args.interactorObject.transform.CompareTag("RightController"))
        {
            rightController.SetActive(false);
        }
        else if (args.interactorObject.transform.CompareTag("LeftController"))
        {
            leftController.SetActive(false);
        }
    }

    private void ShowController(SelectExitEventArgs args)
    {
        if (args.interactorObject.transform.CompareTag("RightController"))
        {
            rightController.SetActive(true);
        }
        else if (args.interactorObject.transform.CompareTag("LeftController"))
        {
            leftController.SetActive(true);
        }
    }
}
