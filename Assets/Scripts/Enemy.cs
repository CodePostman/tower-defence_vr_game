using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    private NavMeshAgent navMesh;
    private SpawnManager _spawnManager;
    public GameObject targetBase;
    public int maxHealth = 50;
    public int health = 50;
    public Image healthBar;

    private UI_info uiInfo;

    [Header("Coins")]

    public GameObject destroyedTargetPrefab;


    // Use this for initialization
    void Start ()
    {
        _spawnManager = GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<SpawnManager>();

        healthBar = transform.Find("EnemyCanvas/HealthBG/Health").GetComponent<Image>();

        navMesh = GetComponent<NavMeshAgent>();

        uiInfo = GameObject.FindGameObjectWithTag("UI").GetComponent<UI_info>();
    }

    // Update is called once per frame
    void Update ()
    {
            navMesh.SetDestination(targetBase.transform.position); 

    }

    public bool RandomResult()
    {
        int probability = 3;
        return (Random.Range(0, probability) == 2);
    }

    public void TakeDamage()
    {
        health -= 5;
        healthBar.fillAmount = (float)health / (float)maxHealth;

        if (health <= 0)
        {
            if (RandomResult() == false)
            {
                Transform currentTransform = transform;
                GameObject oneCoin = Instantiate(destroyedTargetPrefab, currentTransform.position + Vector3.up * 40, currentTransform.rotation);
                Destroy(oneCoin, 5.0f);
            }

            Destroy(gameObject);

            _spawnManager.EnemyDefeated();
            uiInfo.killedEnemies++;
        }
    }
}
