using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateButtons : MonoBehaviour
{
    public GameObject buttonPrefab;
    public int numberOfButtons = 3;

    void Awake()
    {
        for (int i = 0; i < numberOfButtons; ++i)
        {
            Instantiate(buttonPrefab, transform);
        }
    }
}
