using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class HeroHealthManager
    {
        private int healthRegen = 1;
        private float currentHealth = 100;
        private float maxHealth = 100;

        public IEnumerator HealthRegen()
        {
            while (true)
            {
                yield return new WaitForSeconds(1);

                currentHealth += healthRegen;
                if (currentHealth + healthRegen > maxHealth)
                {
                    currentHealth = maxHealth;
                }
            }
        }

        public float TakeDamage(float damage)
        {
            currentHealth -= damage;
            return currentHealth;
        }

        public float GetCurrentHealth()
        {
            return currentHealth;
        }

        public float GetMaxHealth()
        {
            return maxHealth;
        }

        public float GetHealthPercentage()
        {
            return currentHealth / maxHealth;
        }

        public bool IsDead()
        {
            return currentHealth <= 0;
        }
    }