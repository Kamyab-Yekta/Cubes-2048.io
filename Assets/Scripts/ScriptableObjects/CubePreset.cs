using UnityEngine;

[CreateAssetMenu(fileName = "New Cube Preset", menuName = "Cube Preset")]
public class CubePreset : ScriptableObject
{
    public int value;
    public Material material;
}