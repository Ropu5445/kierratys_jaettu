using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItems : MonoBehaviour, IInteractable
{
    [SerializeField] private List<GameObject> itemList = new List<GameObject>();

    public void Interact()
    {
        Destroy();

        int numberOfShirts = Random.Range(2, 6);

        ShuffleList(itemList);

        for (int i = 0; i < numberOfShirts && i < itemList.Count; i++)
        {
            Instantiate(itemList[i], this.gameObject.transform.position, Quaternion.identity);
        }
    }

    private void ShuffleList<T>(List<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}