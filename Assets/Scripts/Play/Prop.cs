using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prop : MonoBehaviour
{
    public float FallSpeed=2f;
    public Effect PropEffect;
    public enum Effect
    {
        AddScore,
        UpSpeed,
		MaxEnergy,
        AutoShoot,
	}
    public void TriggerEffect()
    {
        switch (PropEffect)
        {
            case Effect.AddScore:
                ScoreManager.AddScore(ScoreManager.ScoreSource.GetProp, 100);
                break;
            case Effect.UpSpeed:
                GameObject.FindGameObjectWithTag("Player").GetComponent<CarControl>().CarSpeedUp();
				ScoreManager.AddScore(ScoreManager.ScoreSource.GetProp, 30);
				break;
            case Effect.MaxEnergy:
				GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<ShootItem>().KeepMaxEnergyStorage();
				ScoreManager.AddScore(ScoreManager.ScoreSource.GetProp, 30);
				break;
            case Effect.AutoShoot:

                break;
            default:
                break;
        }
    }

	private void Update()
	{
        transform.position -= Time.deltaTime * FallSpeed * Vector3.one;
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
	}

}
