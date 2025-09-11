using UnityEngine;

public class AttackRange : MonoBehaviour
{
    private Champion owner;
    private SphereCollider collider;

    private void Awake()
    {
        owner = GetComponentInParent<Champion>();
        collider = GetComponent<SphereCollider>();
        collider.isTrigger = true;
        collider.radius = owner.AttackRange;
    }

    private void OnTriggerEnter(Collider other)
    {
        Champion target = other.GetComponent<Champion>();

        if (target != null && target != owner)
        {
            owner.autoAttackController.AddTarget(target);
        }
    }

    private void OnTiggerExit (Collider other)
    {
        Champion target = other.GetComponent<Champion>();

        if (target != null && target != owner)
        {
            owner.autoAttackController.RemoveTarget(target);
        }
    }

    public void SetRange (float range)
    {
        collider.radius = range;
    }
}
