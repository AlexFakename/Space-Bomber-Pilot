using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser1 : MonoBehaviour
{
    [SerializeField] string myLaserTag = "Laser1";
    [SerializeField] int damage = 100;
    GameObject myParent;
    [SerializeField] float projectileSpeed = 10f;
    const string LASER1_PARENT = "Laser 1 Parent";

    private void Start()
    {
        myParent = GameObject.Find(LASER1_PARENT);
        if(!myParent) { myParent = new GameObject(LASER1_PARENT); }
        transform.parent = myParent.transform;
    }

    private void Update()
    {
        transform.Translate(Vector2.down * projectileSpeed * Time.deltaTime);
    }

    public int DealDamage()
    {
        Destroy(gameObject);
        return damage;
    }
}
