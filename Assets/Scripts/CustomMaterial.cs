using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewCustomMaterial", menuName = "Custom Material")]
public class CustomMaterial : ScriptableObject
{
    public Color[] materialColor;
    public float[] brightness;
    //public Texture2D[] materialTexture;

    public Color SetColor(int prueba)
    {
        switch (prueba)
        {
            case 0:
                return materialColor[0] ;
            case 1:
                return materialColor[1];
            case 2:
                return materialColor[2];
            case 3:
                return materialColor[3];
            case 4:
                return materialColor[4];
            case 5:
                return materialColor[5];
            default:
                return materialColor[6];
        }
    }

}
