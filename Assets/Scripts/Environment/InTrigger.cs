using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InTrigger : MonoBehaviour
{
    [SerializeField] private string location;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerWeaponManager player))
        {
            SceneManager.LoadScene(location);
        }
    }
}
