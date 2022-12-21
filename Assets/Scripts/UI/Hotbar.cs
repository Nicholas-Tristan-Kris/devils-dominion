using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hotbar : MonoBehaviour
{
    public int openSlot = 0;

    [SerializeField] private static int numSlots = 10;
    [SerializeField] List<Slot> slots = new List<Slot>(numSlots);

    // Start is called before the first frame update
    void Start()
    {
        Slot[] tmp = GetComponentsInChildren<Slot>();
        int idx = 0;
        foreach (Slot slot in tmp) {
            slots[idx++] = slot;
            slot.inHotbar = true;
            if (slot.Item != null) openSlot++;
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
            if (slot == null) continue;
            if (Input.GetKeyDown(i.ToString())) 
                slot.use();
            
            if (slot.Slider.value > 0) 
                slot.updateCooldown(Time.deltaTime);
        }
    }

    public void removeItemFromSlot(int slot) {
        slots[slot].clear();
        if (slot < openSlot) openSlot = slot;
    }

    public void addItem(Item item) {
        if (openSlot >= numSlots) {
            //TODO tell user inventory is full
            return;
        }
        slots[openSlot++].Item = item;
        while (slots[openSlot++].Item != null && openSlot < numSlots) {}
    }
}
