using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class Collect : MonoBehaviour
{
    public float pickUpRange;

    [Header("What To Give")]
    public int AmountToGiveMeds;
    public int AmountToGiveEnergyDrink;
    public int AmountToGiveEnergyBar;

    [Header("Guns")]
    public int GiveAR15;
    public int GiveAR47;

    GameObject player;
    ItemManager ItemManager;
    void Start()
    {
        player = GameObject.Find("Player");
        ItemManager = player.GetComponent<ItemManager>();
    }
    public void CollectItem()
    {
        if (ItemManager.meds < ItemManager.maxMeds)
        {
            ItemManager.meds += AmountToGiveMeds;
        }
        if(ItemManager.energyDrink < ItemManager.maxEnergyDrink)
        {
            ItemManager.energyDrink += AmountToGiveEnergyDrink;
        }
        if (ItemManager.energyBar < ItemManager.maxEnergyBar)
        {
            ItemManager.energyBar += AmountToGiveEnergyBar;
        }
        if (ItemManager.ar15 < 1)
        {
            ItemManager.ar15 += GiveAR15;
        }
        if (ItemManager.ar47 < 1)
        {
            ItemManager.ar47 += GiveAR47;
        }
        Destroy(gameObject);
    }
}
