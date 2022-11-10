using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plat : MainTile
{
    private PlatformEffector2D Effector;
    public override void SetDefault()
    {
        Effector = GetComponent<PlatformEffector2D>();
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Effector.rotationalOffset = 180;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        Effector.rotationalOffset = 0;
    }
}
