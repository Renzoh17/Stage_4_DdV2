using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraDeVida : MonoBehaviour
{
    private Slider slider;

    private Animator animator;

    private void Start(){
        slider = GetComponent<Slider>();
        animator = GetComponent<Animator>();
    }

    public void CambiarVidaMaxima(int vidaMaxima){
        slider.maxValue = vidaMaxima;
    }

    public void CambiarVidaActual(int cantidadVida){
        slider.value = cantidadVida;
        animator.SetTrigger("Golpe");
    }

    public void InicializarBarraDeVida(int cantidadVida){
        CambiarVidaMaxima(cantidadVida);
        CambiarVidaActual(cantidadVida);
    }
}
