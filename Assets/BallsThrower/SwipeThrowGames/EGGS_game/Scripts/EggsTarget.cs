using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// RASKALOF, v1.0, Script handles target's logic
public class EggsTarget : MonoBehaviour {
    [SerializeField] byte myscore = 1; // Target score in case of hit
    [SerializeField] string egg_tag = "Respawn"; // Set here tag what ball have
    [SerializeField] AudioClip score_sound = null; // Sound to play if ball hit this target
    [SerializeField] GameObject add_score_text_prefab = null; // Add score text effect prefab
    [SerializeField] Transform add_score_text_transform = null; // Position where to appear add score text effect
    [SerializeField] GameObject[] smack_particles = null; // Particle effect (particle bang)
    private Animation animation;

    private void Start()
    {
        animation = GetComponent<Animation>();
    }

    public void ScaleUp()
    {
        transform.localScale  = new Vector3(3.5f, 3.5f, 3.5f);
        animation.enabled = false;
    }
    
    public void ScaleDown()
    {
        //transform.localScale = new Vector3(3f, 3f, 3f);
        animation.enabled = true;
    }


    private void OnTriggerEnter(Collider collision) {
        if(collision.transform.tag == egg_tag) {
            collision.transform.gameObject.GetComponent<Cracker>()?.SetHittedStatus(); // Set what ball hit target during this throw
            GameObject sound = new GameObject("sound"); // Creates new GO
            sound.AddComponent<AudioSource>().PlayOneShot(score_sound); // Play sound
            Destroy(sound, score_sound.length); // Display after play ends
            EggsGameManager.Instance.AddScore(myscore); // Add score
            EggsGameManager.Instance.SpawnTarget(); // Spawn new target

            if (add_score_text_prefab != null)
            {
                GameObject txt = Instantiate(add_score_text_prefab, transform.position, transform.rotation); // Creates add score text effect
                Destroy(txt, txt.GetComponentInChildren<Text>().GetComponent<Animation>().clip.length); // Destroy add score effect GO after animation done playing
                txt.transform.position = add_score_text_transform.position; // Assign position of effect
                txt.GetComponentInChildren<Text>().text = "+" + myscore.ToString(); // Set current hoop score to effect text
                txt.GetComponentInChildren<Text>().enabled = true; // Enable this ad score effect
                txt.GetComponentInChildren<Text>().GetComponent<Animation>().Play(); // Play animation of effect

            }
            //if (smack_particles.Length > 0)
            //{
            //    GameObject Smack = Instantiate(smack_particles[Random.Range(0, smack_particles.Length)], transform.position, collision.transform.rotation); // Instantiate particle effect
            //    Destroy(Smack, 5);
            //}

        }
    }


    public byte GetTargetScore() {
        return myscore;
    }

}
