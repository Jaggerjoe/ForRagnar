using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalManager : MonoBehaviour
{
    public float timeBeforeEnemySpawn = 2.0f;
    public float currentTimeBeforeEnemySpawn = 0;
    public int limitEnemySpawn = 5;
    public int limitClassique = 3;
    public int limitShoot = 2;
    
    public int spawnSameTime = 5;
    private int xPos,xPosDist;
    private int zPos,zPosDist;
    public GameObject ennemiClassique;
    public GameObject ennemiShooter;
    public GameObject prefabPlayer;
    public Transform SpawnPlayer;
    CameraTopDown m_CurrentCamera;
    ProgressSceneLoader loader;   
    [SerializeField]
    Health playerLife;
    [SerializeField]
    Deplacement playerWeapon;
    [SerializeField]
    GameObject weapon;
    [SerializeField]
    GameObject pivot;
    [SerializeField]
    int life;
    public int enemyNumber = 0;
    public int ennemyClassique = 0;
    public int ennemyShoot = 0;
    public float m_EnemyDead;
    [SerializeField]
    int ValMin;
    [SerializeField]
    int ValMax;
    public float m_MexEnemy;

    [SerializeField]
    GameObject particlecircle = null;
    float timeBeforeSpawn;

    private void Awake()
    {  
        prefabPlayer = Instantiate(prefabPlayer, SpawnPlayer);
        playerLife = prefabPlayer.GetComponentInChildren<Health>();
        playerWeapon = prefabPlayer.GetComponentInChildren<Deplacement>();
    }

    private void Start()
    {
        m_CurrentCamera = FindObjectOfType<CameraTopDown>();
        m_CurrentCamera.player = prefabPlayer;
        loader = FindObjectOfType<ProgressSceneLoader>();
        loader.DesactiveUI();
        playerLife.health = loader.GetData();
    }
   
    void Update()
    {
        if (m_EnemyDead <= m_MexEnemy)
        {
            if (currentTimeBeforeEnemySpawn < timeBeforeEnemySpawn)
            {
                currentTimeBeforeEnemySpawn += Time.deltaTime;
            }
            else
            {
                currentTimeBeforeEnemySpawn = 0;

                for (int i = 0; i < spawnSameTime; i++)
                {
                    xPos = Random.Range(-ValMin, ValMax);
                    xPosDist = Random.Range(-ValMin, ValMax);
                    zPos = Random.Range(-ValMin, ValMax);
                    zPosDist = Random.Range(-ValMin, ValMax);
                    Vector3 pos = new Vector3(xPos, 1, zPos);
                    Vector3 posDist = new Vector3(xPosDist, 1, zPosDist);
                    StartCoroutine(CreateEnemyCac(pos));
                    StartCoroutine(CreateEnemyDist(posDist));
                }
            }
        }
        else
        {
            if ((m_EnemyDead >= m_MexEnemy) && (enemyNumber == 0))
            {
                Victory();                
            }
        }     

        if(Input.GetKeyDown(KeyCode.M))
        {
            Victory();
        }           
    }

    void Victory()
    {
        //SceneManager.LoadScene("Scene2");
        //Sauvegarde de la vie/Data
        //ICI  
        life = playerLife.health;
        weapon = playerWeapon.weaponEquiped;              
        loader.SaveData(life, weapon);              
        loader.LoadScene("GameScene");       
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Victory();
        }
    }

    public IEnumerator CreateEnemyCac(Vector3 pos)
    {
        if (enemyNumber < limitEnemySpawn)
        { 
            if (ennemyClassique < limitClassique)
            {
                enemyNumber = enemyNumber + 1;
                ennemyClassique = ennemyClassique + 1;
                GameObject particle = Instantiate(particlecircle, pos, Quaternion.identity);               
                yield return new WaitForSeconds(3);
                Destroy(particle);
                GameObject newEnemy = Instantiate(ennemiClassique, pos, Quaternion.identity);               
                //IAclassique newEnemyComp = newEnemy.GetComponent<IAclassique>();                                 
                SoundManager.Instance.Play("SpawnDraugr");
            }           
        }       
    }

    public IEnumerator CreateEnemyDist(Vector3 posDist)
    {
        if (enemyNumber < limitEnemySpawn)
        {
            if (ennemyShoot < limitShoot)
            {
                enemyNumber = enemyNumber + 1;
                ennemyShoot = ennemyShoot + 1;
                GameObject particle = Instantiate(particlecircle, posDist, Quaternion.identity);              
                yield return new WaitForSeconds(3);
                Destroy(particle);
                GameObject newEnemy = Instantiate(ennemiShooter, posDist, Quaternion.identity);              
                //IAclassique newEnemyComp = newEnemy.GetComponent<IAclassique>();                
                SoundManager.Instance.Play("SpawnDraugr");
            }
        }
    }
}

