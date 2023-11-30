using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField]
    private PlayerData playerPerfil;
    public PlayerData PlayerPerfil {get => playerPerfil;}

    [SerializeField] private BarraDeVida barraDeVida;

    private void Start(){
        barraDeVida.InicializarBarraDeVida(playerPerfil.Vida);
    }

    public void ModificarVida(int danio)
    {
        playerPerfil.Vida -= danio;
        barraDeVida.CambiarVidaActual(playerPerfil.Vida);
        if(playerPerfil.Vida <=0) Destroy(gameObject);
    }

    private bool EstasVivo()
    {
        if(playerPerfil.Vida == 0) {Debug.Log("¡PERDISTE! HAS MUERTO");}
        return playerPerfil.Vida > 0;
    }

    
}
