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

    public GameObject projetil;
    public Transform localDisparo;

    private SpriteRenderer spriteRb;

    // Start is called before the first frame update
    void Start()
    {
        rbPlayer = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
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
            GameObject temp = Instantiate(projetil);

            temp.transform.position = localDisparo.position;

            temp.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(8, 0);

            Destroy(temp.gameObject, 2);
        }

        anim.SetInteger("Run", (int)movimentoX);
        anim.SetBool("Jump", sensor);

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
