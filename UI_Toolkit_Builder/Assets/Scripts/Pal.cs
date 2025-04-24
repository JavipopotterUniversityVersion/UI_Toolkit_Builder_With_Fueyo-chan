using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pal : MonoBehaviour
{
    public void SetPal(PalData palData)
    {
        SpriteRenderer shapeRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
        SpriteRenderer faceRenderer = transform.GetChild(1).GetComponent<SpriteRenderer>();

        shapeRenderer.sprite = palData.shape;
        faceRenderer.sprite = palData.face;

        shapeRenderer.color = new Color(Random.value, Random.value, Random.value, 1f);
    }
}
