using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour, ICollectable
{
    public static event HandleKeyCollected OnKeyCollected;
    public delegate void HandleKeyCollected(ItemData itemData);
    public ItemData keyData;
    public bool Specialkey = false;
    public bool Openkey = false;
    public bool Normalkey = false;
    public void Collect()
    {
        Debug.Log("Key Collected");
        SoundManager.Instance.CoinSound();
        Destroy(gameObject);
        OnKeyCollected?.Invoke(keyData);
    }
}
