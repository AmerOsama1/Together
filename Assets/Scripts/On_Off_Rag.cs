using UnityEngine;

public class On_Off_Rag : MonoBehaviour
{
   [SerializeField] private Animator animator;
    private Rigidbody[] ragdollRigidbodies;
    private Collider[] cc; // Array to hold all CapsuleColliders
    public Transform newPos;
    public Transform OldPos;

    void Start()
    {
        ragdollRigidbodies = GetComponentsInChildren<Rigidbody>();
        cc = GetComponentsInChildren<Collider>(); // Assign all CapsuleColliders in children

        // Initially disable ragdoll and enable CapsuleColliders
        SetRagdollState(false);
    }

    public void EnableRagdoll()
    {
        SetRagdollState(true);
        
    }

    public void DisableRagdoll()
    {
        SetRagdollState(false);
        if (newPos != null)
        {
        animator.SetTrigger("stand");
            OldPos.position = newPos.position;
        }
    }

    private void SetRagdollState(bool state)
    {
        animator.enabled = !state;

        foreach (Rigidbody rb in ragdollRigidbodies)
        {
            rb.isKinematic = !state;
        }

        foreach (Collider c in cc)
        {
            c.enabled = state; // Enable/disable CapsuleColliders based on ragdoll state
        }
    }
}
