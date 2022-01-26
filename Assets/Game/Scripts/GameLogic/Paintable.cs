using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Paintable : MonoBehaviour
{
    [SerializeField] private Brush brush;
    public bool IsActive;
    private Texture2D texture;
    private Vector2 mousePos = new Vector2();
    private RectTransform rect;
    private int width;
    private int height;
    private void Start() {
        var rawImage = GetComponent<RawImage>();
        rect = rawImage.GetComponent<RectTransform>();
        width = (int)rect.rect.width;
        height = (int)rect.rect.height;
        texture = rawImage.texture as Texture2D;

        ResetTexture();
    }

    private void ResetTexture(){
        for (int y = 0; y < texture.height; y++)
        {
            for (int x = 0; x < texture.width; x++)
            {
                texture.SetPixel(x, y, Color.white);
            }
        }
        texture.Apply();
    }

    private void Update() {
        if(!IsActive) return;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rect, Input.mousePosition, Camera.main, out mousePos);
        mousePos.x = (width - (width /2 - mousePos.x)) * texture.width/16;
        mousePos.y = Mathf.Abs((height/2 - mousePos.y) - height) * texture.height/20;
        if(Input.GetMouseButton(0)){     
            brush.Paint((int)mousePos.x, (int)mousePos.y, texture);
        }
        texture.Apply();
        Debug.Log("Painted :" + GetPercentageRed() + "%");
        
    }

    private float GetPercentageRed(){
        Color[] allPixels = texture.GetPixels();
        Color[] nonWhitePixels = allPixels.Where(pixel => pixel != Color.white).ToArray();
        float percentage = (float)nonWhitePixels.Length/(float)allPixels.Length * 100;
        return percentage;
    }
}
