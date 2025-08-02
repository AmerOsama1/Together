using UnityEngine;
using Photon.Pun;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 6f;
    public Transform camera;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    Animator anim;
    public float jumpForce = 10f;
    public LayerMask groundMask;
    public float range = 0.5f;
    bool isGrounded;
    public Transform g;
    public GameObject Part;
    public GameObject walkEffect;
    public float fireRate = 0.5f; 
    public float timeStamp = 0.0f;
    public float Force = 10f;
    public float KickRange = 2f;
    public float doubleJumpForce = 5f;
    PhotonView view;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        anim = GetComponent<Animator>();
        Cursor.visible = false;
        view = GetComponent<PhotonView>();
    }

    void Update()
    {
        if (view.IsMine)
        {
            HandleMovement();
            HandleJump();
            doubleJump();
            if (Input.GetButtonDown("kick") && Time.time > timeStamp)
            {
                timeStamp = Time.time + fireRate;
                Kick();
            }
        }
    }

    void HandleMovement()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        Vector3 dir = new Vector3(x, 0, z).normalized;

        if (dir.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg + camera.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            rb.MovePosition(transform.position + moveDir * speed * Time.deltaTime);

            anim.SetBool("run", true);
            if (Time.time > timeStamp)
            {
                timeStamp = Time.time + fireRate;
                PhotonNetwork.Instantiate(walkEffect.name, g.transform.position, g.transform.rotation);
            }
        }
        else
        {
            anim.SetBool("run", false);
        }
    }

    void HandleJump()
    {
        RaycastHit hit;

        if (Physics.Raycast(g.transform.position, Vector3.down, out hit, range, groundMask))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            PhotonNetwork.Instantiate(Part.name, g.transform.position, g.transform.rotation);
            anim.SetBool("jump", true);
        }
        else
        {
            anim.SetBool("jump", false);
        }
    }

    void doubleJump() {
    if (Input.GetKeyDown(KeyCode.E) && isGrounded) {
        anim.SetBool("double", true);
        rb.AddForce(Vector3.up * doubleJumpForce, ForceMode.Impulse);

        
        rb.AddForce(transform.forward * doubleJumpForce, ForceMode.Impulse);
    }
    else {
                anim.SetBool("double", false);

    }
}
    

    [PunRPC]
    void ApplyKickForce(Vector3 direction, int viewID)
    {
        Rigidbody rb = PhotonView.Find(viewID).GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(direction * Force, ForceMode.Impulse);
        }
    }

    void Kick()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, KickRange);
        foreach (Collider item in colliders)
        {
            if (item.CompareTag("Player"))
            {
                anim.SetTrigger("kick");
                Vector3 direction = (item.transform.position - transform.position).normalized;
                PhotonView targetView = item.GetComponent<PhotonView>();
                if (targetView != null)
                {
                    view.RPC("ApplyKickForce", RpcTarget.All, direction, targetView.ViewID);
                }
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, KickRange);
    }
}
