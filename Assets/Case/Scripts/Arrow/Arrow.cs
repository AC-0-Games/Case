using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Case.Throw;
using Case.Health;

public class Arrow : MonoBehaviour, IThrow
{
    public Transform _target;
    private int _attack;



    public void ThrowSettings(Vector3 startingPos, Transform target, int attack, string tag)
    {
        transform.position = startingPos;
        _target = target;
        _attack = attack;
        gameObject.tag = tag;
        StartCoroutine(FollowTarget());
    }

    IEnumerator FollowTarget()
    {

        while(true)
        {
            if (_target != null)
            {
                transform.LookAt(_target.position + Vector3.up);
                transform.Translate(Vector3.forward * Time.deltaTime * 30);
            }
            else
            {
                   Destroy(gameObject);
                break;
            }
            yield return null;
        }
    }
   

    private void OnTriggerEnter(Collider other)
    {
        if(gameObject.CompareTag("Friend") && other.CompareTag("Enemy"))
        {
            other.GetComponent<IHealty>().GetDamage(_attack);

            Destroy(gameObject);
        }
        else if(gameObject.CompareTag("Enemy") && other.CompareTag("Friend"))
        {
            other.GetComponent<IHealty>().GetDamage(_attack);

            Destroy(gameObject);
        }
    }
}
