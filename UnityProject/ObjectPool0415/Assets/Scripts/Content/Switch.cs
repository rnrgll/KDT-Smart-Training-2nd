using System;
using UnityEngine;
public class Switch : MonoBehaviour
{
    [SerializeField] private DamageAdapter _damageAdapter;
    [SerializeField] private GameObject door;
    private bool IsDoorOpen => door.activeSelf == false;
    
    
    public void SwitchDoor()
    {
        if (IsDoorOpen) Close();
        else Open();
    }

    private void Open()
    {
        door.SetActive(false);
    }

    private void Close()
    {
        door.SetActive(true);
    }
    
}
