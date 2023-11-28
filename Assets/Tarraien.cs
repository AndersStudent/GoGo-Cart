using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tarraien : MonoBehaviour
{

    //Check if a cart is on the grass and give less traction
    public void OnCollisionEnter(Collision collision)
    {
        KartController Kart = collision.gameObject.GetComponent<KartController>();

        if (Kart != null)
        {
            Kart.TrackModstand = 5;
            Kart.currentSpeed -= 2;
        }
    }

    //Check if a cart is not on the grass and give it more traction
    public void OnCollisionExit(Collision collision)
    {
        KartController Kart = collision.gameObject.GetComponent<KartController>();

        if (Kart != null)
        {
            Kart.TrackModstand = 0;
        }
    }
}
