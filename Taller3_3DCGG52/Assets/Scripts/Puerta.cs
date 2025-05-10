using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta : MonoBehaviour
{
    public float speed;
    public float angle;
    public Vector3 direction;

    public bool puedeAbrir;
    public bool abrir;

    // Start is called before the first frame update
    void Start()
    {
        angle = transform.eulerAngles.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Round(transform.eulerAngles.y) != angle)
        {
            transform.Rotate(direction * speed);
        }

        if (Input.GetButtonDown("Fire1") && puedeAbrir == true && abrir == false)
        {
            angle = 80;
            direction = Vector3.up;
            abrir = true;
        }
        else if (Input.GetButtonDown("Fire1") && puedeAbrir == true && abrir == true)
        {
            angle = 0;
            direction = Vector3.down;
            abrir = false;
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            puedeAbrir = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            puedeAbrir = false;
        }
    }

}
