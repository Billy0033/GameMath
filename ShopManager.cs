using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public CoinManager coinManager;
    public PlayerMove playerMove;
    public string bought = "Куплено!";
    public string selected = "Выбрано!";
    public int select = 0;
    public Sprite sprite0;
    public int price1;
    public bool bought1;
    public Text text1;
    public Sprite sprite1;
    public int price2;
    public bool bought2;
    public Text text2;
    public Sprite sprite2;
    public int price3;
    public bool bought3;
    public Text text3;
    public Sprite sprite3;
    public int price4;
    public bool bought4;
    public Text text4;
    public Sprite sprite4;
    public int price5;
    public bool bought5;
    public Text text5;
    public Sprite sprite5;

    void Start()
    {
        LoadData();
    }

    void OnDisable()
    {
        SaveData();
    }

    void SaveData()
    {
        //Debug.Log("Saved!");
        PlayerPrefs.SetInt("bought1", bought1 ? 1 : 0);
        PlayerPrefs.SetInt("bought2", bought2 ? 1 : 0);
        PlayerPrefs.SetInt("bought3", bought3 ? 1 : 0);
        PlayerPrefs.SetInt("bought4", bought4 ? 1 : 0);
        PlayerPrefs.SetInt("bought5", bought5 ? 1 : 0);
    }

    void LoadData()
    {
        //Debug.Log(PlayerPrefs.GetInt("bought1"));
        bought1 = PlayerPrefs.GetInt("bought1") == 1;
        bought2 = PlayerPrefs.GetInt("bought2") == 1;
        bought3 = PlayerPrefs.GetInt("bought3") == 1;
        bought4 = PlayerPrefs.GetInt("bought4") == 1;
        bought5 = PlayerPrefs.GetInt("bought5") == 1;
    }

    bool TryToBuy(int price)
    {
        if(coinManager.coins >= price)
        {
            coinManager.coins -= price;
            return true;
        }
        return false;
    }

    public void Select0()
    {
        select = 0;
        SelectSkin(sprite0);
    }

    public void Select1()
    {
        if (!bought1)
        {
            if (!TryToBuy(price1))
            {
                return;
            }
            else
            {
                bought1 = true;
            }
        }
        select = 1;
        SelectSkin(sprite1);
    }

    public void Select2()
    {
        if (!bought2)
        {
            if (!TryToBuy(price2))
            {
                return;
            }
            else
            {
                bought2 = true;
            }
        }
        select = 2;
        SelectSkin(sprite2);
    }

    public void Select3()
    {
        if (!bought3)
        {
            if (!TryToBuy(price3))
            {
                return;
            }
            else
            {
                bought3 = true;
            }
        }
        select = 3;
        SelectSkin(sprite3);
    }

    public void Select4()
    {
        if (!bought4)
        {
            if (!TryToBuy(price4))
            {
                return;
            }
            else
            {
                bought4 = true;
            }
        }
        select = 4;
        SelectSkin(sprite4);
    }

    public void Select5()
    {
        if (!bought5)
        {
            if (!TryToBuy(price5))
            {
                return;
            }
            else
            {
                bought5 = true;
            }
        }
        select = 5;
        SelectSkin(sprite5);
    }

    void SelectSkin(Sprite skin)
    {
        playerMove.GetComponent<SpriteRenderer>().sprite = skin;
    }

    void Update()
    {
        if (!bought1)
        {
            text1.text = "" + price1;
        }
        else if(select == 1)
        {
            text1.text = selected;
        }
        else 
        {
            text1.text = bought;
        }

        if (!bought2)
        {
            text2.text = "" + price2;
        }
        else if (select == 2)
        {
            text2.text = selected;
        }
        else
        {
            text2.text = bought;
        }

        if (!bought3)
        {
            text3.text = "" + price3;
        }
        else if (select == 3)
        {
            text3.text = selected;
        }
        else
        {
            text3.text = bought;
        }

        if (!bought4)
        {
            text4.text = "" + price4;
        }
        else if (select == 4)
        {
            text4.text = selected;
        }
        else
        {
            text4.text = bought;
        }

        if (!bought5)
        {
            text5.text = "" + price5;
        }
        else if (select == 5)
        {
            text5.text = selected;
        }
        else
        {
            text5.text = bought;
        }
    }
}
