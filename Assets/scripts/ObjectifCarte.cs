using UnityEngine;

public class ObjectifCarte {
    [SerializeField] private SOObjectifCart _soCarte;

    private int _playerId;
    public SOObjectifCart SOCarte { get => _soCarte; }
    public int PlayerId { get => _playerId; }
    public CartStat Stat;
    public enum CartStat {
        InDeck, InHand, Played
    }

    public ObjectifCarte (SOObjectifCart soCarte, int playerId) {
        _soCarte = soCarte;
        _playerId = playerId;
    }
}