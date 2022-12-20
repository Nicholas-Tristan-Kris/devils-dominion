using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hotbar : MonoBehaviour
{

    [SerializeField] private static int numSlots = 10;
    [SerializeField] List<Slot> slots = new List<Slot>();
    
    private int currSlot = -1;

    // Start is called before the first frame update
    void Start()
    {
        Slot[] tmp = GetComponentsInChildren<Slot>();
        foreach (Slot slot in tmp) {
            slots.Add(slot);
            if (slots.Count > numSlots) {
                Debug.LogError("More slots discovered than allowed");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < numSlots; i++) {
            Slot slot = slots[i];
            if (Input.GetButtonDown(i.ToString())) 
                slot.use();
            
            if (slot.Slider.value > 0) 
                slot.updateCooldown(Time.deltaTime);
        }
    }

    public void removeItemFromSlot(int slot) {
        slots[slot].clear();
    }
}
