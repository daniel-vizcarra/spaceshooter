using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed, timerToShoot, howMuchDown, coolDown;
    public GameObject bullet;
    public Transform gun1;
    public int health;
    public bool goingleft;

    // Start is called before the first frame update
    void Start()
    {
        coolDown = timerToShoot;
    }

    // Update is called once per frame
    void Update()
    {
        // Disminuye el temporizador para disparar
        timerToShoot -= Time.deltaTime;
        if (timerToShoot <= 0)
        {
            Shoot();
            timerToShoot = coolDown;
        }

        // Movimiento del enemigo hacia la izquierda o derecha
        if (goingleft == true)
        {
            transform.position -= Vector3.right * speed * Time.deltaTime;
        }
        else
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }

        // Verifica si ha alcanzado el borde de la pantalla y cambia de dirección
        if (Mathf.Abs(transform.position.x) >= 7)
        {
            GoDownAndTurn();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica si el enemigo ha sido golpeado por una bala
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            health--;

            // Si la salud llega a cero, destruye al enemigo
            if (health <= 0)
            {
                Die();
            }
        }
    }

    void GoDownAndTurn()
    {
        // Incrementa la velocidad y baja un poco al enemigo, luego cambia de dirección
        speed *= 1.25f;
        transform.position -= Vector3.up * howMuchDown;
        goingleft = !goingleft;
    }

    void Shoot()
    {
        // Dispara una bala desde la posición del arma en la dirección opuesta
        Instantiate(bullet, gun1.position, Quaternion.Euler(0, 0, -180f));
    }

    void Die()
    {
        // Destruye al enemigo
        Destroy(gameObject);
    }
}
