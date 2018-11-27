using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExportButtonUI : MonoBehaviour
{
    [Header("外部参照")]
    [SerializeField] DotCanvasUI dotCanvasUI;

    public void OnSelected()
    {
        Color[] colors = dotCanvasUI.colors;

        // Save colors as png
    }
}
