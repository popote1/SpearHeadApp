using System.Collections.Generic;
using System.Globalization;

public class GameData2Player
{
    public SORoyaume SoRoyaume;
    public int PartieRound;
    public List<PeripecieCart> PeripecieDeckCarts;
    public PeripecieCart PeripecieCartsEnJeu;
    public List<PeripecieCart>PeripecieCimetierCarts;
    
    public string Joueur1Nom;
    public string Joueur2Nom;
    public int Joueur1Score;
    public int Joueur2Score;
    public List<ObjectifCarte> Joueur1DeckCartes;
    public List<ObjectifCarte> Joueur1MainCartes;
    public List<ObjectifCarte> Joueur1CimetierCartes;
    public List<ObjectifCarte> Joueur2DeckCartes;
    public List<ObjectifCarte> Joueur2MainCartes;
    public List<ObjectifCarte> Joueur2CimetierCartes;

    public GameData2Player(SORoyaume royaume , string joueur1Nom , string joueur2Nom , SOObjectifCart[] objectifCarts)
    {

        SoRoyaume = royaume;
        PartieRound = 1;
        PeripecieDeckCarts = new List<PeripecieCart>();
        foreach (var soPeripecie in royaume.SoPeripecieCarts) {
            PeripecieDeckCarts.Add(new PeripecieCart(soPeripecie));
            PeripecieCimetierCarts = new List<PeripecieCart>();
        }

        Joueur1Nom = joueur1Nom;
        Joueur1Score = 0;
        Joueur2Nom = joueur2Nom;
        Joueur2Score = 0;

        Joueur1DeckCartes = new List<ObjectifCarte>();
        Joueur1MainCartes = new List<ObjectifCarte>();
        Joueur1CimetierCartes = new List<ObjectifCarte>();
        foreach (var soObjectif in objectifCarts){ Joueur1DeckCartes.Add(new ObjectifCarte(soObjectif,1));}
        
        Joueur2DeckCartes = new List<ObjectifCarte>();
        Joueur2MainCartes = new List<ObjectifCarte>();
        Joueur2CimetierCartes = new List<ObjectifCarte>();
        foreach (var soObjectif in objectifCarts){ Joueur2DeckCartes.Add(new ObjectifCarte(soObjectif,2));}
    }
}

