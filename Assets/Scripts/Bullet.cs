using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    public float speed = 30f;
    public bool slow;
    public int dmg;
    public float explosionRadius = 0f;
    public GameObject impactEffect;

    public void Seek (Transform _target)
    {
        target = _target;
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);
    }

    void HitTarget()
    {
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 1f);

        if (explosionRadius > 0f)
        {
            Explode();
        } else
        {
            Damage(target);
        }

        //Destroy(target.gameObject);
        Destroy(gameObject);
    }

    void Explode ()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Cow")
            {
                Damage(collider.transform);
            }
        }
    }

    void Damage (Transform enemy)
    {


        Transform objABorrar = enemy.parent;

        if (!enemy.parent || !enemy.parent.gameObject.GetComponent<Vacas>())
            objABorrar = enemy;
        
        if(objABorrar.gameObject.GetComponent<Vacas>().normal)
            objABorrar.gameObject.GetComponent<Vacas>().DarLeche(objABorrar.gameObject.GetComponent<Vacas>().normalleche);
        else if(objABorrar.gameObject.GetComponent<Vacas>().tanque)
            objABorrar.gameObject.GetComponent<Vacas>().DarLeche(objABorrar.gameObject.GetComponent<Vacas>().tanqueleche);
        else if (objABorrar.gameObject.GetComponent<Vacas>().rapida)
            objABorrar.gameObject.GetComponent<Vacas>().DarLeche(objABorrar.gameObject.GetComponent<Vacas>().rapidaleche);
        else if (objABorrar.gameObject.GetComponent<Vacas>().boss)
            objABorrar.gameObject.GetComponent<Vacas>().DarLeche(objABorrar.gameObject.GetComponent<Vacas>().bossleche);

        //Destroy(objABorrar.gameObject);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
