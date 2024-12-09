using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PanelObjectifCart : MonoBehaviour
{

    public event EventHandler<ObjectifCarte> OnClickSuivant;
    public event EventHandler<ObjectifCarte> OnClickPercedant;
    public event EventHandler<ObjectifCarte> OnClickDeck;
    public event EventHandler<ObjectifCarte> OnClickMain;
    public event EventHandler<ObjectifCarte> OnClickDefauce;
   
    
    
    [SerializeField] private Button _bpPrecedente;
    [SerializeField] private Button _bpSuivante;
    [SerializeField] private Button _bpDeck;
    [SerializeField] private Button _bpMain;
    [SerializeField] private Button _bpDefause;
    [SerializeField] private Button _bpRetour;

    [SerializeField] private TMP_Text _txtLocalisation;
    [SerializeField] private TMP_Text _txtObjectifNom;
    [SerializeField] private TMP_Text _txtObjectifDescription;
    [SerializeField] private TMP_Text _txtOrdrePhase;
    [SerializeField] private TMP_Text _txtOrdreNom;
    [SerializeField] private TMP_Text _txtOrdreDescription;
    [SerializeField] private TMP_Text _txtOrdreMotClef;

    private ObjectifCarte _carteSelectionne;

    private void Awake() {
        _bpPrecedente.onClick.AddListener(UIClickPrecedant);
        _bpSuivante.onClick.AddListener(UIClickSuivant);
        _bpDeck.onClick.AddListener(UIClickDeck);
        _bpMain.onClick.AddListener(UIClickMain);
        _bpDefause.onClick.AddListener(UIClickDefauce);
        _bpRetour.onClick.AddListener(UIClickRetoure);
        gameObject.SetActive(false);
    }
    
    

    public void SetCarte(ObjectifCarte carte, string nomJoueur, List<ObjectifCarte> originList) {
        _carteSelectionne = carte;

        _txtLocalisation.text = nomJoueur + "\n" + _carteSelectionne.Stat.ToString();

        _txtObjectifNom.text = _carteSelectionne.SOCarte.ObjectifName;
        _txtObjectifDescription.text = _carteSelectionne.SOCarte.ObjectifDescription;
        _txtOrdrePhase.text = _carteSelectionne.SOCarte.GetPhase();
        _txtOrdreNom.text = _carteSelectionne.SOCarte.OrderName;
        _txtOrdreDescription.text = _carteSelectionne.SOCarte.OrderDescription;
        _txtOrdreMotClef.text = _carteSelectionne.SOCarte.OrdreMotClef;

        
        
        int id = originList.IndexOf(_carteSelectionne);
        _bpDeck.interactable = _carteSelectionne.Stat != ObjectifCarte.CartStat.InDeck;
        _bpMain.interactable = _carteSelectionne.Stat != ObjectifCarte.CartStat.InHand;
        _bpDefause.interactable = _carteSelectionne.Stat != ObjectifCarte.CartStat.Played;
        _bpPrecedente.interactable = id > 0;
        _bpSuivante.interactable = id < originList.Count-1 ;

        Debug.Log("Id trouver est "+ id+" \n l'origine liste est long de "+ originList.Count);
    }

    private void UIClickPrecedant()=> OnClickPercedant.Invoke(this , _carteSelectionne);
    private void UIClickSuivant()=> OnClickSuivant.Invoke(this , _carteSelectionne);
    private void UIClickDeck()=> OnClickDeck.Invoke(this , _carteSelectionne);
    private void UIClickMain()=> OnClickMain.Invoke(this , _carteSelectionne);
    private void UIClickDefauce()=> OnClickDefauce.Invoke(this , _carteSelectionne);
    private void UIClickRetoure() => gameObject.SetActive(false);





}