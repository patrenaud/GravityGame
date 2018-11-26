using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Le RequireComponent ajoute le component sur l'objet s'il n'y est pas à l'ajout du script.
[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{

    [SerializeField]
    Camera m_Camera;

    private float m_RotateSpeed = 20f;
    private float m_RunSpeed = 20f;
    private float m_RunAcceleration = 4f;
    private float m_JumpForce = 650f;
    public float m_FakeGravity = 40f;

    private bool m_IsVertical = true;
    private bool m_RightGravity = false;
    private bool m_LeftGravity = false;


    // Variables privées de direction
    private float m_CurrentSpeed;
    private float m_InputX = 0f;
    private float m_InputZ = 0f;
    private bool m_IsGrounded = true;

    // Vecteurs
    private Vector3 m_LookRotation = new Vector3();
    private Vector3 m_MoveDir = new Vector3();

    // Components
    private Rigidbody m_Rigidbody;

    public bool m_IsInPlatforms = false;
    public bool m_GravUpEnabled = false;
    public bool m_GravSidesEnabled = false;


    private void Awake()
    {
        // On initialise les variables
        m_Rigidbody = GetComponent<Rigidbody>();
    }


    private void FixedUpdate()
    {
        // Modifier la vélocité
        if(m_LeftGravity)
        {
            m_MoveDir.x = m_Rigidbody.velocity.x;
            if (m_Rigidbody.velocity.x != 0f || !m_IsGrounded)
            {
                m_MoveDir.x -= m_FakeGravity * Time.fixedDeltaTime;
            }
            m_Rigidbody.velocity = m_MoveDir;
        }
        else if(m_RightGravity)
        {
            m_MoveDir.x = m_Rigidbody.velocity.x;
            if (m_Rigidbody.velocity.x != 0f || !m_IsGrounded)
            {
                m_MoveDir.x += m_FakeGravity * Time.fixedDeltaTime;
            }
            m_Rigidbody.velocity = m_MoveDir;
        }
        else
        {
            m_MoveDir.y = m_Rigidbody.velocity.y;
            if (m_Rigidbody.velocity.y != 0f || !m_RightGravity && !m_LeftGravity)
            {
                m_MoveDir.y -= m_FakeGravity * Time.fixedDeltaTime;
            }
            m_Rigidbody.velocity = m_MoveDir;
        }

    }

    private void Update()
    {
        // Valider les Inputs utilisateur
        if (CheckInputAxis())
        {
            // Do stuff
            if (m_CurrentSpeed < m_RunSpeed)
            {
                m_CurrentSpeed += m_RunSpeed * m_RunAcceleration * Time.deltaTime;
            }
            m_MoveDir = transform.forward * m_CurrentSpeed;
        }
        else
        {
            // Do other stuff
            m_MoveDir = Vector3.zero;
            m_CurrentSpeed = 0f;
        }
               

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        if (m_GravSidesEnabled)
        {
            if (Input.GetMouseButtonDown(0))
            {

                if (m_RightGravity)
                {
                    m_RightGravity = false;
                }
                m_LeftGravity = !m_LeftGravity;

            }

            if (Input.GetMouseButtonDown(1))
            {
                if (m_LeftGravity)
                {
                    m_LeftGravity = false;
                }
                m_RightGravity = !m_RightGravity;
            }
        }        


        // switch vertical gravity
        if (Input.GetKeyDown(KeyCode.E) && m_Rigidbody.velocity.y != 0f)
        {
            if (m_GravUpEnabled)
            {
                m_FakeGravity = -m_FakeGravity;
            }
        }

        UpdateRotation();
    }

    private void Jump()
    {
        // Ajoute une force en y au joueur
        if (m_IsGrounded)
        {
            m_IsGrounded = false;
            

            if(m_RightGravity || m_LeftGravity)
            {
                m_Rigidbody.velocity = new Vector3(0f, m_Rigidbody.velocity.y, m_Rigidbody.velocity.z);

                if (m_RightGravity)
                {
                    m_Rigidbody.AddForce(-transform.right * m_JumpForce);
                }
                else if (m_LeftGravity)
                {
                    m_Rigidbody.AddForce(transform.right * m_JumpForce);
                }
            }
            else
            {
                m_Rigidbody.velocity = new Vector3(m_Rigidbody.velocity.x, 0f, m_Rigidbody.velocity.z);

                if (m_FakeGravity > 0)
                {
                    m_Rigidbody.AddForce(transform.up * m_JumpForce);
                }
                else if (m_FakeGravity < 0)
                {
                    m_Rigidbody.AddForce(-transform.up * m_JumpForce);
                }
            }
        }
    }

    private void UpdateRotation()
    {
        // Updater la rotation

        if (m_RightGravity)
        {
            m_LookRotation.y = m_InputX;
            m_LookRotation.z = m_InputZ;
        }
        else if(m_LeftGravity)
        {
            m_LookRotation.y = -m_InputX;
            m_LookRotation.z = m_InputZ;
        }
        else
        {
            m_LookRotation.x = m_InputX;
            m_LookRotation.z = m_InputZ;
        }

        m_LookRotation *= m_RunSpeed; // FailSafe

        if (CheckInputAxis())
        {
            /*if(m_RightGravity)
            {
                //Vector3 Offset = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z-1);
                //Quaternion NewRot = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z - 1, 1 );
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(m_LookRotation, Offset), m_RotateSpeed * Time.deltaTime);
            }
            else if(m_LeftGravity)
            {
                //Vector3 Offset = new Vector3(0, 0, 1);
                //Quaternion NewRot = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z + 1, 1);
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(m_LookRotation, Offset), m_RotateSpeed * Time.deltaTime);
            }
            else*/
            {
                transform.rotation = Quaternion.Lerp((transform.rotation), Quaternion.LookRotation(m_LookRotation), m_RotateSpeed * Time.deltaTime);
            }
        }        
    }


    private bool CheckInputAxis()
    {
        // On vérifi les inputs et on retoure vrai s'il y a un input
        m_InputX = Input.GetAxis("Horizontal");
        m_InputZ = Input.GetAxis("Vertical");
        return m_InputX != 0f || m_InputZ != 0f;
    }

    private void OnTriggerStay(Collider aOther)
    {
        m_IsGrounded = true;
    }

    private void OnTriggerExit(Collider aOther)
    {
        m_IsGrounded = false;
    }
}
