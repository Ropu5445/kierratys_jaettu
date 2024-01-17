using System.Collections;
using UnityEngine;

public class NewNPC : MonoBehaviour
{
    [SerializeField] public GameObject npc; // Spawnattava npc
    [SerializeField] private Transform npcSpawnTransform; // Sijainti mihin npc spawnataan

    public static int waitTime = 25; // Odotusaika, joka on npc:n spawnauksen välissä

    public void CountDown() // Metodi, joka kutsutaan kun npc:n animaatio loppuu
    {
        StartCoroutine(SpawnNpc());
    }

    public IEnumerator SpawnNpc()
    {
        yield return new WaitForSeconds(waitTime); // Odotetaan "waitTimen ajan
        Instantiate(npc, npcSpawnTransform.position, npcSpawnTransform.rotation); // Spawnataan eli luodaan uusi peliobjekti (npc) annettuun sijaintiin ja kiertoon
        Destroy(gameObject); // Tuhotaan vanha npc
    }
}
 