using Unity.VisualScripting;
using UnityEngine;

public class Destruir : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (CompareTag("Destructor"))
        {
            Destroy(this.gameObject);
        }
        
    }
}
