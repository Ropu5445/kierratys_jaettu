using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Car : MonoBehaviour
{
    private float waitTime;
    private int randNum;

    [SerializeField] private GameObject rightLineVan, leftLineVan, rightLineCar1, leftLineCar1, rightLineCar2, leftLineCar2;
    [SerializeField] private Transform rightLineTransformVan, leftLineTransformVan, rightLineTransformCar1, leftLineTransformCar1;
    
    private void Start()
    {
        StartCoroutine(SpawnRightCar());
        StartCoroutine(SpawnLeftCar());
    }

    public void SpawnMoreCars()
    {
        StartCoroutine(SpawnRightCar());
        StartCoroutine(SpawnLeftCar());
    }

    IEnumerator SpawnRightCar()
    {
        waitTime = Random.Range(5f, 12f);
        randNum = Random.Range(0, 4);
        yield return new WaitForSeconds(waitTime);
        if (randNum == 1)
        {
            Instantiate(rightLineVan, rightLineTransformVan.position, rightLineTransformVan.rotation);
        }
        else if (randNum == 2)
        {
            Instantiate(rightLineCar1, rightLineTransformCar1.position, rightLineTransformCar1.rotation);
        }
        else if (randNum == 3)
        {
            Instantiate(rightLineCar2, rightLineTransformCar1.position, rightLineTransformCar1.rotation);
        }
        SpawnMoreCars();
    }

    IEnumerator SpawnLeftCar()
    {
        waitTime = Random.Range(5f, 25f);
        randNum = Random.Range(0, 4);
        yield return new WaitForSeconds(waitTime);
        if (randNum == 1)
        {
            Instantiate(leftLineVan, leftLineTransformVan.position, leftLineTransformVan.rotation);
        }
        else if (randNum == 2)
        {
            Instantiate(leftLineCar1, leftLineTransformCar1.position, leftLineTransformCar1.rotation);
        }
        else if (randNum == 3)
        {
            Instantiate(leftLineCar2, leftLineTransformCar1.position, leftLineTransformCar1.rotation);
        }
    }
}
