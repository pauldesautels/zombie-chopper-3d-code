using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicopter : MonoBehaviour
{
    [SerializeField] private Transform partToRotate;
    [SerializeField] private float rotationSpeed = 50;
    [SerializeField] private float bounceSpeed = 8;
    [SerializeField] private float bounceAmplitude = 0.05f;

    private float startingHeight;
    private float timeOffset;

    // Start is called before the first frame update
    void Start()
    {
        startingHeight = transform.localPosition.y;
        timeOffset = Random.value * Mathf.PI * 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (bounceSpeed > 0)
        {
            // Bounce
            float finalHeight = startingHeight + Mathf.Sin(Time.time * bounceSpeed + timeOffset) * bounceAmplitude;
            var position = transform.localPosition;
            position.y = finalHeight;
            transform.localPosition = position;
        }

        // Spin
        partToRotate.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }

    //public void SetPosition(Transform target, float jumpDistance)
    //{
    //    Vector3 targetPos = new Vector3(target.position.x, target.position.y + 1, target.position.z + jumpDistance);
    //    transform.position = targetPos;
    //}
}
