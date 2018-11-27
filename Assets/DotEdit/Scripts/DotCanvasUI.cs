using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DotCanvasUI : MonoBehaviour
{
    [Header("参照")]
    public DotCellUI cellTemplate;
    public Transform cellParent;

    [Header("設定")]
    public Color alpha1;
    public Color alpha2;

    [Header("デバッグ")]
    public DotCellUI[] cells;
    public Color[] colors;
    public Color currentColor;
    public ToolType currentToolType;

    int sizeX = 32;
    int sizeY = 32;

    public void Awake()
    {
        Setup();
        Initialize();
    }

    public void Setup() {
        cells = new DotCellUI[sizeX * sizeY];
        colors = new Color[sizeX * sizeY];

        currentColor = Color.black;
        currentToolType = ToolType.Pencil;

        for(int i = 0; i < sizeX; i++)
        {
            for(int j = 0; j < sizeY; j++)
            {
                Point point = new Point(i,j);
                int index = DotEditUtils.GetIndexFromPoint(point,sizeX);
                DotCellUI cell = Instantiate<DotCellUI>(cellTemplate,cellParent);
                cell.point = point;
                cell.onDraw = DrawDot;
                cell.gameObject.SetActive(true);
                cells[index] = cell;
                Erase(point);
            }
        }

        // テンプレートを隠す
        cellTemplate.gameObject.SetActive(false);
    }

    public void Initialize()
    {
        for(int i = 0; i < sizeX; i++)
        {
            for(int j = 0; j < sizeY; j++)
            {
                Point point = new Point(i,j);
                Erase(point);
            }
        }
    }

    public void ChangeCurrentColor(Color color)
    {
        this.currentColor = color;
    }

    public void DrawDot(Point point)
    {
        Color color = currentColor;

        int index = DotEditUtils.GetIndexFromPoint(point,sizeX);

        if(0 <= index && index < cells.Length)
        {
            if(currentToolType == ToolType.Pencil)
            {
                cells[index].image.color = color;
                colors[index] = color;
            }
            else if(currentToolType == ToolType.Eraser)
            {
                Erase(point);
            }
            else if(currentToolType == ToolType.Fill)
            {
                searched = new HashSet<Point>();
                Fill(point);
            }
        }
        else
        {
            Debug.LogWarningFormat("不正な index: {0}",index);
        }
    }

    public void Erase(Point point)
    {
        int d = point.y % 2;
        int index = DotEditUtils.GetIndexFromPoint(point,sizeX);

        if((point.x + d) % 2 == 0)
        {
            cells[index].image.color = alpha1;
        }
        else
        {
            cells[index].image.color = alpha2;
        }
        colors[index] = new Color(0f,0f,0f,0f);
    }

    HashSet<Point> searched;
    int total = 0;

    public void Fill(Point point)
    {
        total++;
        if (searched.Contains(point)) {
            return;
        }

        if (total > 10) {
            return;
        }
        Debug.LogFormat("({0}, {1})", point.x, point.y);

        searched.Add(point);
        int index = DotEditUtils.GetIndexFromPoint(point,sizeX);

        Color color = currentColor;
        if(0 <= index && index < cells.Length)
        {
            cells[index].image.color = color;
            colors[index] = color;
        }

        Point right = new Point(point.x + 1, point.y);
        Point left = new Point(point.x - 1, point.y);
        Point down = new Point(point.x, point.y + 1);
        Point up = new Point(point.x, point.y - 1);

        Fill(right);
        Fill(left);
        Fill(up);
        Fill(down);
    }

    public void ChangeCurrentTool(ToolType type)
    {
        currentToolType = type;
    }
}
