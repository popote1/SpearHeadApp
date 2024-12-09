using UnityEngine;
using UnityEngine.Rendering;

[CreateAssetMenu(fileName = "newObjectifCart", menuName = "SO/ObjectifCart")]
public class SOObjectifCart : ScriptableObject
{
    [Header("ObjectifPart")] public string ObjectifName;
    [TextArea] public string ObjectifDescription;

    [Space(10), Header("OrderPart")] 
    public phase Phase;
    public bool ISOncePerBattle;
    public bool IsReaction;
    public string OrderName;
    [TextArea]public string OrderDescription;
    public string OrdreMotClef;

    public string GetPhase() {
        string s= "";
        if (IsReaction) s += "Réaction ";
        if (ISOncePerBattle) s += "une fois par bataille ";
        s += Phase.ToString();
        return s;
    }

    public enum phase{
        none, StartTurn, HeroPhase, MovePhase, ShootingPhase, ChargePhase, CombatPhase, EndTurn, Attaque}
}