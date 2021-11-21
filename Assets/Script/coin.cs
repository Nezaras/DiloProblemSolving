using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    private string _circleTag = "Circle";
    private string _gameManagerTag = "manager";
    private GameManager _gameManager;

    private void Start()
    {
        GameObject targetObj = GameObject.FindGameObjectWithTag(_gameManagerTag);
        _gameManager = targetObj.GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag(_circleTag))
        {
            _gameManager.IncreaseScore(1);
            gameObject.SetActive(false);
        }
    }
}
