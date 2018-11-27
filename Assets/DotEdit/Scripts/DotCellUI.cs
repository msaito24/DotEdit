﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DotCellUI : MonoBehaviour {
	public Point point;
	public Action<Point> onDraw;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseEnter() {
        if (Input.GetMouseButton(0)) {
            onDraw(point);
        }
    }

    void OnMouseDown() {
        onDraw(point);
    }
}
