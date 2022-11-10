using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is the main tile script, most function and varible will be store in here
/// </summary>
public abstract class MainTile : MonoBehaviour
{
    // Start is called before the first frame update
    
    bool canCollide;
    public bool CanCollide { get => canCollide; set => canCollide = value; }

    public virtual void SetDefault()
    {
        canCollide = false;
    }
    void Start()
    {
        SetDefault();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
        }
    }
}
