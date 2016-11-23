using UnityEngine;
using System.Collections;

public class ThirdPersonCharacter : MonoBehaviour {


    [SerializeField]
    float groundCheckDistance = 0.1f;


    Animator m_animator;
    Rigidbody m_Rigidbody;
    float m_TurnAmount;
    float m_ForwardAmount;
    bool m_Crouching;
    bool m_IsGrounded;
	// Use this for initialization
	void Start () {
	    m_animator = GetComponent<Animator>();
        m_Rigidbody = GetComponent<Rigidbody>();       
	}
	
	// Update is called once per frame
	void Update () {
	    CheckGroundStatus();
	}

    public void Move(Vector3 move, bool crouch, bool jump) {
        
    }

    void UpdateAnimator() {
        
    }

    void CheckGroundStatus() {
        RaycastHit hit;
        #if UNITY_EDITOR
            // helper to visualise the ground check ray in the scene view
//            Debug.DrawLine(transform.position + (Vector3.up * 0.1f), transform.position + (Vector3.up * 0.1f) + (Vector3.down * m_GroundCheckDistance));
        #endif
        if (Physics.Raycast(transform.position + (Vector3.up * 0.1f), Vector3.down, out hit, groundCheckDistance)) {
                m_IsGrounded = true;
        }else {
            m_IsGrounded = false;
        }

    }

    
}
