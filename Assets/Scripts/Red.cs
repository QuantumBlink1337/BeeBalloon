using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Red : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene("SampleScene");
        //in case we change things around.. but right now red can ONLY detect collisions with the player.
        /*if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            //Reset level
            
        }*/
    }
}
