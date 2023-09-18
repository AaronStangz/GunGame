using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [Header("Mats")]
    public int trashBlockCount;

    [Header("Items")]
    public int meds;
    public int energyDrink;
    public int energyBar;

    [Header("Guns")]
    public int ar15;
    public int ar47;
    public int nato;

    [Header("ammo")]
    public int arAmmo;
    public int smgAmmo;
    public int shotgunAmmo;

    [Header("MaxItems")]
    public int maxMeds;
    public int maxEnergyDrink;
    public int maxEnergyBar;
}
