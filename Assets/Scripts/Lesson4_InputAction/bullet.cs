using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject,3f);
    }
    void Update()
    {
        transform.Translate(Vector3.forward * 100 * Time.deltaTime);
    }
}
