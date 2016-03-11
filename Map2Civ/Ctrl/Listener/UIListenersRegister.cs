using System;
using System.Collections.ObjectModel;

namespace Map2CivilizationCtrl.Listener
{
    public  class UIListenersRegister<T> where T : IUiListener
    {
        readonly Collection<T> _internalList = new Collection<T>();

        public Collection<T> ListenersList
        {
            get
            {
                return _internalList;
            }
        }


        public void RegisterObserver(T implementer)
        {
            _internalList.Add(implementer);
        }

        public void DeregisterObserver(T implementer)
        {
            _internalList.Remove(implementer);
        }

        public Boolean Contains(T implementer)
        {
            return _internalList.Contains(implementer);
        }

        
    }
}
