using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBag : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject bag;
    [SerializeField] private List<GameObject> bags = new List<GameObject>();
    [SerializeField] private Transform itemSpawnTransform;

    [SerializeField] private Animator animator;

    [SerializeField] private string animationName;

    private int num;

    private void Start()
    {
        num = 0;
    }

    public void Ready()
    {
        num = 1;
    }

    public void Interact()
    {
        if (num == 1)
        {
            int randNum = Random.Range(0, 4);
            int randBag = Random.Range(0, 4);
            bag = bags[randBag];
            Debug.Log("Randomoitu: " + randBag);
            if (randNum == 1)
            {
                Instantiate(bag, itemSpawnTransform.position, Quaternion.identity);
                num++;
                animator.Play(animationName);
            }
            else if (randNum == 2)
            {
                for (int i = 0; i < randNum;)
                {
                    Instantiate(bag, itemSpawnTransform.position, Quaternion.identity);
                    i++;
                }
                Instantiate(bag, itemSpawnTransform.position, Quaternion.identity);
                num++;
                animator.Play(animationName);
            }
            else if (randNum == 3)
            {
                for (int i = 0; i < randNum;)
                {
                    Instantiate(bag, itemSpawnTransform.position, Quaternion.identity);
                    i++;
                }
                num++;
                animator.Play(animationName);
            }

        }
    }



    public void Destroy()
    {
        Destroy(gameObject);
    }
}
