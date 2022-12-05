using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public static Coin instance { get; private set; }

    public Action trigger;

    private void Awake()
    {
        instance = this;
    }
    public void Collect()
    {
        gameObject.SetActive(false);
        trigger?.Invoke();
    }
}
