using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Vida")] 
    [SerializeField] private int vida;
    [SerializeField] private BarraDeVida barraDeVida;

    private Animator animator;
    public Rigidbody2D rb2D;
    public Transform jugador;
    private bool mirandoDerecha = true;

    [Header("Ataque")]
    [SerializeField] private Transform controladorAtaque;
    [SerializeField] private float radioAtaque;
    [SerializeField] private int danioAtaque;

    private void Start(){
        animator = GetComponent<Animator>();
        barraDeVida.InicializarBarraDeVida(vida);
        rb2D = GetComponent<Rigidbody2D>();
        jugador = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();        
    }

    private void Update(){
        float distanciaJugador = Vector2.Distance(transform.position, jugador.position);
        animator.SetFloat("distanciaJugador", distanciaJugador);
    }

    public void TomarDanio(int danio){
        vida-=danio;
        barraDeVida.CambiarVidaActual(vida);
        if(vida <= 0) Muerte();
    }

    private void Muerte(){
        animator.SetTrigger("Muerte");
        Destroy(gameObject);
        Debug.Log("GANASTE");
    }

    public void MirarJugador(){
        if((jugador.position.x > transform.position.x && !mirandoDerecha) || (jugador.position.x < transform.position.x && mirandoDerecha)){
            mirandoDerecha = !mirandoDerecha;
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        }
    }

    public void Ataque(){
        Collider2D[] objetos = Physics2D.OverlapCircleAll(controladorAtaque.position, radioAtaque);

        foreach(Collider2D colision in objetos){
            if(colision.CompareTag("Player")){
                colision.GetComponent<Player>().ModificarVida(danioAtaque);
            }
        }
    }

    private void OnDrawGizmos(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(controladorAtaque.position, radioAtaque);
    }
}
