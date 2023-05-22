using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComandosBasicos : MonoBehaviour
{
    public int velocidade;
    private Rigidbody2D rbPlayer;
    public float forcaPulo;

    public bool sensor;
    public Transform posicaoSensor;
    public LayerMask layerChao;

    private Animator anim;
    private Animator jump;

    private SpriteRenderer spriteRb;

    // Start is called before the first frame update
    void Start()
    {
        rbPlayer = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        jump = GetComponent<Animator>();
        spriteRb = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float movimentoX = Input.GetAxisRaw("Horizontal");

        rbPlayer.velocity = new Vector2(movimentoX * velocidade , rbPlayer.velocity.y);

        if (Input.GetButtonDown("Jump") && sensor == true) 
        {
            rbPlayer.AddForce(new Vector2(0, forcaPulo));
        }

        if (Input.GetButton("Fire1"))
        {
            anim.SetTrigger("kick");
        }

        anim.SetInteger("Run", (int)movimentoX);
        jump.SetBool("Jump", sensor);

        if(movimentoX > 0)
        {
            spriteRb.flipX = false;
        }else if (movimentoX < 0)
        {
            spriteRb.flipX = true;
        }

    }

    private void FixedUpdate()
    {
        sensor = Physics2D.OverlapCircle(posicaoSensor.position, 0.1f, layerChao);
    }

}
