using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DieFaceSO", menuName = "Scriptable Objects/ZombieDiceGame/DieFaceSO")]
public class DieFaceSO : ScriptableObject
{
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public int Amount { get; private set; }
    [field: SerializeField] public FaceType Type { get; private set; }

    public enum FaceType
    {
        Points,
        Explode,
        Lightning
    }

    public void Execute()
    {
        if (Type == FaceType.Points) DoPoints();
        if (Type == FaceType.Explode) DoExplode();
        if (Type == FaceType.Lightning) DoLightning();
    }

    private void DoPoints()
    {
        Debug.Log($"{Amount} points!");
    }

    private void DoExplode()
    {
        Debug.Log("Explode");
    }

    private void DoLightning()
    {
        Debug.Log("Lightning");
    }
}
