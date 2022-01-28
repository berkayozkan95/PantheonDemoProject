using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;

public class Paintable : MonoBehaviour
{
    [SerializeField] private Brush brush;
    private bool isActive { get { return isActive;} 
                            set {isActive = value;}}
    public bool IsActive;
    private Texture2D texture;
    private Vector2 mousePos = new Vector2();
    private RectTransform rect;
    private int width;
    private int height;

    private void Start() {
        GameManager.Instance.OnPlayerFinished += OnPlayerFinished;

        //Since the GetPixel and SetPixel functions require a Texture2D object, I used a canvas in world view in order to be able to achive that.
        //These commands did not function as expected when tried with a sprite.
        var rawImage = GetComponent<RawImage>();
        rect = rawImage.GetComponent<RectTransform>();
        width = (int)rect.rect.width;
        height = (int)rect.rect.height;
        texture = rawImage.texture as Texture2D;

        ResetTexture();
    }

    private void ResetTexture(){

        //resetting the texture at every play through since the painted texture is saved afterwards.
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
    }

    //since I am using a "soft" brush, there will be times where while the color might look red it will not be (1,0,0,1) in terms of color.
    //Thus i implemented an empirical solution where the constraints are determined by me. Also checking for just nonwhite pixels work but this
    //method deemed to be more accurate.
    public int GetPercentageRed(){
        Color[] allPixels = texture.GetPixels();
        Color[] nonWhitePixels = allPixels.Where(pixel => pixel.r >= 0.6 && pixel.g < 0.2 && pixel.b < 0.2).ToArray();
        float percentage = (float)nonWhitePixels.Length/(float)allPixels.Length * 100;
        percentage = Mathf.RoundToInt(percentage);
        return (int)percentage;
    }

    //The activation delay is there to wait for the camera transition.
    private void OnPlayerFinished(object sender, GameManager.OnPlayerFinishedEventArgs e){
        Invoke("ActivateBrush", e.activationDelay);
    }

    private void ActivateBrush(){
        IsActive = true;
    }
}
