using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UIElements;

public class Raycast : MonoBehaviour
{
    [SerializeField] private LayerMask Interactable;
    [SerializeField] private LayerMask Collectable;
    [SerializeField] private LayerMask InvItem;

    private LootBox LookingAtBox;
    private Collect LookingAtItem;
    void Update()
    {
        if (Camera.main == null) return;

        RaycastHit hit;

        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * 1000);
        if (Physics.SphereCast(ray, 0.5f, out hit, 10, Interactable + Collectable + InvItem))
        {   
            
            if (Interactable.value == (1 << hit.collider.gameObject.layer))
            {   
                LootBox box = hit.collider.GetComponent<LootBox>();
                if(box != null)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if (Vector3.Distance(transform.position, box.transform.position) < box.OpenRange)
                        {
                            Debug.Log("Opened");
                            box.open();
                        }
                    }
                }
            }
            if (Collectable.value == (1 << hit.collider.gameObject.layer))
            {
                Collect item = hit.collider.GetComponent<Collect>();
                if(item != null) 
                {   
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if (hit.distance < item.pickUpRange)
                        {
                            Debug.Log("Collected");
                            item.CollectItem();
                        }
                    }
                }
            } 
        }
    }
}
