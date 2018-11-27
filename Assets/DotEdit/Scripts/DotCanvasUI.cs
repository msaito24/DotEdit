using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DotCanvasUI : MonoBehaviour
{
    public DotCellUI cellTemplate;
    public Image[] images;

    public int sizeX;
    public int sizeY;
    public Color[] colors;

    public Color currentColor;

    public void Awake() {
    }

    // キャンバスの一部がクリックされたときに呼び出される
    public void OnClicked(Vector2 position)
    {
        // クリックされた位置が不正な位置でないなら正しく currentColor 色を描画する.
        Point point;

        if(GetDrawPoint(position,null,out point))
        {
            DrawDot(point,currentColor);
        }
    }

    public void ChangeCurrentColor(Color color)
    {
        this.currentColor = color;
    }

    public void DrawDot(Point point,Color color)
    {
        int index = DotEditUtils.GetIndexFromPoint(point,sizeX);

        if(0 <= index && index < images.Length)
        {
            images[index].color = color;
        }
        else
        {
            Debug.LogWarningFormat("不正な index: {0}",index);
        }
    }

    public bool GetDrawPoint(Vector2 position,Camera camera,out Point point)
    {
        point = new Point(0,0);
        return false;
    }
}
