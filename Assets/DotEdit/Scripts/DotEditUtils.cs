using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DotEditUtils
{
    public static Point GetPointFromIndex(int index, int width)
    {
        int x = index % width;
        int y = index / width;
        return new Point(x,y);
    }

    public static int GetIndexFromPoint(Point point, int width)
    {
        return point.y * width + point.x; 
    }

}
