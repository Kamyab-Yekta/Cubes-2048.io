using UnityEngine;
using System.Collections.Generic;

public class CubeAppearanceManager : MonoBehaviour
{
    public CubePreset[] presets;
    public Dictionary<int, CubePreset> presetDictionary = new Dictionary<int, CubePreset>();

    void Awake()
    {
        InitializeDictionary();
    }

    void InitializeDictionary()
    {
        presetDictionary.Clear();
        foreach (CubePreset preset in presets)
        {
            if (!presetDictionary.ContainsKey(preset.value))
            {
                presetDictionary.Add(preset.value, preset);
            }
        }
    }

    public CubePreset GetPresetForValue(int value)
    {
        if (presetDictionary.ContainsKey(value))
        {
            return presetDictionary[value];
        }
        return null;
    }

    public void ApplyPresetToCube(GameObject cube, int value)
    {
        CubePreset preset = GetPresetForValue(value);
        if (preset != null)
        {
            Renderer renderer = cube.GetComponent<Renderer>();
            if (renderer != null && preset.material != null)
            {
                renderer.material = preset.material;
            }

            TextMesh textMesh = cube.GetComponentInChildren<TextMesh>();
            if (textMesh != null)
            {
                textMesh.text = value.ToString();
                textMesh.color = GetContrastColor(preset.material.color);
            }
        }
    }

    Color GetContrastColor(Color backgroundColor)
    {
        float luminance = (0.299f * backgroundColor.r + 0.587f * backgroundColor.g + 0.114f * backgroundColor.b);
        return luminance > 0.5f ? Color.black : Color.white;
    }
}