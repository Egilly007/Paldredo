using UnityEngine;

public class Player : MonoBehaviour
{
    public float MoveSpeed = 5f;

    public Camera PlayerCam;
    public float ZoomSpeed = 5f;
    private Vector3 _zoomTarget;

    void Start()
    {
        if (PlayerCam != null)
            _zoomTarget = PlayerCam.transform.localPosition;
        else
            _zoomTarget = new Vector3(0, 20, 2);
    }

    void Update()
    {
        move();
        Interact();
        ZoomMap();
    }

    void move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * MoveSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * MoveSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * MoveSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * MoveSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            MoveSpeed = 10f;
        }
        else
        {
            MoveSpeed = 5f;
        }
    }

    void Interact()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Interaction logic here
        }
    }

    void ZoomMap()
    {
        if (PlayerCam == null) return;

        if (Input.GetKeyDown(KeyCode.Z))
        {
            _zoomTarget = new Vector3(0, 77, 0);
        }
        if (Input.GetKeyUp(KeyCode.Z))
        {
            _zoomTarget = new Vector3(0, 20, 0);
        }

        PlayerCam.transform.localPosition = Vector3.Lerp(PlayerCam.transform.localPosition, _zoomTarget, Time.deltaTime * ZoomSpeed);
    }
}
