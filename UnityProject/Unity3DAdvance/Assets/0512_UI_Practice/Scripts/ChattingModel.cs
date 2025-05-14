using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChattingModel : MonoBehaviour
{
    [SerializeField] private List<string> chattingMssages = new List<string>();
    public event Action<string> OnAddMessage; //변수명을 어떻게 해야할지 모르겠음

    public void AddMessage(string message)
    {
        chattingMssages.Add(message);
        OnAddMessage?.Invoke(message);
    }

    public List<string> GetMeesages()
    {
        return chattingMssages;
    }
    
}
