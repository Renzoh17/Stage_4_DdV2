using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/PlayerData", order = 1)]
public class PlayerData : ScriptableObject
{
    //PLAYER
    [Header("Configuracion")]
    [SerializeField] private int vida = 100;
    public int Vida {get => vida; set => vida = value;}

    //PLAYER MOVE
     // Variables a configurar desde el editor
    [SerializeField] private float velocidad = 5f;
    public float Velocidad {get => velocidad; set => velocidad = value;}

    // Variables de uso interno en el script
    private float moverHorizontal;
    public float MoverHorizontal {get => moverHorizontal; set => moverHorizontal = value;}
    private Vector2 direccion;
    public Vector2 Direccion {get => direccion; set => direccion = value;}

    // Variable para referenciar otro componente del objeto
    private Rigidbody2D miRigidbody2D;
    public Rigidbody2D MiRigidbody2D {get => miRigidbody2D; set => miRigidbody2D = value;}
    private Animator miAnimator;
    public Animator MiAnimator {get => miAnimator; set => miAnimator = value;}
    private SpriteRenderer miSprite;
    public SpriteRenderer MiSprite {get => miSprite; set => miSprite = value;}
    private BoxCollider2D miCollider2D;
    public BoxCollider2D MiCollider2D {get => miCollider2D; set => miCollider2D = value;}

    private int saltarMask;
    public int SaltarMask {get => saltarMask; set => saltarMask = value;}

    //PLAYER JUMP
    // Variables a configurar desde el editor
    
    [SerializeField] private float fuerzaSalto = 5f;
    public float FuerzaSalto {get => fuerzaSalto; set => fuerzaSalto = value;}    

    // Variables de uso interno en el script
    private bool puedoSaltar = true;
    public bool PuedoSaltar {get => puedoSaltar; set => puedoSaltar = value;}
    private bool saltando = false;
    public bool Saltando {get => saltando; set => saltando = value;}

    // Variable para referenciar otro componente del objeto
    /*private Rigidbody2D miRigidbody2D;
    public Rigidbody2D MiRigidbody2D {get => miRigidbody2D; set => miRigidbody2D = value;}*/
    // private AudioSource miAudioSource;
    // public AudioSource MiAudioSource {get => miAudioSource; set => miAudioSource = value;}

    //PLAYER ATTACK
    private bool puedoAtacar = true;
    public bool PuedoAtacar {get => puedoAtacar; set => puedoAtacar = value;}

    [SerializeField] [Range(0.5f, 5f)] private float tiempoCoolDownAtk = 1f;
    public float TiempoCoolDownAtk {get => tiempoCoolDownAtk; set => tiempoCoolDownAtk = value;}


    

   


}
