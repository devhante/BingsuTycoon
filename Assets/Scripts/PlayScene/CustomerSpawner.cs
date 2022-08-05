using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BingsuTycoon.PlayScene
{
    public class CustomerSpawner : MonoBehaviour
    {
        public GameObject[] customerPrefabs;

        private int index = -1;

        private void Awake()
        {
            InstantiateCustomers();
        }

        private void InstantiateCustomers()
        {
            foreach (var item in customerPrefabs)
            {
                Instantiate(item, transform);
            }
        }

        public void SpawnRandomCustomer(float idle)
        {
            StartCoroutine(SpawnRandomCustomerCoroutine(idle));
        }

        private IEnumerator SpawnRandomCustomerCoroutine(float idle)
        {
            int randomIndex;
            yield return new WaitForSeconds(idle);

            while (true)
            {
                randomIndex = Random.Range(0, transform.childCount);
                if (randomIndex != index) break;
            }

            transform.GetChild(randomIndex).gameObject.SetActive(true);
            index = randomIndex;
        }
    }
}