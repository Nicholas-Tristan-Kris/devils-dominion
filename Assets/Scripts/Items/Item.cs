using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public static string NAME = "DEFAULT";
    public static string DESCRIPTION = "THIS IS A DEFAULT DESCRIPTION";
    public static string PRICE;

    [SerializeField] protected int usesLeft;
    [SerializeField] protected float cooldown;
    [SerializeField] protected int sellPrice;
    public float Cooldown {get; set;}
    [SerializeField] protected Image image;
    public Image Image {get; set;}
    public int Uses {get; set;}


    // Start is called before the first frame update
    void Start()
    {
        PRICE = sellPrice.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void useItem() {
        //TODO setup basic item use 
    }
}
