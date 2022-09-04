using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTag : MonoBehaviour
{
    [SerializeField] string myLaserTag;

    public string GetMyTag() { return myLaserTag; }
}
