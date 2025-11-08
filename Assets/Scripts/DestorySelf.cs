using System.Collections;
using UnityEngine;

public class DestorySelf : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Remove());   
    }
    IEnumerator Remove()
    {
        yield return new WaitForSecondsRealtime(1.5f);
        Destroy(gameObject);
    }
}
