using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player_MovementController : MonoBehaviour
{
    [SerializeField] Settings.SO_Settings_Balance settings;
    float speed;
    private void Setup()
    {
        speed = settings.PlayerSpeed;
    }

    Rigidbody2D myRb;
    private void Start()
    {
        myRb = GetComponent<Rigidbody2D>();
        Setup();
    }

    Vector2 _delta;
    Vector2 lookDirection = Vector2.up;

    [SerializeField] Shooting.RingIndicator indicator;

    void Update()
    {
        // Force holder to look at the cursor
        _delta = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        transform.rotation = Quaternion.Euler(0, 0, Vector2.SignedAngle(lookDirection, _delta));

        // Force camera to follow holder
        Camera.main.transform.position = transform.position + Vector3.forward * Camera.main.transform.position.z;

        myRb.velocity = speed * (Input.GetAxis("Horizontal") * Vector2.right + Input.GetAxis("Vertical") * Vector2.up);

        indicator.UpdateVisual();
    }

    // сдвиг трансформа модельки относительно её геометрического центра
    private float centerShift = 0.25f;
    public Vector3 GetCenterPoint ()
    {
        return (transform.position - transform.up * centerShift);
    }

    public void TurnOff()
    {
        this.enabled = false;
    }
}
