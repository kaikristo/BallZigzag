using System.Collections;
using UnityEngine;

public class Tile : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator animator;
    private bool canHaveGem;

    public bool CanHaveGem { get => canHaveGem; set => canHaveGem = value; }

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
        StartCoroutine(WaitSpawnEnd());
    }
    IEnumerator WaitSpawnEnd()
    {
        while (!animator.GetCurrentAnimatorStateInfo(0).IsName("IdleTop"))
        {
            yield return new WaitForSeconds(0.1f);
        }

       if(CanHaveGem) GemSpawner.instance.TryToSpawn(this.transform);
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
