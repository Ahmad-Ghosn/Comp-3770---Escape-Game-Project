using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Sprite openSprite;
    public SpriteRenderer doorSprite;
    public BoxCollider2D boxCollider;
    public bool isOpened = false;
    public bool SpecialDoor = false;
    public bool Openinig = false;
    public void OpenDoor()
    {
        doorSprite.sprite = openSprite;
        boxCollider.isTrigger = true;
        isOpened = true;
    }
}
