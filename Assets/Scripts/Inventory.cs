using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<Slot> slots;
    [SerializeField] private Player player;

    [Header("UI Elements")]
    [SerializeField] private GameObject backpack, hotbar;
    
    [Header("Stats")]
    [SerializeField] private float maxHealth;
    [SerializeField] private int money;
    
    private bool isOpen = false;
    private float sinceChange = 0f;
    private StatManager statManager;

    // Start is called before the first frame update
    void Start()
    {
        statManager = FindObjectOfType<StatManager>();

        Slot[] tmp = FindObjectsOfType<Slot>(); //get all slots in the game 
        foreach (Slot slot in tmp) {
            slots.Add(slot);
        }

        player = FindObjectOfType<Player>();
        if (backpack == null) backpack = GameObject.FindGameObjectWithTag("Backpack");
        if (hotbar == null) hotbar = GameObject.FindGameObjectWithTag("Hotbar");

        setInventory(false);

    }

    // Update is called once per frame
    void Update()
    {
        sinceChange += Time.deltaTime;
        if (Input.GetAxis("Inventory") > 0 && sinceChange > 0.5f) {
            isOpen = !isOpen;
            setInventory(isOpen);
            sinceChange = 0f;
        }
    }

    private void setInventory(bool open) {
        backpack.SetActive(open);
        pause(open);
    }

    private void pause(bool set) {
        //TODO create pause mechanic Time.timeScale = set ? 0 : 1;
    }

    public void swapItem(Slot swap, bool inHotbar) {
        swap = slots.Find(x => swap.Equals(x));

        if (inHotbar) {
            //TODO swap to backpack
        } else {
            //TODO swap to hotbar
            //hotbar.GetComponent<Hotbar>().addItem(swap.Item);
        }
        
    }
}
