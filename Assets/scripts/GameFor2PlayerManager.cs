using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;
using Random = UnityEngine.Random;

public class GameFor2PlayerManager : MonoBehaviour
{
    [SerializeField] private PanelMenu _panelMenu;
    [SerializeField] private PanelObjectifCart _panelObjectifCart;
    [SerializeField] private PanelPeripecie _panelPeripecie;
    [SerializeField] private PanelBattleMap _panelBattleMap;
    [Space(10)]
    
    [SerializeField] private Button _bpRoundPlus;
    [SerializeField] private Button _bpRoundMoin;
    [SerializeField] private TMP_Text _txtRound;

    [SerializeField] private Button _bpMenu;

    [SerializeField] private Button _bpPeripetie;
    [SerializeField] private TMP_Text _txtPeripetie;
    
    [Header("Joueur1")]
    // Joueur1
    [SerializeField] private TMP_Text _txtJoueur1Nom;
    [SerializeField] private Button _bpJoueur1ScorePlus;
    [SerializeField] private Button _bpJoueur1ScoreMoin;
    [SerializeField] private TMP_Text _txtJoueur1Score;
    [SerializeField] private Button _bpJoueur1ObjectifCarte1;
    [SerializeField] private Button _bpJoueur1ObjectifCarte2;
    [SerializeField] private Button _bpJoueur1ObjectifCarte3;
    [SerializeField] private Button _bpJoueur1AjoutCarte;
    [Header("Joueur2")]
    // Joueur2
    [SerializeField] private TMP_Text _txtJoueur2Nom;
    [SerializeField] private Button _bpJoueur2ScorePlus;
    [SerializeField] private Button _bpJoueur2ScoreMoin;
    [SerializeField] private TMP_Text _txtJoueur2Score;
    [SerializeField] private Button _bpJoueur2ObjectifCarte1;
    [SerializeField] private Button _bpJoueur2ObjectifCarte2;
    [SerializeField] private Button _bpJoueur2ObjectifCarte3;
    [SerializeField] private Button _bpJoueur2AjoutCarte;

    private GameData2Player _gameData2Player;


    private void UIReduisRound() => UIChangeRoundTurn(-1);
    private void UIAugmentRound() => UIChangeRoundTurn(1);

    private void UIReduiJoueur1Score() => UIChangeJoueur1Scrore(-1);
    private void UIAugmentJoueur1Score() => UIChangeJoueur1Scrore(1);
    private void UIReduiJoueur2Score() => UIChangeJoueur2Scrore(-1);
    private void UIAugmentJoueur2Score() => UIChangeJoueur2Scrore(1);
    private void UISelectJoueur1Carte1() => SelectCart(0, 1);
    private void UISelectJoueur1Carte2() => SelectCart(1, 1);
    private void UISelectJoueur1Carte3() => SelectCart(2, 1);
    private void UISelectJoueur2Carte1() => SelectCart(0, 2);
    private void UISelectJoueur2Carte2() => SelectCart(1, 2);
    private void UISelectJoueur2Carte3() => SelectCart(2, 2);

    private void UIMenu() => _panelMenu.gameObject.SetActive(true);
    private void Awake() {
        _bpRoundMoin.onClick.AddListener(UIReduisRound);
        _bpRoundPlus.onClick.AddListener(UIAugmentRound);
        
        _bpJoueur1ScoreMoin.onClick.AddListener(UIReduiJoueur1Score);
        _bpJoueur1ScorePlus.onClick.AddListener(UIAugmentJoueur1Score);
        _bpJoueur2ScoreMoin.onClick.AddListener(UIReduiJoueur2Score);
        _bpJoueur2ScorePlus.onClick.AddListener(UIAugmentJoueur2Score);
        
        _bpJoueur1AjoutCarte.onClick.AddListener(UIAjoutCarteJoueur1);
        _bpJoueur2AjoutCarte.onClick.AddListener(UIAjoutCarteJoueur2);
        
        _bpJoueur1ObjectifCarte1.onClick.AddListener(UISelectJoueur1Carte1);
        _bpJoueur1ObjectifCarte2.onClick.AddListener(UISelectJoueur1Carte2);
        _bpJoueur1ObjectifCarte3.onClick.AddListener(UISelectJoueur1Carte3);
        _bpJoueur2ObjectifCarte1.onClick.AddListener(UISelectJoueur2Carte1);
        _bpJoueur2ObjectifCarte2.onClick.AddListener(UISelectJoueur2Carte2);
        _bpJoueur2ObjectifCarte3.onClick.AddListener(UISelectJoueur2Carte3);
        
        _bpPeripetie.onClick.AddListener(UIPeripecie);
        
        _bpMenu.onClick.AddListener(UIMenu);
        
        _panelObjectifCart.OnClickPercedant+= PanelObjectifCartOnOnClickPercedant;
        _panelObjectifCart.OnClickSuivant+= PanelObjectifCartOnOnClickSuivant;
        _panelObjectifCart.OnClickDefauce += PanelObjectifCartOnOnClickDefausse;
        _panelObjectifCart.OnClickMain+= PanelObjectifCartOnOnClickMain;
        _panelObjectifCart.OnClickDeck+= PanelObjectifCartOnOnClickDeck;
        
        _panelPeripecie.OnTirerNouvelleCarte += PanelPeripecieOnOnTirerNouvelleCarte;
        _panelPeripecie.OnClickDeck += PanelPeripecieOnOnClickDeck;
        _panelPeripecie.OnClickMain += PanelPeripecieOnOnClickMain;
        _panelPeripecie.OnClickDefausse += PanelPeripecieOnOnClickDefausse;
        
        
        gameObject.SetActive(false);
    }

    


