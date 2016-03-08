using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Map2CivilizationCtrl.Listener;

namespace Map2CivilizationCtrl.Listener
{
    public  class UIListenersRegister<T> where T : IUiListener
    {
        Collection<T> _internalList = new Collection<T>();

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
