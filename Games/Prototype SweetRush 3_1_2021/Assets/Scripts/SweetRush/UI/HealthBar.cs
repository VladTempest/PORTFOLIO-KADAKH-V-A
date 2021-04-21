using UnityEngine.UI;
using UnityEngine;

namespace SweetRush
{
    public class HealthBar : MonoBehaviour
    {
    public int _currentHealth = 0;
        [SerializeField]
        private int _maxHealth = 0; //Для дальнейшего использования 
        [SerializeField]
        private GameObject _healthBar = null;
        
        public GameObject[] healthBarVisible = null;
        [SerializeField]
        private PoolHeartOfHealthbarSettings _poolHeart = null;


        [SerializeField]
        private Vector3 _positionOfFirstHeart = new Vector3(100f, 920f, 0f);
        [SerializeField]
        private Vector3 _offsetPositionOfFirstHeart = new Vector3(80f, -20f, 0f);
        private static readonly int IsHeartDead = Animator.StringToHash("isHeartDead");

        public void CreateHealthBar()
        //Create healthbar from pool of Game Object Hearts.
        {
            healthBarVisible = new GameObject[_poolHeart.pool.Count]; //Set Length of Array of Hearts to Length of Heart pool.
            for (int i = 0; i < healthBarVisible.Length; i++) //Create HealthBar and place it in Canvas.
            {
                healthBarVisible[i] = Instantiate(_poolHeart.pool[i],
                    _positionOfFirstHeart + (_offsetPositionOfFirstHeart * i), transform.rotation);
                healthBarVisible[i].transform.SetParent(_healthBar.transform);
            }

            _maxHealth = healthBarVisible.Length;
            _currentHealth = _maxHealth;
        }
        public void ChangeHealth(int changeValue)
        {
            if (changeValue == 0) //Change color of Heart if Health changed.
            {
                foreach (var t in healthBarVisible)
                {
                    t.GetComponent<RawImage>().color = Color.white;
                }
                return;
            }
            {
                _currentHealth += changeValue;
                if ((_currentHealth >= 0) && (_currentHealth <= _maxHealth))
                {
                    if (changeValue < 0)
                    {
                        if (!CharacteristicManager.Instance.CheckForGameOver(_currentHealth))
                            //Check for the GameOver, and then change color of Heart.
                        {
                            healthBarVisible[_currentHealth].GetComponent<RawImage>().color = Color.grey;
                            healthBarVisible[_currentHealth].GetComponent<Animator>().SetBool(IsHeartDead,true);
                        }
                    }
                    else
                    {
                        healthBarVisible[_currentHealth-1].GetComponent<RawImage>().color = Color.white;
                        healthBarVisible[_currentHealth-1].GetComponent<Animator>().SetBool(IsHeartDead,false);
                    }
                }
                else _currentHealth--;
            }
        }
    }
}
