using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExportButtonUI : MonoBehaviour
{
    [Header("外部参照")]
    [SerializeField] DotCanvasUI dotCanvasUI;

    private MakeTexture _make;
    public MakeTexture make
    {
        get
        {
            if(_make == null)
            {
                _make = GetComponent<MakeTexture>();
            }
            return _make;
        }
    }

    public void OnSelected()
    {
        Color[] colors = dotCanvasUI.colors;

        // Save colors as png
        make.SavePng(colors);
    }
}
