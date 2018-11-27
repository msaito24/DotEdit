using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotPalletUI : MonoBehaviour
{
    [Header("外部参照")]
    public DotCanvasUI dotCanvasUI;

    [Header("参照")]
    public PalletColorUI template;
    public Transform parent;
    public PalletColorUI[] colorUIs;

    [Header("設定")]
	public Color[] colors;

    public void Awake()
    {
        colorUIs = new PalletColorUI[16];
        for(int i = 0; i < 16; i++)
        {
            colorUIs[i] = Instantiate<PalletColorUI>(template,parent);
            colorUIs[i].gameObject.SetActive(true);
			colorUIs[i].onSelected = OnSelected;
			colorUIs[i].color = colors[i];
        }
        template.gameObject.SetActive(false);
    }

    public void OnSelected(Color color)
    {
        dotCanvasUI.ChangeCurrentColor(color);
    }
}
