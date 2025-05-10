using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;


    public int totalInterruptores = 3;
    public bool pausaDisponible = true;

    public GameObject menuPausa;


    public event Action OnInterruptoresCambiados; //(toca configurarlo en el canvas)
    public event Action OnNivelCompletado;


    private int interruptoresActivados = 0;
    private bool juegoEnPausa = false;

    private void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void Start()
    {

        interruptoresActivados = 0;


        if (menuPausa != null)
            menuPausa.SetActive(false);
    }

    void Update()
    {

        if (pausaDisponible && Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePausa();
        }
    }

    public void RegistrarInterruptorActivado()
    {
        interruptoresActivados++;


        OnInterruptoresCambiados?.Invoke();


        if (interruptoresActivados >= totalInterruptores)
        {
            OnNivelCompletado?.Invoke();
        }
    }

    public int ObtenerInterruptoresActivos()
    {
        return interruptoresActivados;
    }

    public void ReiniciarNivel()
    {

        interruptoresActivados = 0;


        Scene escenaActual = SceneManager.GetActiveScene();
        SceneManager.LoadScene(escenaActual.name); //(aquí ponen el nombre de la escena)
    }

    public void CargarSiguienteNivel()
    {

        GuardarProgreso();


        int indiceActual = SceneManager.GetActiveScene().buildIndex;
        int totalEscenas = SceneManager.sceneCountInBuildSettings;

        if (indiceActual < totalEscenas - 1)
        {
            SceneManager.LoadScene(indiceActual + 1);
        }
        else
        {

            Debug.Log("¡Juego completado!");
        }
    }

    private void GuardarProgreso()
    {

        PlayerPrefs.SetInt("NivelAlcanzado", SceneManager.GetActiveScene().buildIndex + 1);
        PlayerPrefs.Save();
    }

    public void TogglePausa()
    {
        juegoEnPausa = !juegoEnPausa;


        Time.timeScale = juegoEnPausa ? 0f : 1f;


        if (menuPausa != null)
            menuPausa.SetActive(juegoEnPausa);
    }


    public void SimularActivacionInterruptor()
    {
        RegistrarInterruptorActivado();
    }
}


