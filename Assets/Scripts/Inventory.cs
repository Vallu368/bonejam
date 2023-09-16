using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool isOpen = false; 
    GameObject inventoryHolder;
    public KeyCode openInventoryButton = KeyCode.I; //invu nappi, voi vaihtaa editorissa mihin vaan tai tästä
    private void Awake()
    {
        inventoryHolder = GameObject.Find("InventoryHolder");
        inventoryHolder.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(openInventoryButton))  
        {
            if (inventoryHolder != null) //tulee debuggi jos scenessä eioo invu holderia
            {
                OpenAndCloseInventory(isOpen);
            }
            else Debug.Log("no InventoryHolder set up in canvas");  
        }
    }

    private void OpenAndCloseInventory(bool isInventoryOpen) //oma booli nii ei tuu open ja close yhtäaikaa
    {
        if (isInventoryOpen == true)
        {
            isOpen = false;
            inventoryHolder.SetActive(false);
            Debug.Log("closed inventory");
        }
        else
        {
            isOpen = true;
            inventoryHolder.SetActive(true);
            Debug.Log("opened inv");
        }

    }
}
