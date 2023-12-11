using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Collector : MonoBehaviour
{
    public bool hasKey = false;
    public GameObject interactBG;
    public TextMeshProUGUI interactText;
    public GameObject YouWin;
    private Door door;
    public bool SpecialDoorKey;
    public bool SpecialOpenKey;
    

    private void Start()
    {
            Time.timeScale = 1f;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ICollectable collectable = collision.GetComponent<ICollectable>();
        if (collectable != null)
        {
            collectable.Collect();
            Key K = collision.GetComponent<Key>();
            if (K)
            {
                if(K.Specialkey)
                {
                    SpecialDoorKey = true;
                }
                else if(K.Openkey)
                {
                    SpecialOpenKey = true;
                }
                else if (K.Normalkey)
                {
                    hasKey = true;
                }
                

            }
        }

        door = collision.gameObject.GetComponent<Door>();
        if(door)
        {
            if (door.SpecialDoor)
            {
                if (!door.isOpened && SpecialDoorKey)
                {
                    interactBG.SetActive(true);
                    interactText.text = "Press 'E' to open door.";
                }
                else if ( !door.isOpened && !SpecialDoorKey)
                {
                    interactBG.SetActive(true);
                    interactText.text = "Find 'Special Key' to open door.";
                }
            }
            else if(door.Openinig)
            {
                if (!door.isOpened && SpecialOpenKey)
                {
                    interactBG.SetActive(true);
                    interactText.text = "Press 'E' to open door.";
                }
                else if (!door.isOpened && !SpecialOpenKey)
                {
                    interactBG.SetActive(true);
                    interactText.text = "Find 'A Boss and Kill Him to Get a Key' to open door.";
                }
            }
            else
            {
                if (!door.isOpened && hasKey)
                {
                    interactBG.SetActive(true);
                    interactText.text = "Press 'E' to open door.";
                }
                else if ( !door.isOpened && !hasKey)
                {
                    interactBG.SetActive(true);
                    interactText.text = "Find 'Key' to open door.";
                }
            }
        }
        if (collision.gameObject.CompareTag("Win"))
        {
            Time.timeScale = 0f;
            YouWin.SetActive(true);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Door>())
            interactBG.SetActive(false);


        
    }

    private void Update()
    {
        if (door != null && !door.isOpened && hasKey && Input.GetKeyDown(KeyCode.E))
        {
            door.OpenDoor();
            hasKey = false;
            SpecialOpenKey = false;
            SpecialDoorKey = false;
        }
    }
}
