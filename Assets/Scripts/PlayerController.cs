using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 10;
    public float gravityModifier = 1;
    public bool isOnGround = true;
    public bool gameOver = false;

    private Rigidbody playerRb;
    private Animator playerAnim;

    // Start is called before the first frame update
    void Start()
    {
        // This can also be achieved by making playerRb public
        // and dragging the rigidbody component into the corresponding
        // field in the Unity editor. Then the line below
        // can be removed.
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();

        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        // Make player jump up
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            Debug.Log("On ground");
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            gameOver = true;
            Debug.Log("Game over!");
        }
    }
}
