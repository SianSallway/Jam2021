using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaiderShooting : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject spawnPoint;
    public Vector3 direction;
    float rotationAngle;
    public float bulletSpeed;
    RaycastHit2D leftHit;
    RaycastHit2D rightHit;
    public bool leftOfPlayer;
    public bool rightOfPlayer;


    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").gameObject;


    }

    // Update is called once per frame 
    void Update()
    {
        //direction = (target.transform.position - transform.position).normalized;
        //rotationAngle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        //transform.eulerAngles = new Vector3(0, 0, -rotationAngle);

        //Invoke("Shoot", 5);

        if(Input.GetKey(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject newBullet = Instantiate(bullet, spawnPoint.transform.position, Quaternion.identity);
        newBullet.GetComponent<Rigidbody2D>().AddForce(direction * bulletSpeed);
    }
}
