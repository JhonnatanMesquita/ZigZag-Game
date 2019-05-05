using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Main_bolinha : MonoBehaviour
{
    public static float velocity = 0.8f; //velocidade da bolinha
    public static bool gameOver = false;
    private int numMoedas;

    [SerializeField]        //Mostrar campo na Unity
    private Rigidbody rb;   //Corpo da bolinha

    [SerializeField]
    private Text moedaTxt, recordTxt;

    [SerializeField]
    private GameObject moedaSfx, changeSfx, gameOverCanvas;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(velocity, 0, 0);
        gameOverCanvas.SetActive(false);
        recordTxt.text = "Record: " + PlayerPrefs.GetInt("Record").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && !gameOver)
        {
            BolaMov();
        }

        if (!Physics.Raycast(transform.position, Vector3.down, 1))
        {
            gameOver = true;
            rb.useGravity = true;
        }

        if (gameOver)
        {
            gameOverCanvas.SetActive(true);

            if (numMoedas > PlayerPrefs.GetInt("Record")) { 
                PlayerPrefs.SetInt("Record", numMoedas);
                recordTxt.text = "Record: " + PlayerPrefs.GetInt("Record").ToString();
            }

            if (Input.GetMouseButtonDown(0))
            {
                Reset();
            }

        }

        if (Input.GetKeyDown(KeyCode.R)) //recarregar o level
        {
            Reset();
        }
    }

    void BolaMov()
    {
        Instantiate(changeSfx);
        if(rb.velocity.x > 0)
        {
            rb.velocity = new Vector3(0, 0, velocity);
        }
        else
        {
            rb.velocity = new Vector3(velocity, 0, 0);
        }
    }

    private void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gameOver = false;
        velocity = 0.8f;
        numMoedas = 0;
        Criar_plataforma.numPlat = 0;
        trigger_plataforma.changeVel = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Moeda"))
        {
            Destroy(other.gameObject);
            numMoedas++;
            moedaTxt.text = numMoedas.ToString();
            Instantiate(moedaSfx);
        }
    }
}
