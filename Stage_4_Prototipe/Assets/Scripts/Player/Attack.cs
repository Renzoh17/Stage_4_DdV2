using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private Player misDatos;

    [SerializeField] private Transform controladorGolpe;
    [SerializeField] private float radioGolpe;
    [SerializeField] private int danioGolpe;
    [SerializeField] private float tiempoEntreAtaques;
    [SerializeField] private float tiempoSiguienteAtaque;


    private void Start(){
        misDatos = GetComponent<Player>();
        misDatos.PlayerPerfil.MiAnimator = GetComponent<Animator>();

    }

    private void Update(){

        if(tiempoSiguienteAtaque > 0){
            tiempoSiguienteAtaque -= Time.deltaTime;
        }

        if(Input.GetKeyDown(KeyCode.Space) && tiempoSiguienteAtaque <= 0){
            Golpe();
            tiempoSiguienteAtaque = tiempoEntreAtaques;
        }
    }

    private void Golpe(){

        misDatos.PlayerPerfil.MiAnimator.SetTrigger("Golpe");

        Collider2D[] objetos = Physics2D.OverlapCircleAll(controladorGolpe.position, radioGolpe);

        foreach(Collider2D colisionador in objetos){
            if(colisionador.CompareTag("Enemigo")){
                colisionador.transform.GetComponent<Enemy>().TomarDanio(danioGolpe);
            }
        }
    }

    private void OnDrawGizmos(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(controladorGolpe.position, radioGolpe);
    }
}
