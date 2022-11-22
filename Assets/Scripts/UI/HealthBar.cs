using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Player player;
    private Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        slider = GetComponent<Slider>();
        slider.maxValue = player.maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = player.health;
    }
}
