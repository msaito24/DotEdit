using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EraserToolUI : DotToolUI
{
    public override ToolType toolType
    {
        get
        {
            return ToolType.Eraser;
        }
    }
}
