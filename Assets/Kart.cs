using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class KartController : MonoBehaviour
{
    public Overview Ov;
    public GameObject Cam;

    public int Place;
    public int Points;

    public bool Player;
    public List<GameObject> Path;
    public int CheckPointNumber;
    public int Lap;

    public float topSpeed;
    public float acceleration;
    public float turnSpeed;
    public float brakeSpeed;

    public ParticleSystem GasParticel; 

    public float currentSpeed;
    public float currentTurnSpeed;

    public float TrackModstand;
    Vector3 GoingForPoint;

    public PowerUpsClass ItemString;

    private void Start()
    {
        Ov = FindAnyObjectByType<Overview>();
        Ov.Karts.Add(this);

        Path = new List<GameObject>(Ov.Path);
        Lap = 1;

        if (Player == true)
        {
            Cam.SetActive(true);
            Ov.Lap.text = Lap + "/" + Ov.MaxLap;
        }
        else
        {
            Cam.SetActive(false);
        }

        GetNewGoForPoint();
    }

    private void Update()
    {
        Points = Lap * 1000000 + CheckPointNumber * 10000 + 1000 - (int)Vector3.Distance(transform.position, Path[CheckPointNumber].transform.position);

        if (Player == true)
        {
            Ov.Place.text = Place + "th";

            if (Input.GetKey(KeyCode.W))
            {
                Acceleration();
                GasParticel.Play();
            }
            else if (Input.GetKey(KeyCode.S))
            {
                Break();
                GasParticel.Stop();
            }
            else
            {
                SlowDown(2);
                GasParticel.Stop();
            }

            if (Ov.Counter == 5)
            {
                transform.Translate(Vector3.right * currentSpeed * Time.deltaTime);
            }


            if (Input.GetKey(KeyCode.D))
            {
                currentTurnSpeed = turnSpeed;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                currentTurnSpeed = -turnSpeed;
            }
            else
            {
                currentTurnSpeed = 0;
            }

            if (Input.GetKey(KeyCode.Space))
            {
                if (ItemString.Name == "SpeedUp")
                {
                    Debug.Log("SpeedUp");
                    currentSpeed = 20;
                }

                Ov.PowerUpSprite.color = new Color(255, 255, 255, 0);
                PowerUpsClass powerUpsClass = new PowerUpsClass("", null);
                ItemString = powerUpsClass;
            }

            transform.Rotate(Vector3.up * currentTurnSpeed * Time.deltaTime);
        }
        else
        {
            if (Vector3.Distance(transform.position, Path[CheckPointNumber].transform.position) > .0000001)
            {
                Acceleration();
                GasParticel.Play();

                if (Ov.Counter == 5)
                {
                    transform.Translate(Vector3.right * currentSpeed * Time.deltaTime);
                }
            }

            GetNewGoForPoint();

            if (Ov.Counter == 5)
            {
                Vector3 directionToWaypoint = (GoingForPoint - transform.position).normalized;

                Quaternion targetRotation = Quaternion.Euler(0f, -90f, 0f) * Quaternion.LookRotation(directionToWaypoint);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 3.0f);
            }

            if (ItemString.Name == "SpeedUp")
            {
                Debug.Log("SpeedUp");
                currentSpeed = 20;

                PowerUpsClass powerUpsClass = new PowerUpsClass("", null);
                ItemString = powerUpsClass;
            }
        }
    }

    public void Acceleration()
    {
        if (currentSpeed < topSpeed - TrackModstand)
        {
            currentSpeed += acceleration * Time.deltaTime;
        }
        else
        {
            SlowDown(4);
        }
    }

    public void Break()
    {
        if (currentSpeed > -1)
        {
            currentSpeed -= brakeSpeed * Time.deltaTime;
        }
    }

    public void SlowDown(int downForce)
    {
        if (currentSpeed > 0)
        {
            currentSpeed -= downForce * Time.deltaTime;
        }
        else if (currentSpeed < 0)
        {
            currentSpeed += downForce * Time.deltaTime;
        }
    }

    public void GetNewGoForPoint()
    {
        GoingForPoint = new Vector3(Path[CheckPointNumber].transform.position.x + Random.Range(-12,12.1f), 0, Path[CheckPointNumber].transform.position.z + Random.Range(-12, 12.1f));
    }
}
