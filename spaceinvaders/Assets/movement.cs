using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    float mx;
    public float movementSpeed = 5f;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Asigna el valor de Input.GetAxis a mx
        mx = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate(){
        // Calcula el movimiento y actualiza la velocidad del Rigidbody
        Vector2 movement = new Vector2(mx * movementSpeed, rb.velocity.y);
        rb.velocity = movement;
    }
}
