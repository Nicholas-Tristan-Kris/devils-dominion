using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmorSlot : Slot
{

    [SerializeField] private Image empty; 

    public ArmorSlot() : base() {

    }


    // Start is called before the first frame update
    new void Start()
    {
        base.Start(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
