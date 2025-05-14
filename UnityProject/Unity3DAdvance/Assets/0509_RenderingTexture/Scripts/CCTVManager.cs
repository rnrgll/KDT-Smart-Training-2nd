using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCTVManager : MonoBehaviour
{
    private static CCTVManager _instance;
    public static CCTVManager Instance => GetInstance();
    
    [SerializeField] private GameObject cctvMonitor1;
    [SerializeField] private GameObject cctvMonitor2;
    [SerializeField] private Camera cctvCamera1;
    [SerializeField] private Camera cctvCamera2;
    
    private static CCTVManager GetInstance()
    {
        if (_instance == null)
        {
            CreateInstance();
        }
        return _instance;
    }

    private static void CreateInstance()
    {
        if (_instance == null)
        {
            _instance = FindObjectOfType<CCTVManager>();
            if (_instance == null)
            {
                //싱글톤 인스턴스 생성
                GameObject go = new GameObject("CCTV Manager");
                _instance = go.AddComponent<CCTVManager>(); 

            }
            DontDestroyOnLoad(_instance.gameObject);
        }
    }
    
    private void OnDestroy()
    {
        if (_instance == this)
        {
            _instance = null;
        }
    }

    public void HideAllCCTV()
    {
        cctvMonitor1.SetActive(false);
        cctvMonitor2.SetActive(false);
        cctvCamera1.enabled = false;
        cctvCamera2.enabled = false;
    }

    public void ShowCCTV(int num)
    {
        cctvMonitor1.SetActive(num == 1);
        cctvMonitor2.SetActive(num == 2);
        
        cctvCamera1.enabled = (num == 1);
        cctvCamera2.enabled = (num == 2);
    }
}
