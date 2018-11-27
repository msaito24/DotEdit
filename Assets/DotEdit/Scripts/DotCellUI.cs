using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class DotCellUI : MonoBehaviour {
	public Point point;
	public Action<Point> onDraw;
	
	private Image _image;
	public Image image {
		get {
			if (_image == null) {
				_image = GetComponent<Image>();
			}
			return _image;
		}
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
