using BingsuTycoon.PlayScene;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BingsuTycoon
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager instance = null;

        public static GameManager Instance
        {
            get
            {
                return instance;
            }
        }

        private void Awake()
        {
            if (instance)
            {
                Destroy(this.gameObject);
                return;
            }

            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

        private void Start()
        {
            GameObject.FindGameObjectWithTag("CustomerSpawner").GetComponent<CustomerSpawner>().SpawnRandomCustomer();
        }
    }

}