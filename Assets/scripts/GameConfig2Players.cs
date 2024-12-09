using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameConfig2Players : MonoBehaviour {
    [SerializeField] private MainMenuManager _mainMenuManager;
    [SerializeField] private GameFor2PlayerManager _gameFor2PlayerManager;
    [Space(10)]
    [SerializeField] private TMP_Dropdown _dropdownRoyaume;
    [SerializeField] private TMP_InputField _inputFieldJoueur1;
    [SerializeField] private TMP_InputField _inputFieldJoueur2;
    [SerializeField] private Button _bpStart;
    [SerializeField] private Button _bpRetoure;
    [Space(10)] 
    [SerializeField] private SOObjectifCart[] _soObjectifCarts;
    [SerializeField]private SORoyaume[] _SoRoyaumes;


    private void Awake() {
        _bpStart.onClick.AddListener(UIBPStart);
        _bpRetoure.onClick.AddListener(UIBPRetoure);
        SetUpRoyaumeDropDown();
        gameObject.SetActive(false);
    }

    private void UIBPRetoure() {
        _mainMenuManager.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }

    private void UIBPStart() {
        GameData2Player data = new GameData2Player(
            _SoRoyaumes[_dropdownRoyaume.value],
            _inputFieldJoueur1.text,
            _inputFieldJoueur2.text,
            _soObjectifCarts);
        _gameFor2PlayerManager.StartNewGame(data);
        if(data.Joueur1DeckCartes[0]==null) Debug.Log( "la carte est null");
        gameObject.SetActive(false);
    }

    private void SetUpRoyaumeDropDown() {
        _dropdownRoyaume.options.Clear();
        foreach (var royaume in _SoRoyaumes) {
            _dropdownRoyaume.options.Add(new TMP_Dropdown.OptionData(royaume.Name));
        }
    }
}