using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// パレットの色
public class PalletColorUI : MonoBehaviour
{
    public Color color;

    public Action<Color> onSelected;

    public void OnSelected()
    {
        if(onSelected != null)
        {
            onSelected(color);
        }
    }
}