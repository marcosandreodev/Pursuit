using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColetavelP : MonoBehaviour
{

    public int pontos = 0;
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
        Destroy(gameObject);

        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
            Pontuacao.AddPontos(pontos);
            AudioSource.PlayClipAtPoint(somColetavel, transform.position);
            transform.position = posicaoInicial;
        }
    }
}
