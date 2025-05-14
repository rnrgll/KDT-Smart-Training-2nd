using UnityEngine;


public class Goal : MonoBehaviour
{
    [SerializeField] private LayerMask playerLayerMask;
    
    private void OnTriggerEnter(Collider other)
    {
        if (((1 << other.gameObject.layer) & playerLayerMask.value) > 0)
        {
            Debug.Log("골 도착");
            other.GetComponent<PlayerControl>().GameClear();
        }
    }
}
