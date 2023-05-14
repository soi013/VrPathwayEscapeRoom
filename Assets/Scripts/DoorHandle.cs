using System.Linq;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DoorHandle : XRBaseInteractable
{
    [Header("DoorHandle")]
    [SerializeField]
    private Rigidbody targetR;

    [SerializeField]
    private Transform rock;

    private Vector3 startInteroctorPosition;


    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        startInteroctorPosition = args.interactorObject.transform.position;
    }

    void Update()
    {
        if (rock.gameObject.activeSelf)
            return;

        if (!isSelected)
            return;

        if (interactorsSelecting.FirstOrDefault() is not XRDirectInteractor interoctor)
            return;

        var diffPosition = interoctor.transform.position - startInteroctorPosition;

        targetR.velocity = new Vector3(0, 0, diffPosition.z * 2);
    }
}
