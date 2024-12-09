using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PanelPeripecie : MonoBehaviour
{
    public event EventHandler<PeripecieCart> OnClickDeck;
    public event EventHandler<PeripecieCart> OnClickMain;
    public event EventHandler<PeripecieCart> OnClickDefausse;
    public event EventHandler OnTirerNouvelleCarte;
    
    [SerializeField] private TMP_Text _txtPeripecieNom;
    [SerializeField] private TMP_Text _txtPeripecieDescription;
    [SerializeField] private TMP_Text _txtPeripecieRoyaume;
    [Space(5)]
    [SerializeField] private Button _bpDeck;
    [SerializeField] private Button _bpMain;
    [SerializeField] private Button _bpDefausse;
    [SerializeField] private Button _bpTirer;
    [SerializeField] private Button _bpRetoure;

    private PeripecieCart _carte;

    private void Awake()
    {
        _bpRetoure.onClick.AddListener(UIClickRetoure);
        _bpDeck.onClick.AddListener(UIClickDeck);
        _bpMain.onClick.AddListener(UIClickInGame);
        _bpDefausse.onClick.AddListener(UIClickDefauce);
        _bpTirer.onClick.AddListener(UIClickTirer);

        gameObject.SetActive(false);
    }

    public void SetCarte(PeripecieCart carte, bool canDrawMore) {
        _carte = carte;
        _bpTirer.interactable = canDrawMore;

        _txtPeripecieNom.text = _carte.SoCarte.Name;
        _txtPeripecieDescription.text = _carte.SoCarte.Effect;
        _txtPeripecieRoyaume.text = _carte.SoCarte.Royaume.ToString();

        _bpDeck.interactable = _carte.Stat != PeripecieCart.CarteStat.InDeck;
        _bpMain.interactable = _carte.Stat!= PeripecieCart.CarteStat.InGame;
        _bpDefausse.interactable = _carte.Stat != PeripecieCart.CarteStat.Played;
    }

    private void UIClickRetoure() {
        gameObject.SetActive(false);
    }

    private void UIClickDeck() => OnClickDeck.Invoke(this, _carte);
    private void UIClickInGame() => OnClickMain.Invoke(this, _carte);
    private void UIClickDefauce() => OnClickDefausse.Invoke(this, _carte);
    private void UIClickTirer()=> OnTirerNouvelleCarte.Invoke(this , EventArgs.Empty);
}