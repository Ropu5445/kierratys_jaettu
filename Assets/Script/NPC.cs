using System.Collections;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] private GameObject npc;
    [SerializeField] private Transform npcSpawnTransform;
    
    public void Start()
    {
        StartCoroutine(SpawnNpc());
    }

    public IEnumerator SpawnNpc()
    {
        yield return null;
        Instantiate(npc, npcSpawnTransform.position, npcSpawnTransform.rotation);
    }
}
