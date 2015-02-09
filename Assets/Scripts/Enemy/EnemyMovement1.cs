using UnityEngine;
using System.Collections;

public class EnemyMovement1 : MonoBehaviour
{
    Transform player;
	Transform specialEnemy;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    NavMeshAgent nav;
	Vector3 playerPreviousPosition;
	Vector3 enemyTargetPosition;

    void Awake ()
    {
        player = GameObject.FindGameObjectWithTag ("Player").transform;
		specialEnemy = GameObject.FindGameObjectWithTag ("Hellephant").transform;
        playerHealth = player.GetComponent <PlayerHealth> ();
        enemyHealth = GetComponent <EnemyHealth> ();
        nav = GetComponent <NavMeshAgent> ();
		playerPreviousPosition = player.position;
//		nav.SetDestination (player.position);
    }


    void Update ()
    {

//		if ((player.position - nav.updatePosition).sqrMagnitude < Mathf.Pow (nav.stoppingDistance, 2)) {
//		nav.autoBraking = true;
		nav.avoidancePriority = 99;

		 float remainingDistance =   nav.remainingDistance;
		if (remainingDistance == 0f) 
		{
			remainingDistance = 11;		
		}

		remainingDistance = (player.position - specialEnemy.position).magnitude;

//		Vector3 test1 = player.po
		Debug.Log("  Player Position : " + player.position + "nave position: "+transform.position + "hellephant positin: "+specialEnemy.position);
        if(enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
        {
//			
			if ((playerPreviousPosition - player.position).magnitude !=0   && remainingDistance < 15f)  
			{
				if ((specialEnemy.position - enemyTargetPosition).magnitude == 0 )
				{
					enemyTargetPosition =   - (player.position - specialEnemy.position).normalized *5;
					nav.SetDestination(enemyTargetPosition);
				}
				nav.velocity =  - (player.position - specialEnemy.position).normalized *5;
				playerPreviousPosition = player.position;
			}
			else if ((specialEnemy.position - enemyTargetPosition).magnitude != 0 )
			{
				enemyTargetPosition =   - (player.position - specialEnemy.position).normalized *5;
				nav.SetDestination(enemyTargetPosition);
			}
			return;

			
			/*
			if (remainingDistance >= 20f)
			//Mathf.Pow (nav.stoppingDistance, 2)) 
			{

//            	nav.SetDestination (player.position);
//				Debug.Log("  DIStane reach " + nav.stoppingDistance);
				Debug.Log("-----> 1  remainig Distance:" + remainingDistance);
			}
			else if (remainingDistance < 10f)
			{

				Vector3 tt = Vector3.RotateTowards(specialEnemy.position, player.position.normalized, 3.14f, 5f);

//					nav.SetDestination (tt);
//				nav.SetDestination( - (player.position - specialEnemy.position).normalized *5);
//				nav.SetDestination (player.InverseTransformPoint(player.position));
				Debug.Log("-----> 2 remainig Distance" + remainingDistance);
				Debug.Log("  DIStane reach " + nav.remainingDistance + "stop distance: "+nav.stoppingDistance);
			}
			*/
        }
        else
        {
            nav.enabled = false;
        }
    }
}
