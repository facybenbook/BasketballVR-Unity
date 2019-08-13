using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class ThrowBall : MonoBehaviour
{
    public Boundary bnd;
    public GameObject ball;
    public float power;
    public GameObject ballPoint;
    public float secsToDestroy;

    private GameObject iBall;

    private void Start()
    {
        RespawnBall();
    }

    void RndPos()
    {
        transform.position = new Vector3(Random.Range(bnd.xMin, bnd.xMax), transform.position.y, Random.Range(bnd.zMin, bnd.zMax));
    }

    void RespawnBall()
    {
        RndPos();
        iBall = Instantiate(ball, ballPoint.transform.position, ballPoint.transform.rotation);
        iBall.transform.parent = ballPoint.transform;
    }

    private void Update()
    {
        if (iBall == null) RespawnBall();

        if (Input.GetButtonDown("Fire1") && iBall.transform.parent != null)
        {
            iBall.GetComponent<Rigidbody>().isKinematic = false;
            iBall.transform.parent = null;
            iBall.GetComponent<Rigidbody>().AddForce(ballPoint.transform.forward * power, ForceMode.Acceleration);

            Destroy(iBall, secsToDestroy);
        }
    }
}