using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalController : MonoBehaviour
{
    public GameObject BloomPanel;
    private void OnTriggerEnter(Collider other)
    { 
        StartCoroutine(EnterPortal());
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator EnterPortal()
    {
            BloomPanel.GetComponentInChildren<Animator>().SetBool("LevelEnd", true);
            yield return new WaitForSeconds(1);
            BloomPanel.GetComponentInChildren<Animator>().SetBool("LevelEnd", false);

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
