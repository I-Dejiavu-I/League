using UnityEngine;
using TMPro;

public class PlayerGeneral : MonoBehaviour
{
    //CoreChampionStateMachine
    CoreChampionStateMachine CoreChampionStateMachine;
    public CoreChampionStateMachine CORECHAMPIONSTATEMACHINE => CoreChampionStateMachine;
    //CoreCHampionStates
    CoreChampionStateCollection CoreChampionStates;
    public CoreChampionStateCollection CORECHAMPIONSTATES => CoreChampionStates;


    // ---------------------------------------------------------------------------------------//

    [Header("Components")]
    [SerializeField] Rigidbody Rigidbody;

    [Header("UI")]
    [SerializeField] TextMeshProUGUI CurrentState;

    private void Awake()
    {
        //CoreChampionStateMachine
        CoreChampionStateMachine = new CoreChampionStateMachine();
        CoreChampionStates = new CoreChampionStateCollection(this, CoreChampionStateMachine);
    }

    // ---------------------------------------------------------------------------------------//

    void Start()
    {
        CoreChampionStateMachine.Initialize(CoreChampionStates.IDLESTATE);
    }

    void Update()
    {
        CoreChampionStateMachine.state.Update();
        CurrentState.text = CoreChampionStateMachine.ToString();
    }

    private void FixedUpdate()
    {
        CoreChampionStateMachine.state.FixedUpdate();
    }

    private void LateUpdate()
    {
        CoreChampionStateMachine.state.LateUpdate();
    }
}
