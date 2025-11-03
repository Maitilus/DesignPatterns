using UnityEngine;

/// <summary>
/// Adjusts the material tiling based on the GameObject's world scale
/// to ensure the texture always appears 1x1 unit in world space.
/// </summary>
[ExecuteAlways] // Runs in Edit Mode as well, great for testing!
public class WorldSpaceTiler : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    private Material sharedMaterial;

    // The name of the texture property to adjust (usually "_BaseMap" or "_MainTex")
    [SerializeField]
    private string texturePropertyName = "_BaseMap"; 

    void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        if (meshRenderer != null)
        {
            // Use sharedMaterial to avoid creating a new material instance every time
            sharedMaterial = meshRenderer.sharedMaterial;
        }
        else
        {
            Debug.LogError("WorldSpaceTiler requires a MeshRenderer component.");
            this.enabled = false;
        }
    }

    void Update()
    {
        if (sharedMaterial == null) return;

        // Get the current world scale of the object
        Vector3 scale = transform.localScale;

        // Calculate the tiling needed for the texture to cover the object exactly 
        // with 1x1 world units.
        Vector2 newTiling = new Vector2(scale.x, scale.z);

        // Apply the new tiling to the material.
        // We use the property name to ensure compatibility with different shaders.
        sharedMaterial.SetTextureScale(texturePropertyName, newTiling);
    }
}