using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class MonsterZone : MonoBehaviour
{
    [SerializeField] private MonsterV2 monsterPrefab;
    [SerializeField] private int monsterCount = 5;
    [SerializeField] private Vector3 monsterSpawnAreaSize;
    
    
    
    
    public UnityEvent<Transform> onTankEntered;
    public UnityEvent<Transform> onTankExited;

    private void Awake()
    {
        monsterSpawnAreaSize = transform.localScale;
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < monsterCount; i++)
        {
            MonsterV2 monster = Instantiate(monsterPrefab);
            Vector3 pos = transform.position + RandomPosition(monsterSpawnAreaSize);
            pos.y = monster.transform.position.y;
            Quaternion rot = Quaternion.Euler(0, Random.Range(0f, 360f), 0);
            monster.transform.position = pos;
            monster.transform.rotation = rot;
            
            //이벤트 구독 처리
            onTankEntered.AddListener(monster.StartChase);
            onTankExited.AddListener(monster.EndChanse);
        }
    }
    
    private Vector3 RandomPosition(Vector3 spawnAreaSize)
    {
        return new Vector3(Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2),
            0,
            Random.Range(-spawnAreaSize.z / 2, spawnAreaSize.z / 2));
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<TankControl_Advance>(out TankControl_Advance tank))
        {
            Debug.Log("탱크 enter");
            onTankEntered?.Invoke(tank.transform);
        }
        
       
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<TankControl_Advance>(out TankControl_Advance tank))
        {
            Debug.Log("탱크 exit");
            onTankExited?.Invoke(tank.transform);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
