using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyDragon_new_mod : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject dragonEggPrefab;
    public float speed = 1f;
    public float timeBetweenEggDrops = 4f;
    public float leftRightDistance = 17f;
    public float chanceDirections = 0.1f;
    void Start()
    {
        Invoke("DropEgg", 2f); // 1

       
    }
    void DropEgg() // 2
    {
        Vector3 myVector = new 
        Vector3(0.0f, 5.0f, 0.0f);
        GameObject egg =
        Instantiate<GameObject>(dragonEggPrefab);
        egg.transform.position = 
        transform.position + myVector;
        Invoke("DropEgg", timeBetweenEggDrops);
        Invoke(nameof(TimeBetweenEggDrops), 5);
        Invoke(nameof(SpeedDragon), 5);
        Invoke(nameof(chanceDirectionsDragon), 5);
    }

    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        if (pos.x < -leftRightDistance) //1
        {
            speed = Mathf.Abs(speed);
        }
        else if (pos.x > leftRightDistance) //2
        {
            speed = -Mathf.Abs(speed);
        }
    }
    private void TimeBetweenEggDrops(){
        if (timeBetweenEggDrops > 1f){
             timeBetweenEggDrops = timeBetweenEggDrops - 0.5f;
        }
        if (timeBetweenEggDrops  <= 1f && timeBetweenEggDrops > 0.6f ){
             timeBetweenEggDrops = timeBetweenEggDrops - 0.05f;
        }
    }
    private void SpeedDragon(){
        if (speed < 15f && speed > 1f){
             speed = speed + 2f;
        }
    }
    private void chanceDirectionsDragon(){
        if (chanceDirections > 0.1f && chanceDirections < 0.5f){
            chanceDirections += 0.1f;
        }
        if (Random.value < chanceDirections)
        {
                speed *= -1;
        }

    }
    private void FixedUpdate()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet")){

           


        }
    }

}
