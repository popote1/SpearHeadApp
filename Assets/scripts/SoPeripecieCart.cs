using System.Globalization;
using UnityEngine;

[CreateAssetMenu(fileName = "newPeripecieCart", menuName = "SO/PeripecieCart")]
public class SoPeripecieCart : ScriptableObject {
    public string Name;
    public Royame Royaume;
    [TextArea]public string Effect;
    
    public enum Royame
    {
        Aqshy, Ghyran
    }
}