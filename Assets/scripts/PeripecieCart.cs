using UnityEngine;

public class PeripecieCart  {
    [SerializeField] private SoPeripecieCart _soCarte;
    public CarteStat Stat;
    public enum CarteStat {
        InDeck, InGame, Played
    }
    public SoPeripecieCart SoCarte { get => _soCarte; }

    public PeripecieCart(SoPeripecieCart soCarte) {
        _soCarte = soCarte;
    }
}