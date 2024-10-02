using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class CanvasSaver_scr : MonoBehaviour
{
    public static CanvasSaver_scr instance;

    private void Awake()
    {
        if (instance == null)//makes a singleton of the canvas
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //private void Start()//tried to reassign camera to canvas NOT FUNCTIONAL
    //{
    //    GetComponent<Canvas>().worldCamera = Camera.main;
    //}
}
