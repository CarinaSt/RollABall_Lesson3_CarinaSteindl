using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Diagnostics;
using TMPro; 

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float m_speed = 1f;
    
    private Rigidbody m_playerRigidbody;

    private float m_movementX;
    private float m_movementY;

    private int m_collectablesTotalCount, m_collectablesCounter;

    private Stopwatch m_stopWatch;

    public TextMeshProUGUI scoreText;

    private void Start()
    {
        m_playerRigidbody = GetComponent<Rigidbody>();

        m_collectablesTotalCount = m_collectablesCounter = GameObject.FindGameObjectsWithTag("Collectable").Length;

        scoreText.text = m_collectablesTotalCount.ToString();

        m_stopWatch = Stopwatch.StartNew();

    }

    private void OnMove(InputValue inputValue)
    {
        Vector2 movementVector = inputValue.Get<Vector2>();

        m_movementX = movementVector.x;
        m_movementY = movementVector.y;
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(m_movementX, 0f, m_movementY);
        
        m_playerRigidbody.AddForce(movement * m_speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectable"))
        {
            other.gameObject.SetActive(false);

            m_collectablesCounter--;
            scoreText.text = m_collectablesCounter.ToString();
            if (m_collectablesCounter == 0)
            {
                UnityEngine.Debug.Log("You Win");

                UnityEngine.Debug.Log($"It took you {m_stopWatch.Elapsed} to find all {m_collectablesTotalCount} collectibles.");
#if UNITY_EDITOR // end game - only in editor
                UnityEditor.EditorApplication.ExitPlaymode();
#endif
            }
            else
            {
                UnityEngine.Debug.Log($"You've already found {m_collectablesTotalCount - m_collectablesCounter} of {m_collectablesTotalCount} collectibles");
            }
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            UnityEngine.Debug.Log("Game Over!");

#if UNITY_EDITOR // end game - only in editor
            UnityEditor.EditorApplication.ExitPlaymode();
#endif
        }

    }
    }