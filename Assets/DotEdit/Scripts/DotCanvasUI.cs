using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DotCanvasUI : MonoBehaviour
{
    public Image[] images;

    public int sizeX;
    public int sizeY;
    public Color[] colors;

    // キャンバスの一部がクリックされたときに呼び出される
    public void OnClicked(Vector2 position)
    {

    }

    public void DrawDot(Point point, Color color) {
    }

    public Point GetDrawPoint(Vector2 position, Camera camera) {
        Point p = new Point(0, 0);
        return p;
    }
}
