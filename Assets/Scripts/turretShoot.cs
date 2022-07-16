using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class turretShoot : MonoBehaviour
{

    public GameObject projectile;
    public float launchVelocity = 50f;
    public bool roundActive = false;
    public float fireRate = 0.5F;
    private float nextFire = 0.0F;
    public Vector3 enemyPos;





    // Start is called before the first frame update
    void Start()
    {
        //enemyPos  = GameObject.Find("enemy").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        
        //var enemy = nearestGameObject.GetComponent<IEnemy>();


        if (roundActive == true && Time.time > nextFire)
        {

            //var enemy = nearestGameObject.GetComponent<IEnemy>();
            //if (enemy == null)
            //{
            //    return;
            //}
            enemyPos = FindClosestEnemy().transform.position;

            GameObject ball = Instantiate(projectile, transform.position, transform.rotation);
            ball.GetComponent<Rigidbody>().AddForce(enemyPos * launchVelocity);
            nextFire = Time.time + fireRate;
        }
    }

    //Transform GetClosestEnemy(Transform[] enemies)
    //{
    //    Transform bestTarget = null;
    //    float closestDistanceSqr = Mathf.Infinity;
    //    Vector3 currentPos = transform.position;
    //    foreach (transform potentialTarget in enemies)
    //    {
    //        Vector3 directionToTarget = potentialTarget.position - currentPosition;
    //        float dSqrToTarget = directionToTarget.sqrMagnitude;
    //        if(dSqrToTarget < closestDistanceSqr)
    //        {
    //            closestDistanceSqr = dSqrToTarget;
    //            bestTarget = potentialTarget;
    //        }
    //    }
    //    return bestTarget;

    //}

    public GameObject FindClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if(enemies.Length == 0)
        {
            return null;
        }
        //GameObject target;
        GameObject closest;
        if(enemies.Length == 1)
        {
            closest = enemies[0];
            //target.transform.position = closest.transform.position;
            return closest;
        }

        closest = enemies.OrderBy(go => (transform.position - go.transform.position).sqrMagnitude).First();
        Debug.Log("targetting" + closest.transform.position);
        //target.transform.position = closest.transform.position;
        return closest;
    }
}
