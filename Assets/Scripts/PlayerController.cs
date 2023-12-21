using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;

    // Start is called before the first frame update
    void Start()
    {
        // This can also be achieved by making playerRb public
        // and dragging the rigidbody component into the corresponding
        // field in the Unity editor. Then the line below
        // can be removed.
        playerRb = GetComponent<Rigidbody>();

        // Make player jump up
        playerRb.AddForce(Vector3.up * 1000);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
