using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class gameManager : MonoBehaviour
{
    [SerializeField] private TMP_Text PlayerScore;
    [SerializeField] private TMP_Text IaScore;

    [SerializeField] private Transform player;
    [SerializeField] private Transform IA;
    [SerializeField] private Transform ball;

    private int puntajePlayer;
    private int puntajeIA;

    private static gameManager instance;

    public GameObject Winner;
    public GameObject Lose;

    public static gameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<gameManager>();
            }
            return instance;
        }
    }


    private void Start()
    {
        Time.timeScale = 1;
        Winner.SetActive(false);
        Lose.SetActive(false);
        puntajeIA = 0;
        puntajePlayer = 0;
        IaScore.text = puntajeIA.ToString();
        PlayerScore.text = puntajePlayer.ToString();
    }

    public void PlayerScored()
    {
        puntajePlayer++;

        PlayerScore.text = puntajePlayer.ToString();
    }

    public void IaScored()
    {
        puntajeIA++;

        IaScore.text = puntajeIA.ToString();
    }

    public void Restart()
    {
        player.position = new Vector3(player.position.x,7,player.position.z);
        IA.position = new Vector3(IA.position.x, 7, IA.position.z);
        ball.position = new Vector3(0, 7, 0);
    }

    private void Update()
    {
        if(puntajeIA == 5)
        {
            Winner.SetActive(true);
            Time.timeScale = 0;
        }
        else if(puntajePlayer == 5)
        {
            Lose.SetActive(true);
            Time.timeScale = 0;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Reiniciar();
        }
    }

    void Reiniciar()
    {
        SceneManager.LoadScene("Juego");
    }
}
