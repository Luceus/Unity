using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnQuestionScript : MonoBehaviour
{
    public GameObject content;
    public GameObject AnserTextPrefab;
    public static int ItemLocation;

    void Start()
    {
        SpawnPrefabs();
    }

    void SpawnPrefabs()
    {
        for (int i = 0; i < GetQnA_Script.ShowAnswerQuestionList.Count; i++)
        {
            ItemLocation = i;
            Instantiate(AnserTextPrefab, content.transform);
        }
    }
}
