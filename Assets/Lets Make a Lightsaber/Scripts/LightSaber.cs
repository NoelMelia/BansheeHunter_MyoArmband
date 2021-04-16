using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSaber : MonoBehaviour
{
    LineRenderer lineRenderer;
    public Transform startPos;
    public Transform endPos;
    private float TextureOffset = 0f;
    private bool active = true;
    private Vector3 endPosExtendedPos;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        endPosExtendedPos = endPos.localPosition;
    }
    private void Update()
    {
        //Turn lightsaber on and off
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (active)
            {
                active = false;
            }
            else
            {
                active = true;
            }
        }
        // extend the saber
        if (active)
        {
            endPos.localPosition = Vector3.Lerp(endPos.localPosition, endPosExtendedPos, Time.deltaTime * 5f);
        }
        //hide line
        else
        {
            endPos.localPosition = Vector3.Lerp(endPos.localPosition, startPos.localPosition, Time.deltaTime * 5f);
        }
        //Update Line Positions
        lineRenderer.SetPosition(0, startPos.position);
        lineRenderer.SetPosition(1, endPos.position);

        // Pan Textures
        TextureOffset -= Time.deltaTime * 2f;
        if(TextureOffset < -10)
        {
            TextureOffset += 10f;
        }
        lineRenderer.sharedMaterials[1].SetTextureOffset("_MainTex", new Vector2(TextureOffset, 0f));
    }
}
