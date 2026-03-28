using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Coletavel : MonoBehaviour
{
    [Header("Luz")]
    public float intensidadeMin = 0.5f;
    public float intensidadeMax = 2f;
    public float velocidadePulso = 3f;

    [Header("Rotação")]
    public float velocidadeRotacao = 90f;

    private Light2D luz;

    void Start()
    {
        luz = GetComponentInChildren<Light2D>();
    }

    void Update()
    {
        // Pulso da luz
        luz.intensity = Mathf.Lerp(
            intensidadeMin,
            intensidadeMax,
            Mathf.PingPong(Time.time * velocidadePulso, 1)
        );

        // Rotação do sprite (opcional, fica bonito)
        transform.Rotate(0, 0, velocidadeRotacao * Time.deltaTime);
    }

    // Detecta quando o player coleta
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            Debug.Log("Coletado!");
        }
    }
}