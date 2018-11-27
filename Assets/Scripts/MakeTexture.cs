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
        //Make();
       //LoadPng();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void SavePng(Color[] cols) {
        Texture2D m_texture = new Texture2D(64, 64, TextureFormat.ARGB32, false);
        m_texture.name = "";
        for (int index = 0; index < 4096; index++) {
            Point point = DotEditUtils.GetPointFromIndex(index, 64);
            m_texture.SetPixel(point.x, point.y, cols[index]);
        }
        m_texture.Apply();
        SavePngSub(m_texture);
    }

    public Texture2D LoadPng() {
        // ファイルダイアログの表示.
        string filePath = EditorUtility.OpenFilePanel("Load Png", "", "png");

        Texture2D tex = ReadTexture(filePath, 64, 64);
        return tex;
    }

    byte[] ReadPngFile(string path) {
        FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
        BinaryReader bin = new BinaryReader(fileStream);
        byte[] values = bin.ReadBytes((int)bin.BaseStream.Length);

        bin.Close();

        return values;
    }

    Texture2D ReadTexture(string path, int width, int height) {
        byte[] readBinary = ReadPngFile(path);

        Texture2D texture = new Texture2D(width, height);
        texture.LoadImage(readBinary);

        return texture;
    }

    

    void SavePngSub(Texture2D tex) {
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

    /**
    public void SavePng(Color[] cols) {
        Texture2D m_texture = new Texture2D(64, 64, TextureFormat.ARGB32, false);
        m_texture.name = "test";
        for (int index = 0; index < 4096; index++) {
            Point point = DotEditUtils.GetPointFromIndex(index, 64);
            m_texture.SetPixel(point.x, point.y, cols[index]);
        }
        m_texture.Apply();
        SavePngTest(m_texture);
        display(m_texture);
    }**/

    void Make() {
        Texture2D m_texture = new Texture2D(64, 64, TextureFormat.ARGB32, false);
        m_texture.name = "test";
        Color[] cols = new Color[4096];
        for (int i = 0; i < 4096; i++) cols[i] = Color.green;
        for (int i = 0; i < 10; i++) cols[i] = Color.red;

        // m_texture.SetPixels(0, 0, 64, 64, cols);
        // m_texture.Apply();
        //SavePngTest(m_texture);
        SavePng(cols);
        //display(m_texture);
    }
}
