using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{   
    private Player misDatos; 

    // Codigo ejecutado cuando el objeto se activa en el nivel
    private void OnEnable()
    {
        misDatos = GetComponent<Player>();
        misDatos.PlayerPerfil.MiRigidbody2D = GetComponent<Rigidbody2D>();
        misDatos.PlayerPerfil.MiAnimator = GetComponent<Animator>();
        misDatos.PlayerPerfil.MiSprite = GetComponent<SpriteRenderer>();
        misDatos.PlayerPerfil.MiCollider2D = GetComponent<BoxCollider2D>();
        misDatos.PlayerPerfil.SaltarMask = LayerMask.GetMask("Pisos", "Plataformas", "Enemigos");
    }

    // Codigo ejecutado en cada frame del juego (Intervalo variable)
    private void Update()
    {
        misDatos.PlayerPerfil.MoverHorizontal = Input.GetAxis("Horizontal");
        misDatos.PlayerPerfil.Direccion = new Vector2(misDatos.PlayerPerfil.MoverHorizontal, 0f);
       
        int velocidadX = (int)misDatos.PlayerPerfil.MiRigidbody2D.velocity.x;
        //misDatos.PlayerPerfil.MiSprite.flipX = velocidadX < 0;
        if(Input.GetKeyDown(KeyCode.A)) misDatos.PlayerPerfil.MiSprite.flipX = true;
        if(Input.GetKeyDown(KeyCode.D)) misDatos.PlayerPerfil.MiSprite.flipX = false;
        misDatos.PlayerPerfil.MiAnimator.SetInteger("Velocidad", velocidadX);

        misDatos.PlayerPerfil.MiAnimator.SetBool("EnAire", !EnContactoConPlataforma());
        
    }

    private void FixedUpdate()
    {
        misDatos.PlayerPerfil.MiRigidbody2D.AddForce(misDatos.PlayerPerfil.Direccion * misDatos.PlayerPerfil.Velocidad);
    }

    private bool EnContactoConPlataforma()
    {
        return misDatos.PlayerPerfil.MiCollider2D.IsTouchingLayers(misDatos.PlayerPerfil.SaltarMask);
    }

}