    public void StartNewGame(GameData2Player data) {
        gameObject.SetActive(true);
        _gameData2Player = data;

        _txtRound.text = _gameData2Player.PartieRound.ToString();
        
        _txtJoueur1Nom.text = _gameData2Player.Joueur1Nom;
        _txtJoueur1Score.text = _gameData2Player.Joueur1Score.ToString();
        _txtJoueur2Nom.text = _gameData2Player.Joueur2Nom;
        _txtJoueur2Score.text = _gameData2Player.Joueur2Score.ToString();
        
        _panelBattleMap.SetRoyaume(_gameData2Player.SoRoyaume);
        
        ManagePlayer1Carts();
        ManagePlayer2Carts();
        ManagePeripecie();
    }

    private void ManagePlayer1Carts() {
        _bpJoueur1ObjectifCarte1.gameObject.SetActive(_gameData2Player.Joueur1MainCartes.Count >= 1);
        _bpJoueur1ObjectifCarte2.gameObject.SetActive(_gameData2Player.Joueur1MainCartes.Count >= 2);
        _bpJoueur1ObjectifCarte3.gameObject.SetActive(_gameData2Player.Joueur1MainCartes.Count == 3);
        _bpJoueur1AjoutCarte.transform.parent.gameObject.SetActive(_gameData2Player.Joueur1MainCartes.Count != 3&&_gameData2Player.Joueur1DeckCartes.Count > 0);
    }

    private void ManagePlayer2Carts() {
        _bpJoueur2ObjectifCarte1.gameObject.SetActive(_gameData2Player.Joueur2MainCartes.Count >= 1);
        _bpJoueur2ObjectifCarte2.gameObject.SetActive(_gameData2Player.Joueur2MainCartes.Count >= 2);
        _bpJoueur2ObjectifCarte3.gameObject.SetActive(_gameData2Player.Joueur2MainCartes.Count == 3);
        _bpJoueur2AjoutCarte.transform.parent.gameObject.SetActive(_gameData2Player.Joueur2MainCartes.Count != 3&&_gameData2Player.Joueur2DeckCartes.Count > 0);
    }

    private void ManagePeripecie() {
        if (_gameData2Player.PeripecieCartsEnJeu == null) {
            if (_gameData2Player.PeripecieDeckCarts.Count > 0) {
                _txtPeripetie.text = " Tirer Une Nouvelle Peripecie";
                _bpPeripetie.interactable = true;
            }
            else {
                _txtPeripetie.text = "Plus de Peripecie";
                _bpPeripetie.interactable = false;
            }

            return;
        }
        _txtPeripetie.text = _gameData2Player.PeripecieCartsEnJeu.SoCarte.Name;
        _bpPeripetie.interactable = true;
        

    }

    private void UIChangeRoundTurn(int value) {
        _gameData2Player.PartieRound += value;
        _txtRound.text = _gameData2Player.PartieRound.ToString();
    }

    private void UIChangeJoueur1Scrore(int value)
    {
        _gameData2Player.Joueur1Score += value;
        _txtJoueur1Score.text = _gameData2Player.Joueur1Score.ToString();
    }
    private void UIChangeJoueur2Scrore(int value)
    {
        _gameData2Player.Joueur2Score += value;
        _txtJoueur2Score.text = _gameData2Player.Joueur2Score.ToString();
    }

