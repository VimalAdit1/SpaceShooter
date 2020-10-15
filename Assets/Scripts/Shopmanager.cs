using System;
using UnityEngine;
using UnityEngine.UI;

public class Shopmanager : MonoBehaviour
{
    public GameObject[] ships;
    public Button right;
    public Button left;
    public Button play;
    int selected;
    // Start is called before the first frame update
    void Start()
    {
        selected = PlayerPrefs.GetInt("Ship", 0);
    }

    // Update is called once per frame
    void Update()
    {
        right.interactable = !(selected == ships.Length - 1);
        left.interactable = !(selected == 0);
    }
    void changeShip(int index)
    {
        for(int i=0;i<ships.Length;i++)
        {
            ships[i].SetActive((i == index));
        }
        if(isShipUnlocked(selected))
        {
            play.interactable = true;
            PlayerPrefs.SetInt("Ship", selected);
        }
        else
        {
            play.interactable = false;
        }
    }

    private bool isShipUnlocked(int selected)
    {
        return true;
    }

    public void Right()
    {
        if(selected < ships.Length-1)
        {
            selected++;
            changeShip(selected);
        }
    }
    public void Left()
    {
        if (selected > 0)
        {
            selected--;
            changeShip(selected);
        }
    }
}
