using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Overview : MonoBehaviour
{
    public List<GameObject> Path;
    public int MaxLap;

    public List<KartController> Karts;
    public List<KartController> KartsList;

    public TMP_Text Place;
    public TMP_Text Lap;
    public TMP_Text LapShower;
    public TMP_Text BigPlaceText;
    public Image PowerUpSprite;

    public float Timer;
    public int Counter;

    public float CloseTimer;
    public bool WantToClose;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        KartsList = Karts.OrderByDescending(kart => kart.Points).ToList();

        for (int i = 0; i < KartsList.Count; i++)
        {
            KartsList[i].Place = i + 1;
        }

        if (Counter < 5)
        {
            if (Counter == 4)
            {
                LapShower.text = "GO!";
                WantToClose = true;

                Counter = 5;
            }
            else
            {
                if (Timer > 1)
                {
                    Counter += 1;
                    Timer = 0;
                }
                else
                {
                    Timer += Time.deltaTime;
                }

                LapShower.text = "" + Counter;
            }
        }

        if (WantToClose == true)
        {
            if (CloseTimer > 2)
            {
                LapShower.gameObject.SetActive(false);
                WantToClose = false;
                CloseTimer = 0;
            }
            else
            {
                CloseTimer += Time.deltaTime;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        KartController kartController = other.GetComponent<KartController>();

        if (kartController != null)
        {
            if (kartController.CheckPointNumber > 6)
            {
                kartController.Lap += 1;

                if (kartController.Player == true)
                {
                    LapShower.gameObject.SetActive(true);
                    Lap.text = kartController.Lap + "/" + MaxLap;


                    if (kartController.Lap  == MaxLap)
                    {
                        LapShower.text = "Finish";
                        LapShower.gameObject.SetActive(true);
                        kartController.Player = false;
                        BigPlaceText.gameObject.SetActive(true);
                        BigPlaceText.text = kartController.Place + "th";
                    }
                    else
                    {
                        LapShower.text = "Lap: " + kartController.Lap;
                        WantToClose = true;
                        LapShower.gameObject.SetActive(true);
                    }
                }
            }
        }
    }
}
