using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ComandosBasicos : MonoBehaviour
{
    public int velocidade;
    private Rigidbody2D rbPlayer;
    public float forcaPulo;
    public bool verificarDirecao;
    public float velocidadeTiro;

    public bool sensor;
    public Transform posicaoSensor;
    public LayerMask layerChao;

    private Animator anim;

    public GameObject projetil;
    public Transform localDisparo;

    private SpriteRenderer spriteRb;

    public TextMeshProUGUI textocoin;
    private int quantidadeMoedas;
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
            anim.SetTrigger("Tiro");
        }

        if (Input.GetButton("Fire1"))
        {
            GameObject temp = Instantiate(projetil);

            temp.transform.position = localDisparo.position;

            temp.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(velocidadeTiro, 0);

            Destroy(temp.gameObject, 2);
        }

        
        anim.SetInteger("Run", (int)movimentoX);
        anim.SetBool("Jump", sensor);

        if(movimentoX > 0 && verificarDirecao == true)
        {
            Flip();
        }
        else if (movimentoX < 0 && verificarDirecao == false)
        {
            Flip();
        }

    }

    private void FixedUpdate()
    {
        sensor = Physics2D.OverlapCircle(posicaoSensor.position, 0.1f, layerChao);
    }

    public void Flip()
    {
        verificarDirecao = !verificarDirecao;

        float x = transform.localScale.x * -1;

        transform.localScale = new Vector3(x, transform.localScale.y, transform.localScale.z);

        velocidadeTiro *= -1;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "coin")
        {
            quantidadeMoedas += 1;


            textocoin.text = quantidadeMoedas.ToString();
            Destroy(collision.gameObject);
        }
    }
}
