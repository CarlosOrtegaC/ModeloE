using UnityEngine;

public class Disco : MonoBehaviour
{
    public Transform puntoB;         // Arrastras un GameObject vacío como destino
    public float velocidad = 3f;     // Qué tan rápido se mueve
    public float pausa = 2f;         // Cuánto espera al llegar

    Vector2 puntoA;                  // Donde empieza el disco (se guarda al iniciar)
    Vector2 destino;                 // A dónde se mueve
    float tiempoDeEspera = 0f;       // Contador de pausa

    void Start()
    {
        puntoA = transform.position;           // Punto A es donde empieza
        destino = puntoB.position;             // Va hacia B primero
    }

    void Update()
    {
        // Si está esperando, no se mueve
        if (tiempoDeEspera > 0f)
        {
            tiempoDeEspera -= Time.deltaTime;
            return;
        }

        // Mover hacia el destino
        transform.position = Vector2.MoveTowards(transform.position, destino, velocidad * Time.deltaTime);

        // Si ha llegado, activar pausa y cambiar destino
        if (Vector2.Distance(transform.position, destino) < 0.01f)
        {
            // 1. Empieza la pausa
            tiempoDeEspera = pausa;

            // 2. Cambia de dirección
            if (destino == puntoA)
            {
                destino = puntoB.position;
            }
            else
            {
                destino = puntoA;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().RecibirDanio(20);
            Debug.Log("El jugador fue golpeado por un disco!");
        }
    }
}