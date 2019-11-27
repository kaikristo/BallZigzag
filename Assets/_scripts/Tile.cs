using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator animator;
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("GameZone"))
        {
            animator = GetComponentInChildren<Animator>();
            animator.SetTrigger("Destroy");
            LevelGenerator.instance.GenerateNext();
            StartCoroutine(WaitAnimationEnd());
        }


    }

    IEnumerator WaitAnimationEnd()
    {
        while (!animator.GetCurrentAnimatorStateInfo(0).IsName("IdleBottom"))
        {
            yield return new WaitForSeconds(0.25f);
        }
        Destroy(this.gameObject);
    }
}
