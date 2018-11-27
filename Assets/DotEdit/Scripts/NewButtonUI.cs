using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewButtonUI : MonoBehaviour
{
    [Header("外部参照")]
    [SerializeField] DotCanvasUI dotCanvasUI;

    public void OnSelected()
    {
        dotCanvasUI.Initialize();
    }
}
