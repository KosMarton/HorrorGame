using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    [SerializeField] Text HealthText;

    // Start is called before the first frame update
    void Start()
    {
        HealthText.text = SaveScript.PlayerHealth.ToString() + "%";
    }

    // Update is called once per frame
    void Update()
    {
        if (SaveScript.HealthChanged)
        {
            SaveScript.HealthChanged = false;
            HealthText.text = SaveScript.PlayerHealth.ToString() + "%";
        }
    }
}
