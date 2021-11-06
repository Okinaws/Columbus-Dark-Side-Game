using UnityEngine;

public class Fight2D : MonoBehaviour
{
	static GameObject NearTarget(Vector3 position, Collider2D[] array)
	{
		Collider2D current = null;
		float dist = Mathf.Infinity;

		foreach (Collider2D coll in array)
		{
			float curDist = Vector3.Distance(position, coll.transform.position);

			if (curDist < dist)
			{
				current = coll;
				dist = curDist;
			}
		}

		return (current != null) ? current.gameObject : null;
	}

	public static void Action(Vector2 point, float radius, int layerMask, float damage, bool allTargets)
	{
		Collider2D[] colliders = Physics2D.OverlapCircleAll(point, radius, 1 << layerMask);

		if (!allTargets)
		{
			GameObject obj = NearTarget(point, colliders);
			if (obj != null && obj.GetComponent<Hp>())
			{
				obj.GetComponent<Hp>().Hit(damage);
			}
			return;
		}

		foreach (Collider2D hit in colliders)
		{
			if (hit.GetComponent<Hp>())
			{
				hit.GetComponent<Hp>().Hit(damage);
			}
		}
	}
}
