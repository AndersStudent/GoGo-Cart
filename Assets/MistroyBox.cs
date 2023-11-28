using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PowerUpsClass
{
    public string Name;
    public Sprite Sprite;

    public PowerUpsClass(string name, Sprite sprite)
    {
        Name = name;
        Sprite = sprite;
    }
}

public class MistroyBox : MonoBehaviour
{
    public List<PowerUpsClass> PowerUps;

    public MistroyBoxSpawner Spawner;

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
            if (kartController.ItemString.Name == "")
            {
                Spawner.SpawnNew = true;
                Destroy(this.gameObject);


                int _rr = Random.Range(0, PowerUps.Count);

                PowerUpsClass powerUpsClass = new PowerUpsClass(PowerUps[_rr].Name, PowerUps[_rr].Sprite);
                kartController.ItemString = powerUpsClass;

                if (kartController.Player == true)
                {
                    FindObjectOfType<Overview>().PowerUpSprite.sprite = PowerUps[_rr].Sprite;
                    FindObjectOfType<Overview>().PowerUpSprite.color = new Color(255, 255, 255, 255);
                }
            }
        }
    }
}
