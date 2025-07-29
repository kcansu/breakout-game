using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Block", menuName ="Block")]
public class Block : ScriptableObject
{

    public int health;
    public int scoreValue;
    public GameObject prefab;

}
