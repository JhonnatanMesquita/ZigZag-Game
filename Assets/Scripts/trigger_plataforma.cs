using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger_plataforma : MonoBehaviour
{
    private Rigidbody rb;
    public static int changeVel;
    private float maxVel = 2.2f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if(changeVel > 0 && changeVel % 10 == 0 && Main_bolinha.velocity < maxVel)
            {
                Main_bolinha.velocity += 0.2f;
            }

            if(changeVel > 0 && changeVel % 100 == 0)
            {
                Main_bolinha.velocity += 0.3f;
            }

            rb.useGravity = true;
            Destroy(gameObject, 0.2f);
            Criar_plataforma.numPlat--;
            changeVel++;
        }
    }
}
