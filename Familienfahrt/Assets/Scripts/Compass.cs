using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Compass : MonoBehaviour
{
    public RawImage compass;
    public Transform player;
    
    void FixedUpdate()
    {
        compass.uvRect = new Rect((player.localEulerAngles.y+180f) / 360f + 0f, 0f, .5f, 1f);
    }
}
