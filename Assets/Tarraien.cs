using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tarraien : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        KartController Kart = collision.gameObject.GetComponent<KartController>();

        if (Kart != null)
        {
            Kart.TrackModstand = 5;
            Kart.currentSpeed -= 2;
        }
    }

    public void OnCollisionExit(Collision collision)
    {
        KartController Kart = collision.gameObject.GetComponent<KartController>();

        if (Kart != null)
        {
            Kart.TrackModstand = 0;
        }
    }
}
