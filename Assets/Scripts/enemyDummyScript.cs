using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDummyScript : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    float m_Speed;

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Speed = 4;
    }

    // Update is called once per frame
    void Update()
    {
        m_Rigidbody.velocity = transform.right * m_Speed;
    }
}
