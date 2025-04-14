using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_StartButton : UI_Button
{
 
    protected override void OnClick()
    {
        GameManager.Instance.StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
