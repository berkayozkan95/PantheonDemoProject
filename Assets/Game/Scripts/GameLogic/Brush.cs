using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Brush
{
        [SerializeField] private float radius;
        [SerializeField][Range(0,1)] private float hardness;
        public Color color = Color.red;

        public Brush(float radius, float hardness, Color color){
            this.radius = radius;
            this.hardness = hardness;
            this.color = color;
        }

        public void Paint(int x, int y, Texture2D texture){
        for (int i = 0; i < texture.width; i++)
        {
            for (int j = 0; j < texture.height; j++)
            {
                Vector2 pixelLocation = new Vector2(i,j);
                Vector2 centerLocation = new Vector2(x,y);
                if((pixelLocation - centerLocation).magnitude <= radius){ 
                    Color currentColor = texture.GetPixel((int)pixelLocation.x, (int)pixelLocation.y);
                    Vector3 colorLerp = Vector3.Lerp(new Vector3(currentColor.r,currentColor.g,currentColor.b), //lerping between the current pixel color and the wanted color
                         new Vector3(color.r,color.g,color.b) , (1 - Vector2.Distance(pixelLocation,centerLocation)/radius) * hardness); // based on the distance from center 
                    Color softColor = new Color(colorLerp.x, colorLerp.y, colorLerp.z, 1);                                               // to get a softer brush effect. Hardness
                    texture.SetPixel((int)pixelLocation.x, (int)pixelLocation.y, new Color(softColor.r, softColor.g, softColor.b));      // becomes a value to make this color softer
                }                                                                                                                        // but it does so evenly.
            }
        }
    }

}
