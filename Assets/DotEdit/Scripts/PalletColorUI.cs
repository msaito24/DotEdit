using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// パレットの色
public class PalletColorUI : MonoBehaviour
{
    public Color color;

    public Action<Color> onSelected;

	private Image _image;
	public Image image {
		get {
			if (_image == null) {
				_image = GetComponent<Image>();
			}
			return _image;
		}
	}

	public void SetColor(Color _color) {
		this.color = _color;
		this.image.color = _color;
	}

    public void OnSelected()
    {
        if(onSelected != null)
        {
            onSelected(color);
        }
    }
}