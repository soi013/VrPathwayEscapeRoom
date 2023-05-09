using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XrTouchButton : XRBaseInteractable
{
    private Material originalMaterial;

    [Header("XR TouchButton")]
    [SerializeField]
    private Material pushedMaterial;

    private MeshRenderer meshRenderer;

    protected override void Awake()
    {
        base.Awake();
        Debug.Log($"Awake {this.gameObject.name}");

        meshRenderer = GetComponent<MeshRenderer>();
        originalMaterial = meshRenderer.material;
    }

    protected override void OnHoverEntered(HoverEnterEventArgs args)
    {
        base.OnHoverEntered(args);

        Debug.Log($"OnHoverEntered {args}");
        meshRenderer.material = pushedMaterial;
    }

    protected override void OnHoverExited(HoverExitEventArgs args)
    {
        base.OnHoverExited(args);
        Debug.Log($"OnHoverExited {args}");
        meshRenderer.material = originalMaterial;
    }
}
