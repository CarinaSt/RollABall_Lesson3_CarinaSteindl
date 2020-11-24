using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowingEnemyController : MonoBehaviour
{
    [SerializeField] private GameObject m_playerObject = null;
    [SerializeField] private float m_detectionRadius = 20f;

    private NavMeshAgent m_agent = null;
    private Vector3 m_initialPosition = Vector3.zero;

    protected virtual Vector3 GetNextDestination()
    {
        return m_initialPosition;

    }


    // Start is called before the first frame update
    void Start()
    {
        m_agent = gameObject.GetComponent<NavMeshAgent>();
        m_initialPosition = gameObject.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(a: m_playerObject.transform.position, b: gameObject.transform.position) < m_detectionRadius)
        {        //enemy is chasing player

            m_agent.SetDestination(m_playerObject.transform.position);
        }
    }
}
