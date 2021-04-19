using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundScroll : MonoBehaviour
{
    private float scroll_Speed = 0.1f;
    private MeshRenderer mesh;
    private float x_Scroll;

    private void Awake() {
        mesh = GetComponent<MeshRenderer>();
    }

    private void Update() {
        if(!PauseMenu.IsPaused){
            //When the pause button is pressed
            Scroll();
        }
        
    }

    private void Scroll()
    {
        //Scroll along the axis with the speed and time
        x_Scroll = Time.time * scroll_Speed;

        Vector2 offset = new Vector2(x_Scroll, 0f);

        mesh.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }
}
