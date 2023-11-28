using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public int CheckPointNumber;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        KartController kartController = other.GetComponent<KartController>();

        if (kartController != null)
        {
            kartController.CheckPointNumber = CheckPointNumber;
        }
    }
}