    private void UIAjoutCarteJoueur1() {
        Debug.Log("Ajoutunecart");
        if (_gameData2Player.Joueur1MainCartes.Count >= 3) return;
        if (_gameData2Player.Joueur1DeckCartes.Count == 0) return;
        ObjectifCarte carte =
            _gameData2Player.Joueur1DeckCartes[Random.Range(0, _gameData2Player.Joueur1DeckCartes.Count)];
        _gameData2Player.Joueur1MainCartes.Add(carte);
        _gameData2Player.Joueur1DeckCartes.Remove(carte);
        carte.Stat = ObjectifCarte.CartStat.InHand;
        ManagePlayer1Carts();
    }
    private void UIAjoutCarteJoueur2() {
        if (_gameData2Player.Joueur2MainCartes.Count >= 3) return;
        if (_gameData2Player.Joueur2DeckCartes.Count == 0) return;
        ObjectifCarte carte =
            _gameData2Player.Joueur2DeckCartes[Random.Range(0, _gameData2Player.Joueur2DeckCartes.Count)];
        _gameData2Player.Joueur2MainCartes.Add(carte);
        _gameData2Player.Joueur2DeckCartes.Remove(carte);
        carte.Stat = ObjectifCarte.CartStat.InHand;
        ManagePlayer2Carts();
    }

    

    private void SelectCart(int carteId, int player) {
        ObjectifCarte carte;
        string playerName;
        List<ObjectifCarte> originList;
        if (player == 1) {
            carte = _gameData2Player.Joueur1MainCartes[carteId];
            playerName = _gameData2Player.Joueur1Nom;
            originList = _gameData2Player.Joueur1MainCartes;
        }
        else {
            carte = _gameData2Player.Joueur2MainCartes[carteId];
            playerName = _gameData2Player.Joueur2Nom;
            originList = _gameData2Player.Joueur2MainCartes;
        }

        _panelObjectifCart.SetCarte(carte, playerName, originList);
        _panelObjectifCart.gameObject.SetActive(true);
    }

    private void PanelObjectifCartOnOnClickPercedant(object sender, ObjectifCarte carte) => ScrollCarte(carte,-1);
    private void PanelObjectifCartOnOnClickSuivant(object sender, ObjectifCarte carte)=> ScrollCarte(carte,1);

    private void ScrollCarte(ObjectifCarte carte , int increment)
    {
        List<ObjectifCarte> originList;
        string playerName;
        if (carte.PlayerId == 1)
        {
            playerName = _gameData2Player.Joueur1Nom;
            switch (carte.Stat)
            {
                case ObjectifCarte.CartStat.InDeck:
                    originList = _gameData2Player.Joueur1DeckCartes;
                    break;
                case ObjectifCarte.CartStat.InHand:
                    originList = _gameData2Player.Joueur1MainCartes;
                    break;
                case ObjectifCarte.CartStat.Played:
                    originList = _gameData2Player.Joueur1CimetierCartes;
                    break;
                default: throw new ArgumentOutOfRangeException();
            }
        }
        else
        {
            playerName = _gameData2Player.Joueur2Nom;
            switch (carte.Stat)
            {
                case ObjectifCarte.CartStat.InDeck:
                    originList = _gameData2Player.Joueur2DeckCartes;
                    break;
                case ObjectifCarte.CartStat.InHand:
                    originList = _gameData2Player.Joueur2MainCartes;
                    break;
                case ObjectifCarte.CartStat.Played:
                    originList = _gameData2Player.Joueur2CimetierCartes;
                    break;
                default: throw new ArgumentOutOfRangeException();
            }
        }

        int id = originList.IndexOf(carte);
        
        if (id+increment < 0|| id+increment>=originList.Count) return;
        carte = originList[id +increment];
        _panelObjectifCart.SetCarte(carte,playerName, originList );
    }
    
    private void PanelObjectifCartOnOnClickDefausse(object sender, ObjectifCarte carte) => ChangeCartePlace(carte, ObjectifCarte.CartStat.Played);
    private void PanelObjectifCartOnOnClickDeck(object sender, ObjectifCarte carte) => ChangeCartePlace(carte, ObjectifCarte.CartStat.InDeck);
    private void PanelObjectifCartOnOnClickMain(object sender, ObjectifCarte carte) => ChangeCartePlace(carte, ObjectifCarte.CartStat.InHand);
    

