using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class MakeTexture : MonoBehaviour {
    public int Max = 32;

    // Use this for initialization
    void Start () {
        //Make();
       //LoadPng();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void SavePng(Color[] cols) {
        Texture2D m_texture = new Texture2D(Max, Max, TextureFormat.ARGB32, false);
        m_texture.name = "";
        for (int index = 0; index < Max * Max; index++) {
            Point point = DotEditUtils.GetPointFromIndex(index, Max);
            m_texture.SetPixel(point.y, Max - point.x, cols[index]);
        }
        m_texture.Apply();
        SavePngSub(m_texture);
    }

    public Texture2D LoadPng() {
        // ファイルダイアログの表示.
        string filePath = EditorUtility.OpenFilePanel("Load Png", "", "png");

        Texture2D tex = ReadTexture(filePath, Max, Max);
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
}
