using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSFX : MonoBehaviour
{
    private AudioSource audioSourcePlayer;
    private Animator animatorPlayer;
    [SerializeField] private AudioClip[] audiosStep;
    // Start is called before the first frame update
    void Start()
    {
        audioSourcePlayer = GetComponent<AudioSource>();
        animatorPlayer = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (audioSourcePlayer.isPlaying == false && animatorPlayer.GetFloat("Blend") != 0)
        {
            int random = Random.Range(0, audiosStep.Length);
            audioSourcePlayer.PlayOneShot(audiosStep[random]);
        }
    }
}
