using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DestroyCubes : MonoBehaviour
{
    public GameObject cubeTransfer;
    private Sequence sequence;
    private Vector3 point;
    private void Start()
    { 
        sequence = DOTween.Sequence();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cube"))
        {
            sequence.Append(other.transform.DOMove(cubeTransfer.transform.position, 1f, true));
            sequence.Join(other.transform.DORotate(Vector3.forward, 1, RotateMode.Fast));
            sequence.Join(other.transform.DOScale(.1f, 2));
            StartCoroutine(DestroyOther(other.gameObject));
            
        }
    }

    IEnumerator DestroyOther(GameObject other)
    {
        yield return new WaitForSeconds(10);
        Destroy(other.gameObject);
    }
    
}
