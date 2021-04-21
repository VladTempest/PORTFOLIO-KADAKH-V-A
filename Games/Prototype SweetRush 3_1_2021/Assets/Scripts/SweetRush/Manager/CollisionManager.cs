using System;
using UnityEngine;

namespace SweetRush
{
    
    public class CollisionManager : SingletonInitiatorBase<CollisionManager>
    {
        public float _forceForPlayer = 100;

        [SerializeField]
        private float _forceForEatables=10;
        
        
        public void CollisionAnalyzer(GameObject objectInitiator,GameObject objectCollision, ref bool onGround)
    {
        if (objectInitiator.HasComponent<PlayerController>())    //Is Initiator Player?
        {
            if (objectCollision.HasComponent<BackGroundBehaviour>())
            {
                //Check if the Player was in the Air
                if (!onGround)
                {
                    //play dust fx
                    FXManager.Instance.PlayFX(objectInitiator, 5);
                    //play fall sfx
                    AudioManager.Instance.PlaySoundFX(3,7);
                }
                onGround = true;
            }
            else
            {
                if (objectCollision.HasComponent<ObstacleBehaviour>()
                ) //Is Collision Player with Obstacle? If yes destroy Collision
                {
                    UIManager.Instance.ChangeHealthUI(-1);
                    //Reset combo
                    CharacteristicManager.Instance.IncreaseEatablesCounter(false);
                    //Play explosion fx
                    FXManager.Instance.PlayFX(objectCollision, 2);
                    AudioManager.Instance.PlaySoundFX(2);
                    AudioManager.Instance.PlaySoundFX(5,(int) objectCollision.GetComponent<ObstacleBehaviour>().type);
                    Destroy(objectCollision);
                    if (GameManager.Instance._isGameStart)
                    {
                        //Make a nice impulse motion
                        objectInitiator.GetComponent<Rigidbody>().velocity = Vector3.zero;
                        objectInitiator.GetComponent<Rigidbody>().AddForce(
                            new Vector3(-0.5f, 0.5f, 0) * _forceForPlayer,
                            ForceMode.Impulse);
                        onGround = false;
                        StartCoroutine(PlayerController.Instance.PlayerInvincibility());
                    }
                }
                else if (objectCollision.HasComponent<EatablesBehaviourBase>()
                ) //Is Collision Player with Eatable? If yes destroy Collision
                {
                    
                    //Is Collision Player with Heart Pick up?
                    if (objectCollision.HasComponent<EatableHeartPickUpBehaviour>()
                    )
                    {
                        FXManager.Instance.PlayFX(objectInitiator, 6);
                        UIManager.Instance.ChangeHealthUI(1);
                        AudioManager.Instance.PlaySoundFX(3,5);
                    }
                    else
                    {
                       FXManager.Instance.PlayFX(objectCollision, 3);
                       CharacteristicManager.Instance.IncreaseEatablesCounter(true);
                        CharacteristicManager.Instance.AddPointsForEatables();
                        AudioManager.Instance.PlaySoundFX(0);
                        AudioManager.Instance.PlaySoundFX(4,CharacteristicManager.Instance.currentCombo-1);
                        //Instantiate popup score on player position
                        var position = objectInitiator.transform.position;
                        var instantiationPosition = new Vector3(position.x,
                            position.y + 3f, position.z);
                        UIManager.Instance.InstantiatePopUpScore(instantiationPosition);
                    }
                    Destroy(objectCollision);
                }
            }
        }
        else if (objectInitiator.HasComponent<EatablesBehaviourBase>())    
            //Is Initiator Eatable?
        {
            if (objectCollision.HasComponent<BackGroundBehaviour>())    
                //Is Collision Eatable with Ground?
            {
                //Description of collision Eatable with ground 
                if (!onGround) //Is this first collision with ground?
                {
                    FXManager.Instance.PlayFX(objectInitiator, 4);
                    AudioManager.Instance.PlaySoundFX(3,6);
                    onGround = true;
                    objectInitiator.GetComponent<Rigidbody>().AddForce(
                        new Vector3(-0.6f, 0.4f, 0) * _forceForEatables, 
                        ForceMode.Impulse);
                }
                else
                    //Second collision Eatable with ground.
                {
                    FXManager.Instance.PlayFX(objectInitiator, 4);
                    FXManager.Instance.PlayFX(objectInitiator, 1);
                    AudioManager.Instance.PlaySoundFX(3,9);
                    Destroy(objectInitiator);
                    
                }
            }
            else if (objectCollision.HasComponent<ObstacleBehaviour>())
                //Is Collision Eatable with Obstacle??
            {
                FXManager.Instance.PlayFX(objectCollision, 7);
                AudioManager.Instance.PlaySoundFX(5,(int) objectCollision.GetComponent<ObstacleBehaviour>().type);
                Destroy(objectCollision);
                objectInitiator.GetComponent<Rigidbody>().AddForce(
                    new Vector3(-0.4f, 0.3f, 0) * (_forceForEatables*0.3f), 
                    ForceMode.Impulse);
            }
            
        }
        else if (objectInitiator.HasComponent<BurpBehaviour>()) //Is Initiator Burp?
        {
            //Is Collision Burp with Obstacle or Eatable? 
            {
                
                //it disables collider of obstacle/eatable to prevent collision with player after burp influence
                if (objectCollision.HasComponent<ObstacleBehaviour>())
                {
                   AudioManager.Instance.PlaySoundFX(5,(int) objectCollision.GetComponentInParent<ObstacleBehaviour>().type);
                    objectCollision.GetComponentInChildren<BoxCollider>().enabled = false;
                    //Add points for killing obstacle with current number of killed by the Burp in mind
                    objectInitiator.GetComponent<BurpBehaviour>().numberOfKilledByThisBurp++;
                    CharacteristicManager.Instance.AddPointsForObstacles(objectInitiator.GetComponent<BurpBehaviour>().numberOfKilledByThisBurp);
                    FXManager.Instance.PlayFX(objectCollision, 0);
                    FXManager.Instance.PlayFlashScreenEffect();
                    AudioManager.Instance.PlaySoundFX(2);
                    //Instantiate popup score on obstacle position
                    var position = objectCollision.transform.position;
                    var instantiationPosition = new Vector3(position.x,
                        position.y + 1f, position.z);
                    UIManager.Instance.InstantiatePopUpScore(instantiationPosition);
                    Destroy(objectCollision);
                }
                else if ((objectCollision.HasComponent<EatablesBehaviourBase>()))
                {
                    FXManager.Instance.PlayFX(objectCollision, 1);
                    AudioManager.Instance.PlaySoundFX(3,9);
                    Destroy(objectCollision);
                }
                
            }
        }
        
        else if (objectInitiator.HasComponent<KillerObjectBehaviour>())
        {
            if (!objectCollision.HasComponent<SpawnedObjectBase>())
                return;
            FXManager.Instance.PlayFX(objectCollision, 0);
            FXManager.Instance.PlayFlashScreenEffect();
            AudioManager.Instance.PlaySoundFX(2);
            Destroy(objectCollision);

        }
    }

        //Trigger of Player bumping to the Truck 
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.HasComponent<PlayerController>())
            {
               
                UIManager.Instance.ChangeHealthUI(-1);
                //Reset combo
                if (GameManager.Instance._isGameStart)
                {
                    CharacteristicManager.Instance.IncreaseEatablesCounter(false);
                    other.gameObject.GetComponentInParent<Rigidbody>().velocity = Vector3.zero;
                    other.gameObject.GetComponentInParent<Rigidbody>().AddForce(
                        new Vector3(-0.5f, 0.5f, 0) * _forceForPlayer,
                        ForceMode.Impulse);
                    PlayerController.Instance._isOnGround = false;
                    AnimationManager.Instance.PlayIceCreamTruckBumpingOnBumpAnimation(0.8f);
                    StartCoroutine(PlayerController.Instance.PlayerInvincibility());
                }




            }
        }
        }
    }
    


// Class for the checking if gameObject has the Component.
public static class HasItComponent {
    public static bool HasComponent<T>(this GameObject flag)where T : Component{
        return flag.GetComponentInParent<T> () != null;
    }
}