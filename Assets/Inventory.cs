using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<Slot> slots;
    [SerializeField] private Player player;

    [Header("UI Elements")]
    [SerializeField] private GameObject backpack, hotbar;
    
    [Header("Stats")] //TODO stats here
    [SerializeField] private float maxHealth;
    [SerializeField] private int money;
    
    private bool isOpen = false;


    // Start is called before the first frame update
    void Start()
    {
        Slot[] tmp = FindObjectsOfType<Slot>(); //get all slots in the game 
        foreach (Slot slot in tmp) {
            slots.Add(slot);
        }

        player = FindObjectOfType<Player>();
        backpack = GameObject.FindGameObjectWithTag("Backpack");
        hotbar = GameObject.FindGameObjectWithTag("Hotbar");

        openInventory();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Inventory") != 0) {
            openInventory();
            isOpen = !isOpen;
        }
    }

    private void openInventory() {
        backpack.SetActive(isOpen);
        //TODO maybe some pause stuff here?
    }

    public void swapItem(Slot swap, bool inHotbar) {
        swap = slots.Find(x => swap.Equals(x));

        if (inHotbar) {
            //TODO swap to backpack
        } else {
            //TODO swap to hotbar
            hotbar.GetComponent<Hotbar>().addItem(swap.Item);
        }
        
    }
}
