using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reload : MonoBehaviour
{
    [SerializeField] private Canvas _reload;
    [SerializeField] private Slider _slider;

    
    [SerializeField] private float speed = 0.5f;

    public void ActiveUI()
    {
        
        _reload.gameObject.SetActive(true);
    }

    public void DeactiveUI()
    {
        _reload.gameObject.SetActive(false);
        _slider.value = 0f;
    }

    public float GetFill()
    {
        return _slider.value;
    }

    private void Start()
    {
        _slider.value = 0f;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space) && _slider.IsActive())
        {
            _slider.value += speed * Time.deltaTime;
        }
    }
}
