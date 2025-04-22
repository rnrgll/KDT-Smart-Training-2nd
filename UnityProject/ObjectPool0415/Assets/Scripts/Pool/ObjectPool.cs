using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;
public class ObjectPool : MonoBehaviour
{
    //총알 프리팹
    [SerializeField] private PoolObject objectPrefab;
    
    //오브젝트 풀
    [FormerlySerializedAs("objectPool")] [SerializeField] private List<PoolObject> pool = new();
    
    //오브젝트 풀 초기 사이즈
    [SerializeField] private int poolSize = 5;

    protected virtual void Awake()
    {
        //풀 초기화
        for (int i = 0; i < poolSize; i++)
        {
            PoolObject instance = Instantiate(objectPrefab);
            instance.gameObject.SetActive(false);
            pool.Add(instance);
            
        }
    }

    public PoolObject GetPoolObject(Vector3 position, Quaternion rotataion)
    {
        //pool에 남아있는 오브젝트가 없으면 오브젝트를 생성해서 반환한다.
        if (pool.Count == 0)
        {
            return Instantiate(objectPrefab, position, rotataion);
        }
        
        
        
        //pool에 있는 오브젝트를 꺼내서 반환한다.
        //가장 마지막 요소로!
        PoolObject instance = pool[pool.Count - 1];
        pool.RemoveAt(pool.Count-1);

        //오브젝트의 return pool을 설정해준다.
        instance.returnPool = this;
        
        //position, rotation 설정 후
        instance.transform.position = position;
        instance.transform.rotation = rotataion;
        
        Debug.Log(instance.name);
        
        
        //활성화 처리한다.
        instance.gameObject.SetActive(true);
        return instance;
    }



    public void ReturnToPool(PoolObject instance)
    {
        //비활성화 처리
        instance.gameObject.SetActive(false);
        //Pool에 다시 넣어주기
        pool.Add(instance);
    }
    
}
