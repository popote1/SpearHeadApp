using System;
using System.Collections;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private GameConfig2Players _gameConfig2Players;
    [Space(10)]
    [SerializeField] private Button _bp1Joueur;
    [SerializeField] private Button _bp2Joueur;
    [SerializeField] private Button _bpObtion;
    [SerializeField] private Button _bpQuitter;
    [SerializeField] private Button _bpItch
        ;

    private void Awake()
    {
        _bp1Joueur.interactable = false;
        _bpObtion.interactable = false;
        _bp2Joueur.onClick.AddListener(On2PlayerClick);
        _bpQuitter.onClick.AddListener(OnQuitter);
        _bpItch.onClick.AddListener(UICkickItch);
        
    }

    private void OnQuitter()=> Application.Quit();

    private void On2PlayerClick() {
        _gameConfig2Players.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }

    private void UICkickItch() {
        Application.OpenURL("https://popote.itch.io/spearhead-app");
    }

}