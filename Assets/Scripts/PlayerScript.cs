using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.EventSystems;

public class PlayerScript : MonoBehaviour
{
    public GameObject bullet;

    public Transform enemyPos;
    public Transform bulletSpawn;

    public LayerMask layer;

    public float distance;
    public float rangeRadius;
    public float raycastLength;
    public float bulletSpeed;

    void Start()
    {
        StartCoroutine(SpawnBullet());
        enemyPos = GameObject.FindGameObjectWithTag("Enemy").transform;
    }

    void Update()
    {
        distance = Vector3.Distance(transform.position, enemyPos.position);
        if (distance <= rangeRadius )
        {
            transform.transform.LookAt(enemyPos);
        }
    }

    private void FixedUpdate()
    {
        //RaycastHit hit;

        //if(Physics.Raycast(transform.position, transform.forward, out hit, raycastLength, layer))
        //{
        //    Debug.Log("Enemy detected");
        //}
        //else
        //{
        //    Debug.Log("No enemy within radius!");
        //}

        
    }

    private void OnMouseDown()
    {
        
    }

    private IEnumerator SpawnBullet()
    {
        WaitForSeconds waitTime = new WaitForSeconds(10);
        while (true)
        {
            GameObject _bullet = Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
            Rigidbody rigidBody = _bullet.GetComponent<Rigidbody>();
            rigidBody.velocity = transform.forward * bulletSpeed;
            yield return waitTime;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, rangeRadius);
    }
}
