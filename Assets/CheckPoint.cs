using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public int CheckPointNumber;


    //Check if a cart hits the checkpoint and send the info to the kart
    public void OnTriggerEnter(Collider other)
    {
        KartController kartController = other.GetComponent<KartController>();

        if (kartController != null)
        {
            kartController.CheckPointNumber = CheckPointNumber;
        }
    }
}
