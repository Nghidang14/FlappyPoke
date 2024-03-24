using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    GameObject obj;
    GameObject gameController;
    [SerializeField] float flyPower = 200f;

    AudioSource pokeAudioSource;

    Animator anim;
    [SerializeField] AudioClip flyClip;
    [SerializeField] AudioClip gameOverClip;

    // Start is called before the first frame update
    void Start()
    {
        obj = gameObject;
        pokeAudioSource = obj.GetComponent<AudioSource>();
        pokeAudioSource.clip = flyClip;
        anim = obj.GetComponent<Animator>();
        anim.SetBool("isDead", false);

        if (gameController == null)
        {
            gameController = GameObject.FindGameObjectWithTag("GameController");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            if (!gameController.GetComponent<GameController>().isEndGame)
                pokeAudioSource.Play();
            obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, flyPower));
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        EndGame();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        gameController.GetComponent<GameController>().GetScore();
    }

    void EndGame()
    {
        anim.SetBool("isDead", true);
        pokeAudioSource.clip = gameOverClip;
        pokeAudioSource.volume = 0.5f;
        pokeAudioSource.Play();
        gameController.GetComponent<GameController>().EndGame();
    }

}
