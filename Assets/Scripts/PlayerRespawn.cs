using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRespawn : MonoBehaviour
{
    public Transform respawnPoint;
    public int lives = 3;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Si el jugador cae por debajo de cierto punto, se considera "muerto"
        if (transform.position.y < -10f)
        {
            lives--;
            Debug.Log("Vidas restantes: " + lives);

            if (lives > 0)
            {
                // Volver al punto de respawn
                transform.position = respawnPoint.position;
                rb.velocity = Vector3.zero;
            }
            else
            {
                // Reiniciar la escena
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}