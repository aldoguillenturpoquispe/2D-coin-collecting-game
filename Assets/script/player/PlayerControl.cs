using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public PlayerSoundController playerSoundController;
    public float velocidad = 5;
    private Rigidbody2D rb2D;
    
    private float movimiento;
    public float FuerzaSalto = 4;
    private bool enSuelo;
    public Transform controlSuelo;
    public float radioSalto = 0.1f;
    public LayerMask capaSuelo;

    public Animator animacion;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animacion = GetComponent<Animator>();

        if (playerSoundController == null)
            playerSoundController = GetComponent<PlayerSoundController>();
    }

    void Update()
    {
        movimiento = Input.GetAxisRaw("Horizontal");
        rb2D.linearVelocity = new Vector2(movimiento * velocidad, rb2D.linearVelocity.y);

        if (Input.GetButtonDown("Jump") && enSuelo)
        {
            rb2D.linearVelocity = new Vector2(rb2D.linearVelocity.x, FuerzaSalto);
            if (playerSoundController != null)
                playerSoundController.playSalto();
        }
        if (movimiento != 0)
            transform.localScale = new Vector3(Mathf.Sign(movimiento),1,1);

        animacion.SetFloat("Velocidad", Mathf.Abs(movimiento));
        animacion.SetFloat("VelocidadV", rb2D.linearVelocity.y);
        animacion.SetBool("EnSuelo", enSuelo);
    }

    private void FixedUpdate()
    {
        enSuelo = Physics2D.OverlapCircle(controlSuelo.position, radioSalto, capaSuelo);
    }
}