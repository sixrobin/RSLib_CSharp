namespace RSLib.CSharp.FSM
{
    using System.Collections.Generic;

    public abstract class FSMState<TStateID, TTransitionID, TBehaviourContext> where TStateID : System.Enum where TTransitionID : System.Enum
    {
        public FSMState(TStateID id)
        {
            Id = id;
        }

        private readonly Dictionary<TTransitionID, TStateID> _transitionsMap = new Dictionary<TTransitionID, TStateID>();

        public TStateID Id { get; }

        public bool AddTransition(TTransitionID transition, TStateID id)
        {
            if (_transitionsMap.ContainsKey(transition))
            {
                return false;
            }
            
            _transitionsMap.Add(transition, id);
            return true;
        }

        public bool RemoveTransition(TTransitionID transition)
        {
            if (!_transitionsMap.ContainsKey(transition))
            {
                return false;
            }
            
            _transitionsMap.Remove(transition);
            return true;
        }

        public TStateID GetTransitionOutputState(TTransitionID transition)
        {
            if (!_transitionsMap.ContainsKey(transition))
            {
                return default;
            }
            
            return _transitionsMap[transition];
        }

        public virtual void OnStateEntered()
        {
        }
        
        public virtual void OnStateExit()
        {
        }

        /// <summary>
        /// State transition if current context requires one.
        /// </summary>
        public abstract TTransitionID Reason(TBehaviourContext context);

        /// <summary>
        /// State behaviour.
        /// </summary>
        public abstract void Act(TBehaviourContext context);
    }
}