using UnityEngine;
using System.Collections;

public interface IAttack {

	GameObject target { get; set; }

	void DealDamage();
}
