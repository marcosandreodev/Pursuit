using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColetavelP : MonoBehaviour
{

    public int pontos = 10;
    public AudioClip somColetavel;

    private Vector2 posicaoInicial;


    // Start is called before the first frame update
    void Start()
    {
        posicaoInicial = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Pontuacao.AddPontos(pontos);
            AudioSource.PlayClipAtPoint(somColetavel, transform.position);
            transform.position = posicaoInicial;
        }
    }
}
