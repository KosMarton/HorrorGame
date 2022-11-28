using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    RaycastHit hit;
    [SerializeField] float Distance = 4.0f;
    [SerializeField] GameObject PickupMessage;

    private float RayDistance;
    private bool CanSeePickup = false;

    // Start is called before the first frame update
    void Start()
    {
        PickupMessage.gameObject.SetActive(false);
        RayDistance = Distance;
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, RayDistance))
        {
            if (hit.transform.CompareTag("Apple"))
            {
                CanSeePickup = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Destroy(hit.transform.gameObject);
                    SaveScript.Apples++;
                }
            }
            else if (hit.transform.CompareTag("Battery"))
            {
                CanSeePickup = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (SaveScript.Batteries < 4)
                    {
                        Destroy(hit.transform.gameObject);
                        SaveScript.Batteries++;
                    }
                }
            }
            else
            {
                CanSeePickup = false;
            }
        }

        if (CanSeePickup)
        {
            PickupMessage.gameObject.SetActive(true);
            RayDistance = 1000f;
        }
        else
        {
            PickupMessage.gameObject.SetActive(false);
            RayDistance = Distance;
        }
    }
}
