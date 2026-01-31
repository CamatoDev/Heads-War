using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalEnemyAI : MonoBehaviour
{
    // Variables de la cible 
    public Transform target;
    //Rayon de l'explosion
    public float explosionRadius = 2.0f;

    // Variables pour le déplacement
    [Header("Enemy mouvement")]
    public float moveSpeed = 5.0f;
    public float distanceMax = 40.0f;
    public float orbitDistance = 5.0f; // Distance à laquelle le drone orbite autour du joueur
    public float orbitSpeed = 3.0f; // Vitesse à laquelle le drone orbite autour du joueur
    public float heightVariationSpeed = 1.0f; // Vitesse de variation de la hauteur
    public float heightVariationRange = 3.0f; // Amplitude de la variation de hauteur
    //Distance entre le joueur et l'ennemi
    private float distance;

    // Variable pour l'attaque
    [Header("Enremy Attack")]
    public float timeBetweenAttack = 8f;
    public float chaseRange = 10.0f;
    public float attackRange = 1.0f;
    bool onAttack = false;

    [Header("Enemy Stats")]
    public float coin = 250f;
    //Pour la vie de l'ennemi 
    public float startHealth = 300f;
    private float health;

    [Header("Clone Option")]
    // Variables pour le dédoublement
    public float cloneCooldown = 1.0f; // Temps entre chaque dédoublement
    private float cloneTimer = 0.0f;
    public GameObject dronePrefab; // Préfabriqué du drone à cloner
    public float cloneSpawnDistance = 5.0f; // Distance minimale entre le clone et l'objet de référence
    public int maxDrones = 2; // Nombre maximum de drones autorisés

    [Header("Song")]
    // Variable pour le son
    public AudioSource audioSource;
    public AudioClip enemyDie;
    public AudioClip enemySpawn;

    // Variables pour la variation de hauteur
    private float baseHeight;
    private float targetHeight;
    private float heightTimer;

    // Liste statique pour garder une trace de tous les drones
    private static List<FinalEnemyAI> allFinalDrones = new List<FinalEnemyAI>();

    // Start is called before the first frame update
    void Start()
    {
        // Assignation des variables de lancement
        target = GameObject.FindGameObjectWithTag("Player").transform;
        health = startHealth;
        cloneTimer = cloneCooldown; // Initialisation du timer de dédoublement

        // Initialisation de la hauteur de base
        baseHeight = transform.position.y;
        targetHeight = baseHeight;
        heightTimer = 0.0f;

        // Ajouter ce drone à la liste des drones
        allFinalDrones.Add(this);
    }

    // Update is called once per frame
    void Update()
    {
        // Teste si la cible existe 
        if (target == null) return;

        distance = Vector3.Distance(transform.position, target.position);

        // Si le drone est trop loin, il revient vers le joueur
        if (distance > distanceMax)
        {
            ReturnToPlayer();
        }
        else
        {
            // On orbite autour du joueur
            OrbitPlayer();
            VaryHeight(); // Variation de la hauteur
        }

        // Si le drone est à la bonne distance, il tourne autour du joueur 
        if (distance <= distanceMax)
        {
            RotateAroundPlayer();
            VaryHeight(); // Variation de la hauteur
        }

        // Gestion du dédoublement
        cloneTimer -= Time.deltaTime;
        if (cloneTimer <= 0)
        {
            if (allFinalDrones.Count < maxDrones)
            {
                CloneDrone();
            }
            // Ajuster dynamiquement le cooldown en fonction du nombre de drones
            cloneTimer = cloneCooldown * (1 + (allFinalDrones.Count / (float)maxDrones));
        }

        //Gestion de l'attaque
        //timeBetweenAttack -= Time.deltaTime;
        //if (timeBetweenAttack <= 0)
        //{
        //    onAttack = true;
        //    float direction = Vector3.Distance(target.position, transform.position);

        //    if (direction >= attackRange)
        //    {
        //        // Aller vers le joueur
        //        transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        //    }
        //    Explosion();
        //}
    }

    // Fonction pour orbiter autour du joueur
    public void OrbitPlayer()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Vector3 orbitPosition = target.position + (transform.position - target.position).normalized * orbitDistance;

        // Maintenir la distance orbitale
        transform.position = Vector3.MoveTowards(transform.position, orbitPosition, moveSpeed * Time.deltaTime);
    }

    // Fonction pour la rotation ciculaire autour du joueur 
    public void RotateAroundPlayer()
    {
        // Mouvement circulaire autour du joueur
        transform.RotateAround(target.position, Vector3.up, orbitSpeed * Time.deltaTime);
    }

    // Fonction pour revenir vers le joueur si trop loin
    public void ReturnToPlayer()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        transform.position = Vector3.MoveTowards(transform.position, target.position + direction * orbitDistance, moveSpeed * Time.deltaTime);
    }

    // Fonction pour varier la hauteur
    public void VaryHeight()
    {
        heightTimer += Time.deltaTime * heightVariationSpeed;

        // Changer la hauteur cible de manière aléatoire
        if (heightTimer >= 1.0f)
        {
            targetHeight = baseHeight + Random.Range(-heightVariationRange, heightVariationRange);
            heightTimer = 0.0f;
        }

        // Interpolation vers la nouvelle hauteur
        float newY = Mathf.Lerp(transform.position.y, targetHeight, Time.deltaTime * heightVariationSpeed);
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }

    // Fonction pour l'attaque explosive
    public void Explosion()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Player"))
            {
                // Infliger des dégâts au joueur
                hitCollider.GetComponent<PlayerActions>().TakeDamage(50); // Exemple de dégâts
            }
        }
        // Détruire le drone après l'explosion
        Dead();
    }

    public void Damage(float damage)
    {
        health -= damage;
        audioSource.PlayOneShot(enemyDie);

        if (health <= 0)
        {
            Dead();
        }
    }

    public void Dead()
    {
        target.gameObject.GetComponent<PlayerStats>().points += coin;
        // Retirer ce drone de la liste des drones
        allFinalDrones.Remove(this);
        // Rajouter une animation d'explosion 

        audioSource.PlayOneShot(enemyDie);
        Destroy(gameObject, 0.5f);
    }

    // Fonction pour cloner le drone
    public void CloneDrone()
    {
        if (dronePrefab != null)
        {
            // Calculer une position aléatoire à une distance suffisante
            Vector3 spawnPosition;
            do
            {
                spawnPosition = transform.position + new Vector3(Random.Range(-cloneSpawnDistance, cloneSpawnDistance), 0, Random.Range(-cloneSpawnDistance, cloneSpawnDistance));
            } while (Vector3.Distance(spawnPosition, transform.position) < cloneSpawnDistance);

            // Instancier le clone
            Instantiate(dronePrefab, spawnPosition, Quaternion.identity);
        }
    }

    // Fonction pour nettoyer la liste des drones (au cas où)
    private void OnDestroy()
    {
        allFinalDrones.Remove(this);
    }
}
