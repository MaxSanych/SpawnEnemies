using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Update()
    {
            transform.Translate(_speed * Time.deltaTime * -1, 0, 0);
    }
}
