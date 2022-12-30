using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Vector3 initialPos;
    Vector3 initialPlayerPos;
    [SerializeField] Transform player;

    private Rigidbody Rg;
    // Start is called before the first frame update
    void Start()
    {
        initialPos = transform.position;
        initialPlayerPos = player.position;
        Rg = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Wall") || collision.transform.CompareTag("Net"))
        {
            Debug.Log("Hit");
            Invoke("resetPos",1f);
        }
    }

    void resetPos(){
        Debug.Log("reset");
        Rg.velocity = Vector3.zero;
        transform.position = initialPos;
        player.position = initialPlayerPos;
    }
}
