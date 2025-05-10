using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContadorObjetos : MonoBehaviour
{
    public static ContadorObjetos instance;
    public static int contadorEsferas = 0;
    public static int contadorCubos = 0;
    public static int contadorCapsulas = 0;

    public string tipoObjeto;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("moveobject"))
        {
            switch (tipoObjeto)
            {
                case "Capsule":
                    contadorCapsulas++;
                    break;
                case "Sphere":
                    contadorEsferas++;
                    break;
                case "Cube":
                    contadorCubos++;
                    break;
            }
            ActualizarUI();
            Destroy(gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("moveobject"))
        {
            switch (tipoObjeto)
            {
                case "Capsule":
                    if (contadorCapsulas > 0) contadorCapsulas--;
                    break;
                case "Sphere":
                    if (contadorEsferas > 0) contadorEsferas--;
                    break;
                case "Cube":
                    if (contadorCubos > 0) contadorCubos--;
                    break;
            }
            ActualizarUI();
        }
    }

    private void ActualizarUI()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ContadordeObjetos()
    {
        contadorEsferas++;
        contadorCubos++;
        contadorCapsulas++;


    }
}
