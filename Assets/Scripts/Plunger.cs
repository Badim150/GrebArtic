using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Plunger : MonoBehaviour {

    float power;
    float minPower = 0;
    bool ballReady;
    List<Rigidbody> ballList;

    public float maxPower = 100;
    public Slider powerSlider;

    private void Start()
    {
        powerSlider.minValue = 0;
        powerSlider.maxValue = maxPower;
        ballList = new List<Rigidbody>();

    }

    private void Update()
    {
        if (ballReady)
        {
            powerSlider.gameObject.SetActive(true);
        }
        else
        {
            powerSlider.gameObject.SetActive(false);
        }



        powerSlider.value = power;
        if (ballList.Count > 0)
        {
            ballReady = true;

            if (Input.GetKey(KeyCode.Space))
            {
                if (power <= maxPower)
                {
                    power += 50 * Time.deltaTime;
                }
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                foreach (Rigidbody r in ballList)
                {
                    r.AddForce(power*Vector3.forward);
                }
            }
        }
        else
        {
            ballReady = false;
            power = minPower;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            ballList.Add(other.GetComponent<Rigidbody>());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            ballList.Remove(other.GetComponent<Rigidbody>());
            power = minPower;
        }
    }

}
