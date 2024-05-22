using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndGameScript : MonoBehaviour
{
    public Text text;
    public void SetMessage(string message)
    {
        text.text = message;
    }
}
