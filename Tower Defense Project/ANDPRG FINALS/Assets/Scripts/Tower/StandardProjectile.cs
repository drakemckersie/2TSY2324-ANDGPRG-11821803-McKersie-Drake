using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardProjectile : AbstractProjectile
{
    private TrailRenderer trailRenderer;

     void Awake()
    {
        trailRenderer = GetComponent<TrailRenderer>();
        if (trailRenderer == null)
        {
            return;
        }

        trailRenderer.time = 0.5f;
        trailRenderer.startWidth = 0.1f;
        trailRenderer.endWidth = 0.0f;



    }
}
