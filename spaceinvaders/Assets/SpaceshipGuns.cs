using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipGuns : MonoBehaviour
{
    public float cooldowntimer = .05f;
    float timerlenght;
    public GameObject bullet;
    public Transform gun1, gun2;

    // Start is called before the first frame update
    void Start()
    {
        timerlenght = cooldowntimer;
        cooldowntimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Si el botón del mouse está presionado y el cooldown ha terminado
        if (Input.GetMouseButton(0) && cooldowntimer <= 0)
        {
            // Instancia una bala en las posiciones de las dos armas
            Instantiate(bullet, gun1.position, Quaternion.identity);
            Instantiate(bullet, gun2.position, Quaternion.identity);

            // Reinicia el cooldown
            cooldowntimer = timerlenght;
        }

        // Reduce el cooldown si es mayor a 0
        if (cooldowntimer >= 0)
        {
            cooldowntimer -= Time.deltaTime;
        }
    }
}
