using JLib;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameCounter : MonoSingle<FrameCounter>
{
    int frameCount;

    public int FrameCount { get => frameCount; set => frameCount = value; }

    private void Update()
    {
        FrameCount++;
    }
}
