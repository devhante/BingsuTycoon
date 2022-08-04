using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BingsuTycoon.PlayScene
{
    public class CustomerSpawner : MonoBehaviour
    {
        public GameObject[] customerPrefabs;

        private void Awake()
        {
            InstantiateCustomers();
        }

        private void InstantiateCustomers()
        {
            foreach (var item in customerPrefabs)
            {
                Debug.Log(item.name);
                Instantiate(item, transform);
            }
        }

        public void SpawnRandomCustomer()
        {
            transform.GetChild(Random.Range(0, transform.childCount)).gameObject.SetActive(true);
        }
    }
}