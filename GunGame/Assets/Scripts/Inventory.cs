using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    ItemManager ItemManager;
    public bool InvOpen = false;
    public bool HoldingSomething = false;
    public GameObject inventory;
    public GameObject Fpcamera;
    [SerializeField] private PlayerCam cam;
    [SerializeField] private PlayerMovement move;

    [Header("Guns")]
    public GameObject ak15Prefab;
    public GameObject ak47Prefab;
    public GameObject natoPrefab;

    [Header("Items")]
    public GameObject medsPrefab;
    public GameObject energyDrinkPrefab;
    public GameObject energyBarPrefab;

    void Start()
    {
        ItemManager = GetComponent<ItemManager>();
    }

    void Update()
    {
        Escape();
        ItemCheck();

        if (Input.GetKeyDown(KeyCode.I))
        {
            InvOpen = true;
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            InvOpen = true;
        }

        if (InvOpen == true)
        {
            cam.enabled = false;
            move.enabled = false;
            Fpcamera.transform.rotation = Quaternion.Euler(25, Fpcamera.transform.rotation.eulerAngles.y, Fpcamera.transform.rotation.eulerAngles.z);
            HoldingSomething = false;
            inventory.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }

        if (InvOpen == false)
        {
            inventory.SetActive(false);
            move.enabled = true;
            cam.enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    void ItemCheck()
    {
        if (InvOpen == true)
        {
            //////////////////////////[ Guns ]//////////////////////////
            if (ItemManager.ar15 == 1)
            {
                ak15Prefab.SetActive(true);
            }
            else ak15Prefab.SetActive(false);
            if (ItemManager.ar47 == 1)
            {
                ak47Prefab.SetActive(true);
            }
            else ak47Prefab.SetActive(false);
            if (ItemManager.nato == 1)
            {
                natoPrefab.SetActive(true);
            }
            else natoPrefab.SetActive(false);

            //////////////////////////[ Item ]///////////////////////////
            
            if (ItemManager.meds >= 1)
            {
                medsPrefab.SetActive(true);
            }
            else medsPrefab.SetActive(false);
            if (ItemManager.energyDrink >= 1)
            {
                energyDrinkPrefab.SetActive(true);
            }
            else energyDrinkPrefab.SetActive(false);
            if (ItemManager.energyBar >= 1)
            {
                energyBarPrefab.SetActive(true);
            }
            else energyBarPrefab.SetActive(false);
        }
        else return;
    }

    void Escape()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && InvOpen == true)
        {
            ForceEscape();
        }
    }

    void ForceEscape()
    {
        InvOpen = false;
    }
}
