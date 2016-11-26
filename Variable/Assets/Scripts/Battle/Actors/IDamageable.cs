using UnityEngine;
using System.Collections;

public interface IDamageable {

	int health { get; set; }

	void TakeDamage(int dmg);
}
