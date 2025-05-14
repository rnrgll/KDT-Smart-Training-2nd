using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChattingPresenter : MonoBehaviour
{
    [SerializeField] private ChattingModel model;
    [SerializeField] private ChattingView view;

    private void OnEnable()
    {
        model.OnAddMessage += UpdateChattingView;
    }

    private void OnDisable()
    {
        model.OnAddMessage -= UpdateChattingView;
    }

    public void OnSendMessage(string message)
    {
        if (string.IsNullOrEmpty(message))
        {
            return;
        }
        model.AddMessage(message);
    }

    public void UpdateChattingView(string message)
    {
        view.AddMessageToUI(message);
    }
}
