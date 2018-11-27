﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DotCanvasUI : MonoBehaviour
{
    [Header("参照")]
    public DotCellUI cellTemplate;
    public Transform cellParent;

    [Header("デバッグ")]
    public int sizeX;
    public int sizeY;
    public DotCellUI[] cells;
    public Color[] colors;
    public Color currentColor;
    public ToolType currentToolType;

    public void Awake()
    {
        cells = new DotCellUI[sizeX * sizeY];
        colors = new Color[sizeX * sizeY];

        for(int i = 0; i < sizeX; i++)
        {
            for(int j = 0; j < sizeY; j++)
            {
                Point point = new Point(i,j);
                int index = DotEditUtils.GetIndexFromPoint(point, sizeX);
                DotCellUI cell = Instantiate<DotCellUI>(cellTemplate, cellParent);
                cell.point = point;
                cell.onDraw = DrawDot;
                cells[index] = cell;
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
            if (currentToolType == ToolType.Pencil) {
                cells[index].image.color = color;
                colors[index] = color;
            }
            else if (currentToolType == ToolType.Eraser) {
                color = new Color(0f, 0f, 0f, 0f);
                cells[index].image.color = color;
                colors[index] = color;
            }
        }
        else
        {
            Debug.LogWarningFormat("不正な index: {0}",index);
        }
    }

    public void ChangeCurrentTool(ToolType type) {
        currentToolType = type;
    }
}
