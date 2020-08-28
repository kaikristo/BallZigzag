using System.Collections;
using UnityEngine;

public class Tile : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator animator;

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("GameZone"))
        {
            animator.SetTrigger("Destroy");
            LevelGenerator.instance.GenerateNext();
            StartCoroutine(WaitFallingEnd());
        }


    }
    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        StartCoroutine(WaitSpawn());
    }
    IEnumerator WaitSpawn()
    {
        while (!animator.GetCurrentAnimatorStateInfo(0).IsName("IdleTop"))
        {
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator WaitFallingEnd()
    {
        while (!animator.GetCurrentAnimatorStateInfo(0).IsName("IdleBottom"))
        {
            yield return new WaitForSeconds(0.25f);
        }
        Destroy(this.gameObject);
    }
}
