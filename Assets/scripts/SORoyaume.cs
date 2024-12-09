using UnityEngine;

[CreateAssetMenu(fileName = "NouveauRoyaume", menuName = "SO/NouveauRoyaume")]
public class SORoyaume: ScriptableObject
{
    public string Name;
    public SoPeripecieCart[] SoPeripecieCarts;
    public Sprite ImgTerrain;
}