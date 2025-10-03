using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSphere : MonoBehaviour
{
    public Animation _animation;

    public List<AnimationClip> _Clip;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void DownAnimation()
    {
        _animation.clip = _Clip[1];
        _animation.Play();

        Invoke(nameof(OffObject), 1f);
    }

    void OffObject()
    {
        gameObject.SetActive(false);
        //gameObject.transform.localScale = new Vector3(1, 1, 1);
        //_animation.clip = _Clip[0];
        //_animation.Play();
    }

    public void UpAnimation()
    {
        gameObject.SetActive(true);
        _animation.clip = _Clip[2];
        _animation.Play();
        Invoke(nameof(SetAnimation), 1f);
    }

    void SetAnimation()
    {
        _animation.clip = _Clip[0];
        _animation.Play();
    }
}
