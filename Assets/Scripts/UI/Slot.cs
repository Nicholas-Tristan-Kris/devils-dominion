using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [SerializeField] private Item item;
    private Slider slider;
    private float timeLeftInCooldown;

    public Image image;
    public float TimeLeftInCooldown {get; set;}
    public Slider Slider {get; set;}
    public Item Item {get; set;}

    void Start() {
        slider = GetComponentInChildren<Slider>();
        if (slider == null) {Debug.LogError("No Slider Found In Child Of Slot");}
        image = GetComponent<Image>();
    }

    public void use() {
        item.useItem();
        timeLeftInCooldown = item.Cooldown;
        slider.value = slider.maxValue;

        if (item.Uses == 0) {
            clear();
        }
    }

    public void updateCooldown(float newTime) {
        slider.value -= slider.value - newTime >= 0 ? newTime : 0;
    }

    public void clear() {
        item = null;
        image.sprite = null;
    }

    public void set(Item item) {
        this.item = item;
        slider.maxValue = item.Cooldown;
    }
}
