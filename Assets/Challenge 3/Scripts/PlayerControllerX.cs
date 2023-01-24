using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour

    {
    public float jumpForce = 20f;
    public bool gameOver;
    public float gravityMultiplier = 1.5f;
    public ParticleSystem explosionParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    public AudioClip[] jumpSounds;
    public AudioClip[] crashSounds;

    private Rigidbody _rigidbody;
    private bool isOnTheGround = true;
    private AudioSource _audioSource;

    
    

    private void Start()
    {
        // hace una fuerza que impulsa el gameobject hacia arriba

        // el getcomponent lo que hace es coger los datos de la componente que se le ascie
        _rigidbody = GetComponent<Rigidbody>();
        Physics.gravity *= gravityMultiplier;
        
    }

    private void Update()
    {
        /* hará que el impulso se haga efectivo cuando pulsemos la tecla espacio y solo funcionará si el personaje
        está en el suelo */
        if (Input.GetKeyDown(KeyCode.Space) && !gameOver)
        {
            Jump();
        }
    }

    // si el player esta en el suelo, podrá saltar, si no lo está, no podrá saltar.
    private void OnCollisionEnter(Collision otherCollider)
{
    if (otherCollider.gameObject.CompareTag("Bomb"))
    {
        Destroy(otherCollider.gameObject);
        GameOver();
    }
    else if (otherCollider.gameObject.CompareTag("Ground"))
    {
        isOnTheGround = true;
    }
}

private void Jump()
{
    _rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    // Llamamos al trigger para que se dé la transición de la animación de correr a salto
}

private void ChoseRandomSFX(AudioClip[] sounds)
{
    int randomIdx = Random.Range(0, sounds.Length);
    _audioSource.PlayOneShot(sounds[randomIdx], 1);
}

private void GameOver()
{
    gameOver = true;
    explosionParticle.Play();
}


}
