using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftX : MonoBehaviour
{
    public float speed = 15f;
    public float leftBound;

    private PlayerControllerX playerControllerScript;

    private void Start()
    {
        playerControllerScript = FindObjectOfType<PlayerControllerX>();
    }


    // hará que el obstaculo se mueva hacia la izquierda
    private void Update()
    {
        if (!playerControllerScript.gameOver)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if (transform.position.x < leftBound && !gameObject.CompareTag("Background"))
        {
            Destroy(gameObject);
        }
    }
}
