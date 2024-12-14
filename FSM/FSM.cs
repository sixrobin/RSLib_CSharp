namespace RSLib.CSharp.FSM
{
    using System.Collections.Generic;
    
    public class FSM<TState, TTransition, TBehaviourContext> where TState : System.Enum where TTransition : System.Enum
    {
        public FSM()
        {
        }

        public FSM(params FSMState<TState, TTransition, TBehaviourContext>[] states)
        {
            for (int i = 0; i < states.Length; ++i)
                AddState(states[i]);
        }
        
        private readonly List<FSMState<TState, TTransition, TBehaviourContext>> _states = new List<FSMState<TState, TTransition, TBehaviourContext>>();

        public TState CurrentStateID { get; private set; }
        
        public FSMState<TState, TTransition, TBehaviourContext> CurrentState { get; private set; }

        public void AddState(FSMState<TState, TTransition, TBehaviourContext> state)
        {
            _states.Add(state);

            // First state is set as current one.
            if (_states.Count == 1)
            {
                CurrentState = state;
                CurrentStateID = state.Id;
            }
        }

        public bool RemoveState(TState state)
        {
            for (int i = _states.Count - 1; i >= 0; --i)
            {
                if (EqualityComparer<TState>.Default.Equals(_states[i].Id, state))
                {
                    _states.RemoveAt(i);
                    return true;
                }
            }

            return false;
        }

        public bool PerformTransition(TTransition transition)
        {
            TState state = CurrentState.GetTransitionOutputState(transition);

            for (int i = _states.Count - 1; i >= 0; --i)
            {
                if (!EqualityComparer<TState>.Default.Equals(_states[i].Id, state))
                {
                    continue;
                }
                
                CurrentStateID = state;
                CurrentState.OnStateExit();
                CurrentState = _states[i];
                CurrentState.OnStateEntered();
                
                return true;
            }

            return false;
        }
    }
}