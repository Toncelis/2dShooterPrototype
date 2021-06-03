using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobEditorSetup : MonoBehaviour
{
    [SerializeField] MobType type;
    [SerializeField] Settings.SO_Settings_Balance settings;

    [Space(15)]

    [SerializeField] Battle.Mob_MovementController movementController;
    [SerializeField] Battle.MobState state;
    [SerializeField] Battle.Mob_Attack attack;

    private void OnValidate()
    {
        if (movementController != null)
        {
            movementController.mobVariant = type;
            movementController.settings = settings;
        }
        if (attack != null)
        {
            attack.mobVariant = type;
            attack.settings = settings;
        }
        if (state != null)
        {
            state.mobVariant = type;
            state.settings = settings;
        }
    }

    private void Start()
    {
        Destroy(this);
    }
}
