using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelect : MonoBehaviour
{
    private int index;

    public void Increment(int amount)
    {
        index += amount;
        if (index < 0) index = transform.childCount - 1;
        if (index > transform.childCount - 1) index = 0;
        UpdateActiveStates();
    }

    private void UpdateActiveStates()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(index == i);
        }
    }
}
