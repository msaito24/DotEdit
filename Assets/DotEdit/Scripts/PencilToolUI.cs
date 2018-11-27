using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PencilToolUI : DotToolUI
{
    public override ToolType toolType
    {
        get
        {
            return ToolType.Pencil;
        }
    }
}
