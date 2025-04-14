using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class UI_Button : MonoBehaviour
{
    private Button button;
    
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);

    }

    protected abstract void OnClick();
    
    
    
    
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
