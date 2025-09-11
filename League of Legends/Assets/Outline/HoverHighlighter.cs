using UnityEngine;
using UnityEngine.UI;

public class HoverHighlighter : MonoBehaviour
{
    [Header("Raycast & Layer")]
    [SerializeField] private LayerMask unitLayer;

    [Header("Glow Outline Settings")]
    private Color outlineColor;
    [SerializeField] private float outlineThickness = 0.02f;
    [SerializeField] private float glowIntensity = 2f;

    private Camera mainCamera;
    private GameObject lastHighlighted;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, unitLayer))
        {
            GameObject target = hit.collider.gameObject;

            if (target != lastHighlighted)
            {
                ClearHighlight();
                ApplyHighlight(target);
                lastHighlighted = target;
            }
        }
        else
        {
            ClearHighlight();
        }
    }

    private void ApplyHighlight(GameObject obj)
    {
        var rend = obj.GetComponent<Renderer>();

        Color glowColor = outlineColor;
        if (obj.CompareTag("RedSide"))
        {
            glowColor = Color.red;
        }
        else if (obj.CompareTag("BlueSide"))
        {
            glowColor = Color.blue;
        }
        else
        {
            glowColor = Color.yellow;
        }

        if (rend != null)
        {
            var mpb = new MaterialPropertyBlock();
            rend.GetPropertyBlock(mpb);

            mpb.SetFloat("_OutlineEnabled", 1f);
            mpb.SetColor("_OutlineColor", glowColor);
            mpb.SetFloat("_Thickness", outlineThickness);
            mpb.SetFloat("_GlowIntensity", glowIntensity);

            rend.SetPropertyBlock(mpb);
        }
    }

    private void ClearHighlight()
    {
        if (lastHighlighted != null)
        {
            var rend = lastHighlighted.GetComponent<Renderer>();

            if (rend != null)
            {
                var mpb = new MaterialPropertyBlock();
                rend.GetPropertyBlock(mpb);
                mpb.SetFloat("_OutlineEnabled", 0f);
                rend.SetPropertyBlock(mpb);
            }

            lastHighlighted = null;
        }
    }
}
