﻿using UnityEngine;
using System.Collections;

public class FlashingObjects3 : MonoBehaviour
{

    private Material _mat;
    private Color[] _colors = { Color.gray, Color.red };
    private float _flashSpeed = 0.1f;
    private float _lengthOfTimeToFlash = 0.2f;
    [SerializeField] GameObject duckmesh;
    private Color originalcolor;

    public void Awake()
    {

        _mat = duckmesh.GetComponent<MeshRenderer>().material;
        originalcolor = new Color(0.37f, 0.32f, 0.3f);

    }
    // Use this for initialization
    void Start()
    {
        //StartCoroutine(Flash(this._lengthOfTimeToFlash, this._flashSpeed));
    }

    IEnumerator Flash(float time, float intervalTime)
    {
        float elapsedTime = 0f;
        int index = 0;
        while (elapsedTime < time)
        {
            _mat.color = _colors[index % 2];

            elapsedTime += Time.deltaTime;
            index++;
            yield return new WaitForSeconds(intervalTime);
        }

        if (elapsedTime >= time)
        {
            _mat.color = originalcolor;
        }
    }
}
