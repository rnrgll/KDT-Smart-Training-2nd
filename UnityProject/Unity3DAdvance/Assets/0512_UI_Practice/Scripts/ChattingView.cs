using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChattingView : MonoBehaviour
{
    [SerializeField] private ChattingPresenter presenter;
    
    //input을 받아서 presenter에게 전달한다
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private Transform chatContent;
    
    [SerializeField] private TMP_Text chatMessagePrefab;

    private void Start()
    {
        inputField.onSubmit.AddListener(OnSubmit);
    }

    //inputfield 제출시
    public void OnSubmit(string message)
    {
        presenter.OnSendMessage(message);
        inputField.text = "";
        
        //엔터 이후에도 바로 inputfield 입력가능하도록
        inputField.Select(); //재선택
        inputField.ActivateInputField(); //포커스 활성화 
    }
    
    // 메시지 UI 업데이트 (Prefab 생성 방식)
    public void AddMessageToUI(string message)
    {
        TMP_Text newMessage = Instantiate(chatMessagePrefab, chatContent);
        TMP_Text messageText = newMessage.GetComponent<TMP_Text>();
        messageText.text = message;
        newMessage.transform.SetAsLastSibling();
    }
}
