using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : MonoBehaviour
{
    [SerializeField] GameObject xProjectile;
    private GameObject Prefab;
    Vector3 vecPos;
    Vector3 directionPos;

    [SerializeField] private GameObject bullet;

    void Start()
    {
        InvokeRepeating("XProjectileFunction", 2, 4);
        InvokeRepeating("bulletFunction", 3, 4);
    }
    void XProjectileFunction()
    {
    
        for (int i = 0; i < 4; i++)
        {
            switch (i)
            {
                case 0:
                    vecPos = new Vector3(transform.position.x, transform.position.y - 1.5f, transform.position.z - 2.5f);
                    directionPos = Vector3.back;
                    break;
                case 1:
                    vecPos = new Vector3(transform.position.x, transform.position.y - 1.5f, transform.position.z + 2.5f);
                    directionPos = Vector3.forward;
                    break;
                case 2:
                    vecPos = new Vector3(transform.position.x - 2.5f, transform.position.y - 1.5f, transform.position.z);
                    directionPos = Vector3.left;
                    break;
                case 3:
                    vecPos = new Vector3(transform.position.x + 2.5f, transform.position.y - 1.5f, transform.position.z);
                    directionPos = Vector3.right;
                    break;
                default:
                    break;
            }

            Prefab = Instantiate(xProjectile, vecPos, xProjectile.transform.rotation);
            Prefab.GetComponent<Rigidbody>().velocity=directionPos*5;

            Destroy(Prefab, 5);
        }
    }

    void bulletFunction()
    {
        vecPos = new Vector3(transform.position.x, transform.position.y + 3, transform.position.z);
        directionPos = GameObject.Find("Player").transform.position;

        Prefab = Instantiate(bullet, vecPos, Prefab.transform.rotation);
        Prefab.GetComponent<Rigidbody>().velocity = (directionPos-Prefab.transform.position);

        Destroy(Prefab, 5);
    }
}
