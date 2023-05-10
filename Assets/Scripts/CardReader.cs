using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CardReader : XRSocketInteractor
{
    [Header("CardReader")]
    [SerializeField]
    private Transform enterPoint;

    [SerializeField]
    private Transform exitPoint;

    private Vector3 targetDirection;

    private Vector3 enterPosition;

    [SerializeField]
    private AudioSource audioSuccess;

    private void Awake()
    {
        targetDirection = (exitPoint.position - enterPoint.position).normalized;
    }

    protected override void OnHoverEntered(HoverEnterEventArgs args)
    {
        base.OnHoverEntered(args);
        Debug.Log($"CardReader OnHoverEntered interactableObject {args.interactableObject}");
        Debug.Log($"CardReader OnHoverEntered interactorObject {args.interactorObject}");

        if (args.interactableObject is not XRGrabInteractable card)
            return;

        enterPosition = card.transform.position;

        Debug.Log($"CardReader OnHoverEntered {card.name} rotation={card.transform.rotation}");
    }

    protected override void OnHoverExited(HoverExitEventArgs args)
    {
        base.OnHoverExited(args);

        Debug.Log($"CardReader OnHoverExited interactableObject {args.interactableObject}");
        Debug.Log($"CardReader OnHoverExited interactorObject {args.interactorObject}");

        if (args.interactableObject is not XRGrabInteractable card)
            return;

        var diffPosition = (card.transform.position - enterPosition).normalized;
        var dotValue = Vector3.Dot(diffPosition, targetDirection);

        Debug.Log($"CardReader OnHoverExited {new { card.name, card.transform.position, targetDirection, diffPosition, dotValue }}");

        if (dotValue > 0.8)
            OpenDoor();
    }

    private void OpenDoor()
    {
        audioSuccess.Play();
    }
}
