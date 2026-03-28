using UnityEngine;
using UnityEngine.InputSystem;

public class MovimentoJogador : MonoBehaviour
{
    public float velocidade = 4f;
    private Camera cam;
    private Rigidbody2D rb;

    void Start()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Rotação apontando para o mouse
        Vector3 posicaoMouse = cam.ScreenToWorldPoint(
            new Vector3(
                Mouse.current.position.x.ReadValue(),
                Mouse.current.position.y.ReadValue(),
                0
            )
        );

        Vector2 direcao = posicaoMouse - transform.position;
        float angulo = Mathf.Atan2(direcao.y, direcao.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angulo - 90f);
    }

    void FixedUpdate()
    {
        Vector2 input = Vector2.zero;

        if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed)
            input.y = 1;
        if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed)
            input.y = -1;
        if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
            input.x = 1;
        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
            input.x = -1;

        // MovePosition respeita colisões de forma mais confiável
        Vector2 novaPosicao = rb.position + input.normalized * velocidade * Time.fixedDeltaTime;
        rb.MovePosition(novaPosicao);
    }
}