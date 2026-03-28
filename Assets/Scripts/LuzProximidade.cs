using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LuzDescoberta : MonoBehaviour
{
    public Transform player;
    public float distanciaAtivacao = 5f;
    public float velocidadeTransicao = 2f;
    public float intensidadeAcesa = 1.5f;

    private Light2D luz;
    private bool acesa = false;

    void Start()
    {
        luz = GetComponent<Light2D>();
        luz.intensity = 0f;

        if (player == null)
            player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        // Só verifica distância se ainda não foi acesa
        if (!acesa)
        {
            float distancia = Vector2.Distance(transform.position, player.position);

            if (distancia <= distanciaAtivacao)
                acesa = true;
        }

        // Uma vez acesa, vai aumentando até o máximo
        if (acesa)
        {
            luz.intensity = Mathf.Lerp(
                luz.intensity,
                intensidadeAcesa,
                velocidadeTransicao * Time.deltaTime
            );
        }
    }
}
