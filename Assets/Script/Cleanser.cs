using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleanser : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> prefabs;

    [SerializeField]
    private GameObject prefabSpawn;

    private int waitTime = 5; // Lisää tai vähennä aikaa ennen kuin pipo puhdistuu

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("Ticks"))
        {
            StartProcessing();
            Debug.Log("Prosessointi aloitettu");
        }
    }

    public void StartProcessing()
    {
        StartCoroutine(Process());
    }

    public IEnumerator Process()
    {
        yield return new WaitForSeconds(waitTime);
        Debug.Log("Aikaa kulunut: " + waitTime);
        if (prefabs.Count > 0) // Tarkistetaan onko listassa prefabeja
        {
            // Random prefabi listasta
            int randomIndex = Random.Range(0, prefabs.Count);
            GameObject selectedPrefab = prefabs[randomIndex];

            // Spawnataan random prefab siihen höyrystimen päähän
            Instantiate(selectedPrefab, prefabSpawn.transform.position, prefabSpawn.transform.rotation);
        }
    }
}
