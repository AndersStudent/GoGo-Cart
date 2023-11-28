using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MistroyBoxSpawner : MonoBehaviour
{
    public GameObject MistroyBoxPrefab;

    public float Timer;
    public bool SpawnNew;

    // Start is called before the first frame update
    void Start()
    {
        SpawnMistroyBoxPrefab();
    }

    // Update is called once per frame
    void Update()
    {
        if (SpawnNew == true)
        {
            if (Timer > 10)
            {
                SpawnNew = false;
                Timer = 0;
                SpawnMistroyBoxPrefab();
            }
            else
            {
                Timer += Time.deltaTime;
            }
        }
    }

    public void SpawnMistroyBoxPrefab()
    {
        MistroyBox mistroyBox = Instantiate(MistroyBoxPrefab, transform.transform.position, MistroyBoxPrefab.transform.rotation, transform).GetComponent<MistroyBox>();
        mistroyBox.Spawner = this;
    }
}
