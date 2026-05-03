using UnityEngine;
using UnityEngine.InputSystem;
public class Bola : MonoBehaviour
{
    InputAction RightRotation;
    InputAction leftRotation;
    InputAction space;
    float force = 10f;
    Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        leftRotation = new InputAction("LeftRightRotation", binding: "<Keyboard>/a");
        RightRotation = new InputAction("LeftRightRotation", binding: "<Keyboard>/d");
        RightRotation.Enable();
        leftRotation.Enable();
        space = new InputAction("Space", binding: "<Keyboard>/space");
        space.Enable();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<Transform>().position.y < -10)
        {
            GetComponent<Transform>().position = new Vector3(0, 0.65f, -6.32f);
            rb.linearVelocity = Vector3.zero;
            foreach(Transform child in transform)
            {
                child.gameObject.SetActive(true);
            }
        }
    }
    void FixedUpdate()
    {
        Vector3 ballLooking = GetComponent<Transform>().forward;
        if (space.ReadValue<float>() != 0)
        {
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(false);
            }
            rb.AddForce(ballLooking * force, ForceMode.Impulse);
        }
        if (RightRotation.ReadValue<float>() != 0)
        {
            GetComponent<Transform>().Rotate(0, 1, 0);
        }
        if (leftRotation.ReadValue<float>() != 0)
        {
            GetComponent<Transform>().Rotate(0, -1, 0);
        }
    }
}
