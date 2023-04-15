using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Lives : MonoBehaviour
{
    [SerializeField] private float _lives;
    public float _continues;
    [SerializeField] private TextMeshProUGUI _livesText;

    void Start()
    {
        _livesText.text = _continues.ToString();
    }

    void Update()
    {
        _livesText.text = _continues.ToString();
    }


    public void TakeDamage(float _damage)
    {
        _lives -= _damage;

        if(_lives <= 0)
        {
            Destroy(gameObject);

            _continues--;

            if (_continues <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}
