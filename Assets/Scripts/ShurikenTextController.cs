using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShurikenTextController : MonoBehaviour
{
    static TextMeshProUGUI text;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    public static void UpdateCounter(int newCount)
    {
        text.text = "x" + newCount;
    }
}
