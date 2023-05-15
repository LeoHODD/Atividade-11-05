using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimentação : MonoBehaviour
{
    private Rigidbody2D rbPlayer;
    public float velocidade;
    public float forcaPulo;
    private float inputMovimentoHorizontal;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rbPlayer = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        inputMovimentoHorizontal = Input.GetAxisRaw("Horizontal");

        rbPlayer.velocity = new Vector2(inputMovimentoHorizontal* velocidade, rbPlayer.velocity.y);

        anim.SetInteger("walk",(int) inputMovimentoHorizontal);
    }
}
