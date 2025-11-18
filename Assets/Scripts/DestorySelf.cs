using System.Collections;
using UnityEngine;

public class DestorySelf : MonoBehaviour
{
    [SerializeField] float waitTime = 2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Remove());   
    }
    IEnumerator Remove()
    {
        yield return new WaitForSecondsRealtime(waitTime);
        Destroy(gameObject);
    }
}
