using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   
    private float yRange = 14f; // Limite de pantalla en el eje y
    [SerializeField] public float jumpForce = 8f; // El impulso a la hora de saltar
    private Rigidbody playerRigidbody;

    // Para el Game Over
    public bool gameOver;
    

    // Para el contador
    private int totalmoneda = 0;

    // Para los sonidos
    public AudioClip jumpClip; // Impulso hacia arriba
    public AudioClip crashClip; // Colisiona contra un obstáculo
    public AudioClip moneyClip; // Colisiona contra un recolectable
    private AudioSource playerAudioSource;
   

    // Para los sistemas de particulas
    public ParticleSystem explosionParticleSystem; // Colisiona contra un obstáculo
    public ParticleSystem moneyParticleSystem; // Colisiona contra un recolectable


    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();

        playerAudioSource = GetComponent<AudioSource>();


    }

    // Update is called once per frame
    void Update()
    {
        // Saltamos cunado pulsamos el espacio
        if (Input.GetKeyDown(KeyCode.Space) && !gameOver)
        {
            playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            //SFX de salto
            playerAudioSource.PlayOneShot(jumpClip, 10);
        }
        //Limite de pantalla en el eje y
        if (transform.position.y > yRange)
        {
            transform.position = new Vector3(transform.position.x, yRange,
                transform.position.z);
        }

       
      


    }
    // Si el Player colisiona contra el suelo, entonces Game over
    private void OnCollisionEnter(Collision otherCollider)
    {
       
        
        //Si colisionamos con el suelo, entonces Game Over
         if (otherCollider.gameObject.CompareTag("Ground"))
         {
            Debug.Log("GAME OVER");
            Time.timeScale = 0f;
         }
        

    }
    
    private void OnTriggerEnter(Collider otherCollision)
    {
        if (!gameOver)
        {
            // Si el Player colisiona contra la bomba, entonces game over
            if (otherCollision.gameObject.CompareTag("Bomb"))
            {
                // Ejecutamos el sistema de partículas de explosión

                gameOver = true;
            
                Instantiate(explosionParticleSystem,
                    transform.position,
                    explosionParticleSystem.transform.rotation);

                explosionParticleSystem.Play();


                Destroy(otherCollision.gameObject);
                Debug.Log("GAME OVER");
     
                //Reproducir el SFX de la explosion
                playerAudioSource.PlayOneShot(crashClip, 10);

              
            }
        }
        // Si el Player colisiona contra la moneda, entonces se le suma mas 1 al contador
        if (otherCollision.gameObject.CompareTag("Money"))
        {
           
            Destroy(otherCollision.gameObject);
            totalmoneda++;
            Debug.Log(totalmoneda);

            moneyParticleSystem.Play();

            //Reproducir el SFX del recolectable
            playerAudioSource.PlayOneShot(moneyClip, 10);
        }

    }

}
