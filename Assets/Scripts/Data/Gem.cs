using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            GameCtrl.instance.Scores++;
            if (UICtrl.instance != null) UICtrl.instance.ShowScore();
            Destroy(this.gameObject);
        }
    }
}