    private void ChangeCartePlace( ObjectifCarte carte, ObjectifCarte.CartStat stat) {
        _panelObjectifCart.gameObject.SetActive(false);
        if (carte.PlayerId == 1) {
            _gameData2Player.Joueur1CimetierCartes.Add(carte);
            switch (carte.Stat) {
                case ObjectifCarte.CartStat.InDeck: _gameData2Player.Joueur1DeckCartes.Remove(carte); break;
                case ObjectifCarte.CartStat.InHand: _gameData2Player.Joueur1MainCartes.Remove(carte);break;
                case ObjectifCarte.CartStat.Played: _gameData2Player.Joueur1CimetierCartes.Remove(carte);break;
                default: throw new ArgumentOutOfRangeException();
            }

            switch (stat) {
                case ObjectifCarte.CartStat.InDeck:_gameData2Player.Joueur1DeckCartes.Add(carte); break;
                case ObjectifCarte.CartStat.InHand:_gameData2Player.Joueur1MainCartes.Add(carte);break;
                case ObjectifCarte.CartStat.Played:_gameData2Player.Joueur1CimetierCartes.Add(carte);break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(stat), stat, null);
            }
            carte.Stat = stat;
            ManagePlayer1Carts();
        }
        else {
            _gameData2Player.Joueur1CimetierCartes.Add(carte);
            switch (carte.Stat) {
                case ObjectifCarte.CartStat.InDeck: _gameData2Player.Joueur2DeckCartes.Remove(carte); break;
                case ObjectifCarte.CartStat.InHand: _gameData2Player.Joueur2MainCartes.Remove(carte);break;
                case ObjectifCarte.CartStat.Played: _gameData2Player.Joueur2CimetierCartes.Remove(carte);break;
                default: throw new ArgumentOutOfRangeException();
            }

            switch (stat) {
                case ObjectifCarte.CartStat.InDeck:_gameData2Player.Joueur2DeckCartes.Add(carte); break;
                case ObjectifCarte.CartStat.InHand:_gameData2Player.Joueur2MainCartes.Add(carte);break;
                case ObjectifCarte.CartStat.Played:_gameData2Player.Joueur2CimetierCartes.Add(carte);break;
                default: throw new ArgumentOutOfRangeException(nameof(stat), stat, null);
            }
            carte.Stat = stat;
            ManagePlayer2Carts();
        }
    }


    private void PanelPeripecieOnOnClickDefausse(object sender, PeripecieCart e) => ChangePeripeciePlace(e, PeripecieCart.CarteStat.Played);
    private void PanelPeripecieOnOnClickMain(object sender, PeripecieCart e)=> ChangePeripeciePlace(e, PeripecieCart.CarteStat.InGame);
    private void PanelPeripecieOnOnClickDeck(object sender, PeripecieCart e)=> ChangePeripeciePlace(e, PeripecieCart.CarteStat.InDeck);
    private void PanelPeripecieOnOnTirerNouvelleCarte(object sender, EventArgs e) {
        if (_gameData2Player.PeripecieCartsEnJeu != null)
        {
            _gameData2Player.PeripecieCimetierCarts.Add(_gameData2Player.PeripecieCartsEnJeu);
            _gameData2Player.PeripecieCartsEnJeu.Stat = PeripecieCart.CarteStat.Played;
            _gameData2Player.PeripecieCartsEnJeu = null;
        }
        UIPeripecie();
    }

    private void UIPeripecie() {
        if (_gameData2Player.PeripecieCartsEnJeu == null) {
            PeripecieCart carte =
                _gameData2Player.PeripecieDeckCarts[Random.Range(0, _gameData2Player.PeripecieDeckCarts.Count)];
            _gameData2Player.PeripecieDeckCarts.Remove(carte);
            _gameData2Player.PeripecieCartsEnJeu = carte;
            carte.Stat = PeripecieCart.CarteStat.InGame;
        }
        ManagePeripecie();
        _panelPeripecie.SetCarte(_gameData2Player.PeripecieCartsEnJeu,_gameData2Player.PeripecieDeckCarts.Count>0);
        _panelPeripecie.gameObject.SetActive(true);
    }

    private void ChangePeripeciePlace(PeripecieCart carte, PeripecieCart.CarteStat stat) {
        _panelPeripecie.gameObject.SetActive(false);
        switch (carte.Stat) {
            case PeripecieCart.CarteStat.InDeck: _gameData2Player.PeripecieDeckCarts.Remove(carte); break;
            case PeripecieCart.CarteStat.InGame:_gameData2Player.PeripecieCartsEnJeu=null; break; 
            case PeripecieCart.CarteStat.Played:_gameData2Player.PeripecieCimetierCarts.Remove(carte); break; 
            default: throw new ArgumentOutOfRangeException();
        }
        switch (stat)
        {
            case PeripecieCart.CarteStat.InDeck: _gameData2Player.PeripecieDeckCarts.Add(carte); break;
            case PeripecieCart.CarteStat.InGame: _gameData2Player.PeripecieCartsEnJeu=carte; break; 
            case PeripecieCart.CarteStat.Played: _gameData2Player.PeripecieCimetierCarts.Add(carte); break; 
            default: throw new ArgumentOutOfRangeException(nameof(stat), stat, null);
        }

        carte.Stat = stat;
        ManagePeripecie();
    }
}