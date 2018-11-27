using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotToolUI : MonoBehaviour
{
    [Header("外部参照")]
    [SerializeField] DotCanvasUI dotCanvasUI;

    public virtual ToolType toolType
    {
        get
        {
            return ToolType.None;
        }
    }

    public virtual void OnSelected()
    {
        // TODO impl
        // dotCanvasUI.ChangeCurrentTool(toolType);
    }
}
