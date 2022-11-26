using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;

public class BatteryPower : MonoBehaviour
{
    [SerializeField] Image BatteryUI;
    [SerializeField] float DrainTime = 15.0f;
    [SerializeField] float Power;

    // Update is called once per frame
    void Update()
    {
        if (SaveScript.FlashLightOn || SaveScript.NVLightOn)
        {
            BatteryUI.fillAmount -= 1.0f / DrainTime * Time.deltaTime;
            Power = BatteryUI.fillAmount;
            SaveScript.BatteryPower = Power;
        }
    }
}
