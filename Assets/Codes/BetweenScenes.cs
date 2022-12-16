using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetweenScenes : MonoBehaviour
{
    private void Awake()
    {
        {
            var noDestruirEntreEscenas = FindObjectsOfType<BetweenScenes>();
            if(noDestruirEntreEscenas.Length > 1)
            {
                Destroy(gameObject);
                return;
            }
            DontDestroyOnLoad(gameObject);
        }
    }
}
