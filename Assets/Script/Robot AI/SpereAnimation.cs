using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpereAnimation : MonoBehaviour
{
    public Animation _animation;

    public List<AnimationClip> _Clip;
    

    // Start is called before the first frame update
    void Start()
    {
        //Invoke(nameof(Animation), 1.5f);
    }

    
    public void DownAnimation()
    {
        _animation.clip = _Clip[2];
        _animation.Play();
        Invoke(nameof(OffObj), 1f);
    }

    void OffObj()
    {
        gameObject.SetActive(false);
    }

    public void UpAnimation()
    {
        gameObject.SetActive(true);
        _animation.clip = _Clip[0];
        _animation.Play();
        Invoke(nameof(Animation), 1f);
    }

    public void Animation()
    {
        _animation.clip = _Clip[1];
        _animation.Play();
    }

    
}
