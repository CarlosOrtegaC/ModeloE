using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Player player;
    private bool isPlayerNearby = false;
    private bool isOpened = false;

    void Update()
    {
        if (isPlayerNearby && !isOpened && Input.GetKeyDown(KeyCode.E))
        {
            isOpened = true;
            animator.SetTrigger("Open");
            player.hasKey = true; // 🚀 el Player recibe la llave
            Debug.Log("Has conseguido una llave");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
            player = other.GetComponent<Player>(); // guardamos referencia
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
        }
    }

}
