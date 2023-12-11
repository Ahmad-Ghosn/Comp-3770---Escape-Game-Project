using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class SoundManager : MonoBehaviour
{
    public AudioSource CoinSource;
    public static SoundManager Instance;


    private void Awake()
    {
        if(Instance==null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }


    public void CoinSound()
    {
        CoinSource.Play();
    }
}
