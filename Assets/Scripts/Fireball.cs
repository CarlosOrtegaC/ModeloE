using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private Vector2 direction; // la configuras en el Inspector

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Restamos vida al jugador
            other.GetComponent<Player>().RecibirDanio(20);
            Destroy(gameObject); // la bola desaparece
        }
    }
}
