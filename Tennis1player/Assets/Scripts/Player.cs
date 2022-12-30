using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform target;
    float speed = 3f;
    float force = 13f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");

        float v = Input.GetAxisRaw("Vertical");

        if (h != 0 || v != 0)
        {
            transform.Translate(new Vector3(h, 0, v) * speed * Time.deltaTime);
            // Debug.Log(h);
            // Debug.Log(v);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            Vector3 direction = target.position - transform.position;
            Debug.Log(direction);
            Debug.Log(direction.normalized);
            other.GetComponent<Rigidbody>().velocity = direction.normalized * force + new Vector3(0 , 6 , 0);
        }
    }
}

