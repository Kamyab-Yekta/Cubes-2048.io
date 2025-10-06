using TMPro;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    public int currentValue = 2;
    public CubeAppearanceManager appearanceManager;
    public TextMeshPro[] textMesh;

    [Header("Size Settings")]
    public float[] sizePresets = { 1.0f, 1.1f, 1.2f, 1.3f, 1.4f, 1.5f, 1.6f, 1.7f, 1.8f, 1.9f, 2.0f };
    public float baseYOffset = 0.5f;

    void Start()
    {
        if (appearanceManager == null)
        {
            appearanceManager = FindObjectOfType<CubeAppearanceManager>();
        }

        if (textMesh == null || textMesh.Length == 0)
        {
            textMesh = GetComponentsInChildren<TextMeshPro>();
        }

        UpdateAppearance();
        UpdateSizeAndPosition();
    }

    public void SetValue(int newValue)
    {
        currentValue = newValue;
        UpdateAppearance();
        UpdateSizeAndPosition();
    }

    public void UpdateAppearance()
    {
        if (textMesh != null && textMesh.Length > 0)
        {
            for (int i = 0; i < textMesh.Length; i++)
            {
                if (textMesh[i] != null)
                {
                    textMesh[i].color = GetTextColorForValue(currentValue);
                    textMesh[i].text = currentValue.ToString();
                }
            }
        }

        if (appearanceManager != null)
        {
            appearanceManager.ApplyPresetToCube(gameObject, currentValue);
        }
    }

    public void UpdateSizeAndPosition()
    {
        int sizeIndex = Mathf.Clamp((int)Mathf.Log(currentValue, 2) - 1, 0, sizePresets.Length - 1);
        float targetSize = sizePresets[sizeIndex];

        if (transform.parent != null)
        {
            Vector3 parentScale = transform.parent.lossyScale;
            Vector3 targetLocalScale = new Vector3(
                targetSize / parentScale.x,
                targetSize / parentScale.y,
                targetSize / parentScale.z
            );
            transform.localScale = targetLocalScale;
        }
        else
        {
            transform.localScale = Vector3.one * targetSize;
        }

        Vector3 currentPosition = transform.position;
        currentPosition.y = targetSize * baseYOffset;
        transform.position = currentPosition;
    }

    public Color GetTextColorForValue(int value)
    {
        switch (value)
        {
            case 2: return new Color(0.2f, 0.2f, 0.2f);
            case 4: return new Color(0.95f, 0.95f, 0.95f);
            case 8: return new Color(0.95f, 0.95f, 0.95f);
            case 16: return new Color(0.95f, 0.95f, 0.95f);
            case 32: return new Color(0.2f, 0.2f, 0.2f);
            case 64: return new Color(0.95f, 0.95f, 0.95f);
            case 128: return new Color(0.2f, 0.2f, 0.2f);
            case 256: return new Color(0.2f, 0.2f, 0.2f);
            case 512: return new Color(0.2f, 0.2f, 0.2f);
            case 1024: return new Color(0.2f, 0.2f, 0.2f);
            case 2048: return new Color(0.95f, 0.95f, 0.95f);
            default: return new Color(0.95f, 0.95f, 0.95f);
        }
    }

    public void EnablePhysics(bool enable)
    {
        Collider collider = GetComponent<Collider>();
        if (collider != null)
        {
            collider.isTrigger = !enable;
        }
    }
}