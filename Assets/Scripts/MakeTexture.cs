using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class MakeTexture : MonoBehaviour {
    public Image target;

    // Use this for initialization
    void Start () {
        Make();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SavePng(Color[] cols) {
        Texture2D m_texture = new Texture2D(64, 64, TextureFormat.ARGB32, false);
        m_texture.name = "test";

        for (int y = 0; y < m_texture.height; y++) {
            for (int x = 0; x < m_texture.width; x++) {
                m_texture.SetPixel(x, y, cols[x]);
            }
        }
        int piX = 0;
        int piY = 0;
        for (int index = 0; index < 4096; index++) {
            //piX = index


            //m_texture.SetPixel(x, y, cols[index]);
        }



        for (int i = 0; i < 4096; i++) cols[i] = Color.green;
        m_texture.SetPixels(0, 0, 64, 64, cols);
        m_texture.Apply();
        SavePngTest(m_texture);
        display(m_texture);
    }

    void Make() {
        Texture2D m_texture = new Texture2D(64, 64, TextureFormat.ARGB32, false);
        m_texture.name = "test";
        Color[] cols = new Color[4096];
        for (int i = 0; i < 4096; i++) cols[i] = Color.green;
        m_texture.SetPixels(0, 0, 64, 64, cols);
        m_texture.Apply();
        SavePngTest(m_texture);
        display(m_texture);
    }

    void SavePngTest(Texture2D tex) {
        byte[] pngData = tex.EncodeToPNG();   // pngのバイト情報を取得.

        // ファイルダイアログの表示.
        string filePath = EditorUtility.SaveFilePanel("Save Texture", "", tex.name + ".png", "png");

        if (filePath.Length > 0) {
            // pngファイル保存.
            File.WriteAllBytes(filePath, pngData);
        }
    }

    void display(Texture2D tex) {
        Sprite sprite = Sprite.Create(
          texture: tex,
          rect: new Rect(0, 0, tex.width, tex.height),
          pivot: new Vector2(0.5f, 0.5f)
        );
        target.sprite = sprite;
    }
}
