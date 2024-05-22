using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public Text coinmeter;
    public int coins = 0;
    // Start is called before the first frame update
    void Start()
    {
        coins = PlayerPrefs.GetInt("coins");
        SetCurrentCoins();
    }

    void OnDisable()
    {
        PlayerPrefs.SetInt("coins", coins);
    }

    // Update is called once per frame
    void Update()
    {
        SetCurrentCoins();
    }

    void SetCurrentCoins()
    {
        coinmeter.text = "" + coins;
    }
}
