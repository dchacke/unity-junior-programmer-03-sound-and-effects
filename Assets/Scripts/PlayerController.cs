using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 10;
    public float gravityModifier = 1;
    public bool isOnGround = true;

    private Rigidbody playerRb;

    // Start is called before the first frame update
    void Start()
    {
        // This can also be achieved by making playerRb public
        // and dragging the rigidbody component into the corresponding
        // field in the Unity editor. Then the line below
        // can be removed.
        playerRb = GetComponent<Rigidbody>();

        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        // Make player jump up
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        isOnGround = true;
    }
}
