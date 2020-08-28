using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    [SerializeField]
    GameObject front, back, left, right;

    public GameObject Front { get => front;}
    public GameObject Back { get => back;}
    public GameObject Left { get => left;}
    public GameObject Right { get => right;}
}
