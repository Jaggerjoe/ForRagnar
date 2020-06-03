using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Deplacement : MonoBehaviour
{
    PlayerControl controls;
    GameObject player;
    public ParticleSystem particle;
    public ParticleSystem bloodParticle;
    InventorySlotUI loot;
    LevelManager manag;
    public TuToManager tuto;
    ProgressSceneLoader loader;
    //Movement
    public float speed; 
    Vector2 inputDirMove;
    Vector3 moveDir;
    Rigidbody rb;
    bool isMoving;
    private Quaternion m_LastRotate;
    
    //Dash
    bool m_IsDashing = false;
    float timer;
    public float speedDash;
    public float nextDashing;
    float m_TimeBetaweenTwoDash;
    [SerializeField]
    private Slider slider = null;

    //Attack
    Animator anim;
    float m_Damages;
    IAhealth IA;
    public bool attack;

    //particles
    [SerializeField]
    ParticleSystem dashes = null;

    //spell
    public GameObject particles;

    //WeaponChange
    GameObject sword,axe;
    public GameObject arme2;
    public GameObject arme1;
    public GameObject pivot;
    bool isWeapon1 = false;
    bool isWeapon2 = false;
    bool equiped = false;
    public GameObject weaponEquiped;

    #region INPUT
    private void Awake()
    {     
        controls = new PlayerControl();
        controls.Enable();
        controls.Gameplay.Yoyo.performed += ctx => Dash();
        controls.Gameplay.Attack.performed += ctx => MeleAttack();
        controls.Gameplay.Utilitaire1.performed += ctx => UseSlotInventory();
        controls.Gameplay.ChangeWeapon.performed += ctx => SwitchWeapon();
        controls.Gameplay.Menu.performed += ctx => manag.MenuPause();
        controls.Gameplay.Move.performed += ctx => inputDirMove = ctx.ReadValue<Vector2>();
        controls.Gameplay.Move.canceled += ctx => inputDirMove = Vector2.zero;
        GetComponent<Health>().OnDie.AddListener(Die);
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        particle = GetComponentInChildren<ParticleSystem>();
        manag = FindObjectOfType<LevelManager>();
        loader = FindObjectOfType<ProgressSceneLoader>();
    }

    private void Start()
    {
        m_TimeBetaweenTwoDash = nextDashing;
        loot = FindObjectOfType<InventorySlotUI>();
        tuto = FindObjectOfType<TuToManager>();
        if (tuto != null)
        {
            sword = tuto.weapon;
            axe = tuto.axe;            
        }

        if(loader.m_SaveWeapon != null)
        {
            SetWeapon();
        }      
    }

    private void OnEnable()
    {
        if(controls != null)
        {
            controls.Gameplay.Enable();
        }       
    }

    private void OnDisable()
    {
        if (controls != null)
        {
            controls.Gameplay.Disable();
        }            
    }

    #endregion

    #region Dash

    public void Dash()
    {      
        if (m_TimeBetaweenTwoDash >= nextDashing)
        {
            if (!m_IsDashing)
            {
                dashes.gameObject.SetActive(true);
                rb.AddForce(moveDir * speedDash, ForceMode.Impulse);
                m_IsDashing = true;
                m_TimeBetaweenTwoDash = 0;
                slider.value = 0;
                gameObject.layer = 15;                
                SoundManager.Instance.Play("DashPlayer");
            }
        }     
    }

    void ResetDashing()
    {
        if (timer >= 0.4f)
        {
            dashes.gameObject.SetActive(false);
            m_IsDashing = false;
            timer = 0;            
            rb.velocity = Vector3.zero;
            gameObject.layer = 8;                                                               
        }
        else
        {
            timer += Time.deltaTime;
        }
    }  

    #endregion

    #region ATTACK
    
    public void MeleAttack()
    {
        anim.Play("Attack 0", 0, 0.2f);
        attack = true;      
    }

    public void CallEvent()
    {

        attack = false;      
    }
    #endregion

    #region MOVEMENT

    private void Movement()
    {       
        //Vector2 dirInput = Vector2.zero;
        //dirInput.x = Input.GetAxis("Horizontal");
        //dirInput.y = Input.GetAxis("Vertical");
        if (inputDirMove.x != 0.0f || inputDirMove.y != 0.0f)
        {
            moveDir = new Vector3(inputDirMove.x, 0, inputDirMove.y).normalized;
            m_LastRotate = Quaternion.LookRotation(moveDir);
            transform.rotation = m_LastRotate;
            transform.Translate(moveDir * speed * Time.deltaTime, Space.World);
            SoundManager.Instance.Play("DeplacementPlayer");
            isMoving = true;           
        }
        else
        {
            isMoving = false;
        }
    }

    #endregion

    void Update()
    {
        if(isMoving)
        {
            particle.Play();
        }
        else if(!isMoving)
        {
            particle.Stop();
        }
        m_TimeBetaweenTwoDash += Time.deltaTime;
        slider.value = m_TimeBetaweenTwoDash / nextDashing; 
               
        //DeplacementBasique
        if (!m_IsDashing)
        {
            Movement();           
        }

       //Reset Dash
        if (m_IsDashing)
        {
            ResetDashing();
        }
        MenuPause();     
    }

    void Die()
    {
        SceneManager.LoadScene("GameOver");
        Time.timeScale = 0;
    }

    void UseSlotInventory()
    {
        if(loot.contentloot != null)
        {
            GameObject objCreate = loot.contentloot.Use();           
            if (loot.contentloot is Spell)
            {
                Ball bullet = objCreate.GetComponent<Ball>();
                if (bullet != null)
                {
                    //bullet.SetTarget();               
                }
                Ring anneau = objCreate.GetComponent<Ring>();
                if (anneau != null)
                {
                    
                }
                Potion potion = objCreate.GetComponent<Potion>();
                if(potion != null)
                {
                    
                }
                
            }
        }
        //loot.Use();       
    }
    public void BloodParticles()
    {
        bloodParticle.Play();
    }
    public void MenuPause()
    {
        if (manag.ispaused)
        {
            controls.Gameplay.Disable();            
        }
        else if(!manag.ispaused)
        {         
            controls.Gameplay.Enable();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("weapon1"))
        {
            isWeapon1 = true;
            isWeapon2 = false;
        }

        if (other.gameObject.layer == LayerMask.NameToLayer("Weapon2"))
        {
            isWeapon2 = true;
            isWeapon1 = false;          
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("weapon1"))
        {
            isWeapon1 = false;                       
        }

        if(other.gameObject.layer == LayerMask.NameToLayer("Weapon2"))
        {
            isWeapon2 = false;          
        }
    }

    public void SwitchWeapon()
    {
        if (isWeapon1 && !equiped)
        {
            sword.transform.parent = pivot.transform.parent;
            sword.transform.position = pivot.transform.position;
            sword.transform.rotation = pivot.transform.rotation;
            equiped = true;           
            weaponEquiped = arme1;
        }

        if (isWeapon2 && !equiped)
        {
            axe.transform.parent = pivot.transform.parent;
            axe.transform.position = pivot.transform.position;
            axe.transform.rotation = pivot.transform.rotation;
            equiped = true;
            weaponEquiped = arme2;
        }                 
    }

    void SetWeapon()
    {
        Instantiate(loader.m_SaveWeapon, pivot.transform.parent);
        weaponEquiped = loader.m_SaveWeapon;
    }
}
