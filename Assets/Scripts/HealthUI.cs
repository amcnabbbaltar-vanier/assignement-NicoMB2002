using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class HealthUI : MonoBehaviour
{
    public TextMeshProUGUI healthText;

    void Update()
    {
        healthText.text = "Health: " + GameManager.Instance.health;
    }

}
