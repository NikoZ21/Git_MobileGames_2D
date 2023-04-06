using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Scripts
{
    public class ObjectPool : MonoBehaviour
    {
        [SerializeField] private List<GameObject> pooledObjects;
        [SerializeField] private int amountToPool;
        [SerializeField] private GameObject objectToPool;


        private void Start()
        {
            pooledObjects = new List<GameObject>();
            GameObject tmp;
            for (int i = 0; i < amountToPool; i++)
            {
                tmp = Instantiate(objectToPool);
                tmp.transform.position = transform.position;
                tmp.GetComponent<PipesMovement>().SetStartPosition(transform.position);
                tmp.SetActive(false);
                pooledObjects.Add(tmp);
            }
        }

        public GameObject GetPoolObject()
        {
            for (int i = 0; i < amountToPool; i++)
            {
                if (!pooledObjects[i].activeInHierarchy)
                {
                    return pooledObjects[i];
                }
            }

            return null;
        }
    }
}