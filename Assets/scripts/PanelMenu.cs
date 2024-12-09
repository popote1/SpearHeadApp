using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelMenu : MonoBehaviour
{
    [SerializeField] private MainMenuManager _mainMenuManager;
    [SerializeField] private PanelBattleMap _panelBattleMap;
    [SerializeField] private GameFor2PlayerManager _gameFor2PlayerManager;
    [Space(10)]
    [SerializeField] private Button _bpRetour;
    [SerializeField] private Button _bpDeploiment;
    [SerializeField] private Button _bpOptions;
    [SerializeField] private Button _bpMenuPrincipal;
    
    void Awake() {
        _bpDeploiment.onClick.AddListener(UIDeploiment);
        _bpRetour.onClick.AddListener(UIRetour);
        _bpMenuPrincipal.onClick.AddListener(UIMenuPrincipal);
        _bpOptions.interactable = false;
        gameObject.SetActive(false);
    }

    private void UIRetour() {
        gameObject.SetActive(false);
    }

    private void UIDeploiment() {
        _panelBattleMap.gameObject.SetActive(true);
    }

    private void UIMenuPrincipal() {
        _gameFor2PlayerManager.gameObject.SetActive(false);
        _mainMenuManager.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
    
}
