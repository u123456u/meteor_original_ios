using UnityEngine;
using System.Collections;

public class Script_FadeInOut_new : MonoBehaviour
{
    public bool UseFadeInOut = true;
	public float FadeInStartAt = 0;
	public float FadeInLast = 1;
	public float FadeOutStartAt = 2;
	public float FadeOutLast = 1;
    public int FadeLoopCount = 1;
    public float FadeLoopInterval = 2;
    public bool UseAlpha = true;
	public float FadeAlpha=128;
		
  	float timer = 0;
    int loopcount = 0;
	bool bInitialized = false;
    bool bSetIn = false;
    bool bSetOut = false;
	// Use this for initialization
	void Start ()
	{
		
	}
	// Update is called once per frame
	void Update ()
	{
		bool des = false;
		timer += Time.deltaTime;
		float alphaVal = 0;

        if (UseFadeInOut)
        {
            if (timer < FadeInStartAt)
            {
                alphaVal = 0;
                if (bInitialized)
                {
                    return;
                }
                else
                {
                    bInitialized = true;
                }
            }
            else if (timer < FadeInStartAt + FadeInLast)
            {
                alphaVal = Mathf.Lerp(0, 1, (timer - FadeInStartAt) / FadeInLast);
            }
            else if (timer < FadeOutStartAt)
            {
                alphaVal = 1;
                if (bSetIn)
                {
                    return;
                }
                else
                {
                    bSetIn = true;
                }
            }
            else if (timer < FadeOutStartAt + FadeOutLast)
            {
                alphaVal = Mathf.Lerp(1, 0, (timer - FadeOutStartAt) / FadeOutLast);
            }
            else if (timer < FadeOutStartAt + FadeOutLast + FadeLoopInterval)
            {
                alphaVal = 0;
                if (bSetOut)
                {
                    return;
                }
                else
                {
                    bSetOut = true;
                }
            }
            else
            {
                alphaVal = 0;
                loopcount += 1;
                if (loopcount < FadeLoopCount || FadeLoopCount < 1)
                {
                    timer = FadeInStartAt;
                    bInitialized = false;
                    bSetIn = false;
                    bSetOut = false;
                }
                else
                {
                    des = true;
                }
            }
        }
			
		Renderer[] rds = gameObject.GetComponentsInChildren<Renderer>(true);
        foreach (Renderer rd in rds)
        {
			
            if (rd.material.HasProperty("_Color"))
			{
				Vector4 c = rd.material.GetVector("_Color");
			//	c.w = c.w*alphaVal;
			//	c.w=alphaVal*(rd.material.GetColor("_Color").a);

                if (UseFadeInOut && UseAlpha) c.w = alphaVal * FadeAlpha / 255;
                else if (UseFadeInOut) c.w = alphaVal;
                else if (UseAlpha) c.w = FadeAlpha / 255;
                else {}

                rd.material.SetVector("_Color", c);
			}
            if (rd.material.HasProperty("_TintColor"))
			{
				Vector4 c = rd.material.GetVector("_TintColor");
			//	c.w = c.w*alphaVal;
			//	c.w=alphaVal*(rd.material.GetColor("_TintColor").a);
			//	c.w=alphaVal;
			//	c.w=alphaVal*FadeAlpha/255;
                if (UseFadeInOut && UseAlpha) c.w = alphaVal * FadeAlpha / 255;
                else if (UseFadeInOut) c.w = alphaVal;
                else if (UseAlpha) c.w = FadeAlpha / 255;
                else { }

                rd.material.SetVector("_TintColor", c);
			}
			
        }
		if(des)
			Destroy(this);
	}
}

