using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody PlayerRb;
    public float jumpStrenght = 10f;
    public float gravityModifier = 1;
    private bool onGroundCheck = true;
    public bool isGameOver = false;
    private Animator playerAnime;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    private AudioSource playerAudio;
    public AudioClip explosionSound;
    public AudioClip jumpSound;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        playerAnime = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && onGroundCheck && isGameOver == false )
        {
            PlayerRb.AddForce(Vector3.up * jumpStrenght, ForceMode.Impulse);
            onGroundCheck = false;
            playerAnime.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            onGroundCheck = true;
            dirtParticle.Play();
        } else if (collision.collider.CompareTag("Barrier"))
        {
            isGameOver = true;
            playerAnime.SetBool("Death_b", true);
            playerAnime.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(explosionSound);
        }
    }
}
