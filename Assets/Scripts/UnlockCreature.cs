using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class UnlockCreature : MonoBehaviour
{
    public static UnlockCreature Instance;
    public GameObject Panel;
    public Image[] Lock;
    private void Awake()
    {
        Time.timeScale = 1f;
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }


    }
   public void Unlock(int ndex)
    {
        Lock[ndex].gameObject.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            Time.timeScale = 0f;
            Panel.SetActive(true);
        }
    }

    public void CloseUnlockPanel()
    {
        Time.timeScale = 1f;
        Panel.SetActive(false);

    }
}
