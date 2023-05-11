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

    // Start is called before the first frame update
    void Start()
    {
        rbPlayer = GetComponent<Rigidbody2D>(); 
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
    }

    private void FixedUpdate()
    {
        sensor = Physics2D.OverlapCircle(posicaoSensor.position, 0.1f, layerChao);
    }

}
