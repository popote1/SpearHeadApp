using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PanelBattleMap : MonoBehaviour
{
    [SerializeField] private Image _imgTerrain;
    [SerializeField] private Image _imgDeploiment;
    [SerializeField] private TMP_Dropdown _dropdownDeploiment;
    [SerializeField] private TMP_Text _txtTerrain;
    [SerializeField] private Button _bpRetour;
    [Space(5)] 
    [SerializeField] private Sprite[] _deploimentSprites;

    [SerializeField] private SORoyaume _soRoyaume;

    private void Awake() {
        _dropdownDeploiment.onValueChanged.AddListener(UIChangeDeploiment);
        _bpRetour.onClick.AddListener(UIRetour);
        gameObject.SetActive(false);
    }

    private void UIChangeDeploiment(int value) {
        _imgDeploiment.sprite = _deploimentSprites[value];
    }

    public void SetRoyaume(SORoyaume royaume)
    {
        _soRoyaume = royaume;
        _imgTerrain.sprite = _soRoyaume.ImgTerrain;
        _txtTerrain.text = "TERRAIN \n " + _soRoyaume.Name; 
        UIChangeDeploiment(0);
    }

    private void UIRetour() {
        gameObject.SetActive(false);
    }
}
