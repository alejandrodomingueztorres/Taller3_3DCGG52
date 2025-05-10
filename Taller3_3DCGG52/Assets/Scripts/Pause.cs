using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    [Header("Referencias UI")]
    public GameObject panelPausa;
    public Button botonContinuar;
    public Button botonReiniciar;
    public Button botonOpciones;
    public Button botonSalir;
    public Slider sliderVolumen;
    public GameObject panelOpciones;

    private GameManager gameManager;
    private AudioSource[] todasLasFuentesAudio;

    void Start()
    {
        gameManager = GameManager.Instance;

      
        if (botonContinuar != null)
            botonContinuar.onClick.AddListener(ContinuarJuego);

        if (botonReiniciar != null)
            botonReiniciar.onClick.AddListener(ReiniciarNivel);

        if (botonOpciones != null)
            botonOpciones.onClick.AddListener(MostrarOpciones);

        if (botonSalir != null)
            botonSalir.onClick.AddListener(SalirAlMenu);

       
    
        if (panelPausa != null)
            panelPausa.SetActive(false);

        if (panelOpciones != null)
            panelOpciones.SetActive(false);

       
        if (gameManager != null && gameManager.menuPausa == null)
        {
            gameManager.menuPausa = panelPausa;
        }

        
        todasLasFuentesAudio = FindObjectsOfType<AudioSource>();
    }

    void Update()
    {
       

        if (panelOpciones != null && panelOpciones.activeInHierarchy)
        {
           
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                VolverAlMenuPausa();
            }
        }
    }

    public void ContinuarJuego()
    {
        if (gameManager != null)
        {
            gameManager.TogglePausa();
        }
    }

    public void ReiniciarNivel()
    {
        Time.timeScale = 1f;

        if (gameManager != null)
        {
            gameManager.ReiniciarNivel();
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void MostrarOpciones()
    {
        if (panelPausa != null)
            panelPausa.SetActive(false);

        if (panelOpciones != null)
            panelOpciones.SetActive(true);
    }

    public void VolverAlMenuPausa()
    {
        if (panelOpciones != null)
            panelOpciones.SetActive(false);

        if (panelPausa != null)
            panelPausa.SetActive(true);
    }

    public void SalirAlMenu()
    {
       
        Time.timeScale = 1f;

        SceneManager.LoadScene(0);
    }

    
}


