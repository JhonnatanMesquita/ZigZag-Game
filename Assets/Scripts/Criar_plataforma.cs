using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Criar_plataforma : MonoBehaviour
{

    [SerializeField]
    private GameObject plataforma, moeda;

    private float tamanhoX;
    private Vector3 ultPos;
    private int maxPlat = 15;
    public static int numPlat;

    // Start is called before the first frame update
    void Start()
    {
        ultPos = plataforma.transform.position;
        tamanhoX = plataforma.transform.localScale.x;

        for(int i = 0; i < 10; i++)
        {
            CriaRandom();
        }

        StartCoroutine(CriaInGame());
    }

    void CriaX(int rand)
    {
        Vector3 tempPos = ultPos;
        tempPos.x += tamanhoX;
        ultPos = tempPos;
        Instantiate(plataforma, tempPos, Quaternion.identity);

        if(rand <= 2)
        {
            Instantiate(moeda, new Vector3(tempPos.x, tempPos.y + 0.15f, tempPos.z), moeda.transform.rotation);
        }
    }

    void CriaZ(int rand)
    {
        Vector3 tempPos = ultPos;
        tempPos.z += tamanhoX;
        ultPos = tempPos;
        Instantiate(plataforma, tempPos, Quaternion.identity);
        if (rand <= 2)
        {
            Instantiate(moeda, new Vector3(tempPos.x, tempPos.y + 0.15f, tempPos.z), moeda.transform.rotation);
        }
    }

    void CriaRandom()
    {
        int rand = Random.Range(0, 10);

        if (numPlat < maxPlat)
        {
            if (rand % 2 == 0)
            {
                CriaX(rand);
                numPlat++;
            }
            else
            {
                CriaZ(rand);
                numPlat++;
            }
        }
    }

    IEnumerator CriaInGame()
    {
        while (!Main_bolinha.gameOver)
        {
            yield return new WaitForSeconds(0.1f);
            CriaRandom();
        }
    }
}
